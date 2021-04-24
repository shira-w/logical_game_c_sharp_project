using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace project2020
{
    /// <summary>
    /// Interaction logic for newpractice.xaml
    /// </summary>
    public partial class newpractice : Window
    {
        const int type = 1;
        bool anableAuodio = true;
        enum ResultType
        {
            SingleRes,
            ArrayRes
        }
        ResultType currDeviceResType;
        string rtype;
        int rsize;
        public binaributton[] binaributtons;
        public Image[] carray=new Image[6];
        private MediaPlayer mediaPlayer;
        public newpractice()
        {
            InitializeComponent();

        }
        public int [] currentNArray=new int[15];
        string currentType;


        public int[] PictureToNumberArray(Image[] binImages, int size)
        {
            int[] numarray = new int[size];
            for (int i = 0; i < size; i++)
            {
                numarray[i] = PictureToNumber(binImages[i]);

            }
            return numarray;
        }
        public static int PictureToNumber(Image binImages)
        {
            //string s = binImages.ToString();
            if (binImages.ToString() == "./wpf-master/project2020/IMG1/00.png")
                return 0;
            if (binImages.ToString() == "./הורדות/wpf-master/project2020/IMG1/11.png")
                return 1;
            return -1;
        }
        // פונקציה להוספת משווה גודל
        public void addmg(int size, int hc, int c1a, int c1b, int c1c, int c1d, int c2a, int c2b, int c2c, int c2d)
        {
            rtype = "mg";
            binaributton[] binaributtons = new binaributton[3];
            Image[] carray1 = new Image[size];
            Image[] carray2 = new Image[size];
            int[] tempNarrayForC1 = new int[size];
            int[] tempNarrayForC2 = new int[size];
            //////////////////////////////////////////////////////////
            int ya = 328, yc = 435;
            int ca = 335, cc = 415;

            for (int i = 0; i < 3; i++)
            {
                binaributtons[i] = new binaributton(ya, 222, yc, 119, i,0);
                ya += 44; yc -= 44;
                grid1.Children.Add(binaributtons[i]);
            }

            for (int i = 0; i < size; i++)
            {
                carray1[i] = new Image();
                carray1[i].Margin = new Thickness(c1a, c1b, c1c, c1d);
                c1a += hc; c1c -= hc;
                random(carray1, i, tempNarrayForC1);
                grid1.Children.Add(carray1[i]);
            }


            for (int i = 0; i < size; i++)
            {
                carray2[i] = new Image();
                carray2[i].Margin = new Thickness(c2a, c2b, c2c, c2d);
                c2a += hc; c2c -= hc;
                random(carray2, i, tempNarrayForC2);
                grid1.Children.Add(carray2[i]);
            }
            int[] narrayComb = new int[2 * size];
            int k;
            for (k=0; k < size; k++ )
            {
                narrayComb[k] = tempNarrayForC1[k];
            }
            narrayComb[k] = -2;
            k++;
            int f = 0;

            for (int t=k;t<2*size; t++)
            {
                narrayComb[t] = tempNarrayForC2[f];
                f++;
            }
            currentNArray = narrayComb;
            currentType = "Compares size";
            //Height = "166" Margin = "307,82,0,0" VerticalAlignment = "Top" Width = "164"
            grid2.Height = 166;
            grid2.Width = 164;
            grid2.Margin = new Thickness(307, 82, 0, 0);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/משווה גודל.png", UriKind.Relative));
            myBrush.ImageSource = image.Source;
            grid2.Background = myBrush;
            // set expected result
            BL.Class1.refOutputBinaryArr = BL.Class1.MagnitudeComparator(BL.Class1.rndInputBinaryArr,
                                                                        BL.Class1.rndInput2BinaryArr,
                                                                        BL.Class1.refOutputBinaryArr);
            
        }
        //משווה גודל  משוחזר        
        public void mgAfterSave(int size, int hc, int c1a, int c1b, int c1c, int c1d, int c2a, int c2b, int c2c, int c2d, int [] arr1, int[] arr2)
        {
            rtype = "mg";
            binaributton[] binaributtons = new binaributton[3];
            Image[] carray1 = new Image[size];
            Image[] carray2 = new Image[size];
            //////////////////////////////////////////////////////////
            int ya = 328, yc = 435;
            int ca = 335, cc = 415;

            for (int i = 0; i < 3; i++)
            {
                binaributtons[i] = new binaributton(ya, 222, yc, 119, i, 0);
                ya += 44; yc -= 44;
                grid1.Children.Add(binaributtons[i]);
            }

            for (int i = 0; i < size; i++)
            {
                carray1[i] = new Image();
                carray1[i].Margin = new Thickness(c1a, c1b, c1c, c1d);
                c1a += hc; c1c -= hc;
                addToImages(carray1, i, arr1);
                grid1.Children.Add(carray1[i]);
            }


            for (int i = 0; i < size; i++)
            {
                carray2[i] = new Image();
                carray2[i].Margin = new Thickness(c2a, c2b, c2c, c2d);
                c2a += hc; c2c -= hc;
                addToImages(carray2, i, arr2);
                grid1.Children.Add(carray2[i]);
            }
            //Height = "166" Margin = "307,82,0,0" VerticalAlignment = "Top" Width = "164"
            grid2.Height = 166;
            grid2.Width = 164;
            grid2.Margin = new Thickness(307, 82, 0, 0);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/משווה גודל.png", UriKind.Relative));
            myBrush.ImageSource = image.Source;
            grid2.Background = myBrush;
            // set expected result
            BL.Class1.refOutputBinaryArr = BL.Class1.MagnitudeComparator(BL.Class1.rndInputBinaryArr,
                                                                        BL.Class1.rndInput2BinaryArr,
                                                                        BL.Class1.refOutputBinaryArr);

        }
        //חצי מחבר
        public void addhzmechaber(int numof)
        {
            currDeviceResType = ResultType.ArrayRes;
            rsize = numof;
            if (numof == 2)
            {
                rtype = "hmechaber";
                //C-שארית Z-תוצאה
                
                binaributton z = new binaributton(381, 237, 383, 131, 0, type);
                grid1.Children.Add(z);                
                binaributton c = new binaributton(269, 237, 495, 132, 1, type);
                grid1.Children.Add(c);

                // מערך הכניסות
                Image[] carray = new Image[2];
                int[] tempNarray = new int[2];
                ////////////////////////////////////////////////////////////
                for (int i = 0; i < 2; i++)
                {
                    carray[i] = new Image();
                    random(carray, i, tempNarray);
                    grid1.Children.Add(carray[i]);
                }
                carray[0].Margin = new Thickness(401, 52, 347, 330);
                carray[1].Margin = new Thickness(340, 52, 408, 330);
                currentNArray = tempNarray;
                currentType = "Half connective";
                grid2.Height = 165;
                grid2.Width = 203;
                grid2.Margin = new Thickness(276, 84, 0, 0);
                ImageBrush myBrush = new ImageBrush();
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"../../IMG1/חציי מחבר.png", UriKind.Relative));
                myBrush.ImageSource = image.Source;
                grid2.Background = myBrush;                
            }
            //מחבר מלא....CIN
            else
            {
                rtype = "connective";
                binaributton z = new binaributton(364, 237, 400, 131, 0, type);
                grid1.Children.Add(z);
                binaributton c = new binaributton(269, 230, 495, 139, 1, type);
                grid1.Children.Add(c);

                //CIN מערך הכניסות-במקרה שהמחבר מלא תהיינה 3 כניסות שאחת מהן היא -האיבר האחרון במערך
                Image[] carray = new Image[3];
                int[] tempNarray = new int[3];

                /////////////////////////////////////////////////////////
                for (int i = 0; i < 3; i++)
                {
                    carray[i] = new Image();
                    random(carray, i, tempNarray);
                    grid1.Children.Add(carray[i]);
                }

                carray[0].Margin = new Thickness(446, 52, 302, 330);
                carray[1].Margin = new Thickness(381, 52, 367, 330);
                carray[2].Margin = new Thickness(328, 52, 420, 330);
                currentNArray = tempNarray;
                currentType = "connective";
                grid2.Height = 165;
                grid2.Width = 203;
                grid2.Margin = new Thickness(276, 84, 0, 0);
                ImageBrush myBrush = new ImageBrush();
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"../../IMG1/מחבר מלאא.png", UriKind.Relative));
                myBrush.ImageSource = image.Source;
                grid2.Background = myBrush;

            }
            // set expected result

            BL.Class1.refOutputBinaryArr = BL.Class1.Adder(BL.Class1.rndInputBinaryArr, BL.Class1.refOutputBinaryArr, rsize); 
        }

        //מחבר משוחזר
        public void hzmechaberafterSave(int numof, int[]arr)
        {
            currDeviceResType = ResultType.ArrayRes;
            rsize = numof;
            if (numof == 2)
            {
                rtype = "hmechaber";
                //C-שארית Z-תוצאה

                binaributton z = new binaributton(381, 237, 383, 131, 0, type);
                grid1.Children.Add(z);
                binaributton c = new binaributton(269, 237, 495, 132, 1, type);
                grid1.Children.Add(c);

                // מערך הכניסות
                Image[] carray = new Image[2];
                ////////////////////////////////////////////////////////////
                for (int i = 0; i < 2; i++)
                {
                    carray[i] = new Image();
                    addToImages(carray, i, arr);
                    grid1.Children.Add(carray[i]);
                }
                carray[0].Margin = new Thickness(401, 52, 347, 330);
                carray[1].Margin = new Thickness(340, 52, 408, 330);
                grid2.Height = 165;
                grid2.Width = 203;
                grid2.Margin = new Thickness(276, 84, 0, 0);
                ImageBrush myBrush = new ImageBrush();
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"../../IMG1/חציי מחבר.png", UriKind.Relative));
                myBrush.ImageSource = image.Source;
                grid2.Background = myBrush;
            }
            //מחבר מלא....CIN
            else
            {
                rtype = "mechaber";
                binaributton z = new binaributton(364, 237, 400, 131, 0, type);
                grid1.Children.Add(z);
                binaributton c = new binaributton(269, 230, 495, 139, 1, type);
                grid1.Children.Add(c);

                //CIN מערך הכניסות-במקרה שהמחבר מלא תהיינה 3 כניסות שאחת מהן היא -האיבר האחרון במערך
                Image[] carray = new Image[3];

                /////////////////////////////////////////////////////////
                for (int i = 0; i < 3; i++)
                {
                    carray[i] = new Image();
                    addToImages(carray, i, arr);
                    grid1.Children.Add(carray[i]);
                }

                carray[0].Margin = new Thickness(446, 52, 302, 330);
                carray[1].Margin = new Thickness(381, 52, 367, 330);
                carray[2].Margin = new Thickness(328, 52, 420, 330);
                grid2.Height = 165;
                grid2.Width = 203;
                grid2.Margin = new Thickness(276, 84, 0, 0);
                ImageBrush myBrush = new ImageBrush();
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"../../IMG1/מחבר מלאא.png", UriKind.Relative));
                myBrush.ImageSource = image.Source;
                grid2.Background = myBrush;

            }
            // set expected result

            BL.Class1.refOutputBinaryArr = BL.Class1.Adder(BL.Class1.rndInputBinaryArr, BL.Class1.refOutputBinaryArr, rsize);
        }
        //מפענח
        public void addmefaaneh(int size, int ca, int cb, int cc, int cd, int ya, int yb, int yc, int yd, int hc, int hy, int gridh, int gridw, int grida, int gridb, int gridc, int gridd)
        {
            currDeviceResType = ResultType.ArrayRes;
            rtype = "mefaaneah";
            binaributton[] binaributtons = new binaributton[(int)Math.Pow(2, size)];
            
            
            Image[] carray = new Image[size];
            int[] tempNarray = new int[size];

            for (int i = 0; i < (int)Math.Pow(2, size); i++)
            {
                binaributtons[i] = new binaributton(ya, yb, yc, yd, i, type);
                yb += hy; yd -= hy;
                grid1.Children.Add(binaributtons[i]);
            }

            for (int i = 0; i < size; i++)
            {
                carray[i] = new Image();
                carray[i].Margin = new Thickness(ca, cb, cc, cd);
                cb += hc; cd -= hc;
                random(carray, i, tempNarray);
                grid1.Children.Add(carray[i]);
            }
            currentNArray = tempNarray;
            currentType = "Decoder";
            // set expected result
            BL.Class1.refOutputBinaryArr = BL.Class1.Decoder(BL.Class1.rndInputBinaryArr, BL.Class1.refOutputBinaryArr);
            
            grid2.Height = gridh;
            grid2.Width = gridw;
            grid2.Margin = new Thickness(grida, gridb, gridc, gridd);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/מפענח " + size + " כניסות.png", UriKind.Relative));
            myBrush.ImageSource = image.Source;
            grid2.Background = myBrush;
        }
        //שחזור מפענח
        public void mefaanehAfterSave(int size, int ca, int cb, int cc, int cd, int ya, int yb, int yc, int yd, int hc, int hy, int gridh, int gridw, int grida, int gridb, int gridc, int gridd, int[] arr)
        {
            currDeviceResType = ResultType.ArrayRes;
            rtype = "mefaaneah";
            binaributton[] binaributtons = new binaributton[(int)Math.Pow(2, size)];
            Image[] carray = new Image[size];

            for (int i = 0; i < (int)Math.Pow(2, size); i++)
            {
                binaributtons[i] = new binaributton(ya, yb, yc, yd, i, type);
                yb += hy; yd -= hy;
                grid1.Children.Add(binaributtons[i]);
            }
            for (int i = 0; i < size; i++)
            {
                carray[i] = new Image();
                carray[i].Margin = new Thickness(ca, cb, cc, cd);
                cb += hc; cd -= hc;
                addToImages(carray, i, arr);
                grid1.Children.Add(carray[i]);
            }
            // set expected result
            BL.Class1.refOutputBinaryArr = BL.Class1.Decoder(BL.Class1.rndInputBinaryArr, BL.Class1.refOutputBinaryArr);

            grid2.Height = gridh;
            grid2.Width = gridw;
            grid2.Margin = new Thickness(grida, gridb, gridc, gridd);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/מפענח " + size + " כניסות.png", UriKind.Relative));
            myBrush.ImageSource = image.Source;
            grid2.Background = myBrush;
        }
            //מרבב
        public void addmerabev(int size, int ca, int cb, int cc, int cd, int cma, int cmb, int cmc, int cmd, int hc, int hcm, int gridh, int gridw, int grida, int gridb, int gridc, int gridd, int ya, int yb, int yc, int yd)
        {
            currDeviceResType = ResultType.SingleRes;
            rtype = "merabev";
            binaributton y = new binaributton(ya, yb, yc, yd, 0, type);
            grid1.Children.Add(y);
            ///////////////////////////////////////////////////////
            Image[] c = new Image[size]; //multpilexer select
            Image[] cm = new Image[(int)Math.Pow(2, size)]; //multiplexer data in 
            int []tempNarrayForC = new int[size];
            int[] tempNarrayForCm = new int[(int)Math.Pow(2, size)];
            ///////////////////////////////////////////////////////
            // data in
            for (int i = 0; i < (int)Math.Pow(2, size); i++)
            {
                cm[i] = new Image();
                cm[i].Margin = new Thickness(cma, cmb, cmc, cmd);
                cmb += hcm; cmd -= hcm;
                random(cm, i, tempNarrayForCm);
                grid1.Children.Add(cm[i]);
            }
            //multpilexer select
            for (int i = 0; i < size; i++)
            {
                c[i] = new Image();
                c[i].Margin = new Thickness(ca, cb, cc, cd);
                ca -= hc; cc += hc;
                random(c, i, tempNarrayForC, 1);
               grid1.Children.Add(c[i]);
            }
            int[] NcarrayComb = new int[(int)Math.Pow(2, size) + size+1];
            int k;
            for (k = 0; k < size; k++)
            {
                NcarrayComb[k] = tempNarrayForC[k];
            }
            
            NcarrayComb[k] = -2;
            k++;
            int f = 0;
            for (int t = k; t < (int)Math.Pow(2, size) + size; t++)
            {
                NcarrayComb[t] = tempNarrayForCm[f];
                f++;
            }
            currentNArray = NcarrayComb;
            currentType = "Multiplexer";
            // set expected result
            BL.Class1.refOutputBinary = BL.Class1.Multiplexer(BL.Class1.rndInput2BinaryArr, BL.Class1.rndInputBinaryArr);

            grid2.Height = gridh;
            grid2.Width = gridw;
            grid2.Margin = new Thickness(grida, gridb, gridc, gridd);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/מרבב " + size + ".png", UriKind.Relative));
            myBrush.ImageSource = image.Source;
            
            grid2.Background = myBrush;
            // set default output
            BL.Class1.outputBinary = 0;

        }


        public void merabevAfterSave(int size, int ca, int cb, int cc, int cd, int cma, int cmb, int cmc, int cmd, int hc, int hcm, int gridh, int gridw, int grida, int gridb, int gridc, int gridd, int ya, int yb, int yc, int yd, int[] arr1, int[]arr2)
        {
            currDeviceResType = ResultType.SingleRes;
            rtype = "merabev";
            binaributton y = new binaributton(ya, yb, yc, yd, 0, type);
            grid1.Children.Add(y);
            Image[] c = new Image[size]; //multpilexer select
            Image[] cm = new Image[(int)Math.Pow(2, size)]; //multiplexer data in 
            for (int i = 0; i < (int)Math.Pow(2, size); i++)
            {
                cm[i] = new Image();
                cm[i].Margin = new Thickness(cma, cmb, cmc, cmd);
                cmb += hcm; cmd -= hcm;
                addToImages(cm, i, arr2);
                grid1.Children.Add(cm[i]);
            }
            //multpilexer select
            for (int i = 0; i < size; i++)
            {
                c[i] = new Image();
                c[i].Margin = new Thickness(ca, cb, cc, cd);
                ca -= hc; cc += hc;
                addToImages(c, i, arr1,1);
                grid1.Children.Add(c[i]);
            }
            // set expected result
            BL.Class1.refOutputBinary = BL.Class1.Multiplexer(BL.Class1.rndInput2BinaryArr, BL.Class1.rndInputBinaryArr);

            grid2.Height = gridh;
            grid2.Width = gridw;
            grid2.Margin = new Thickness(grida, gridb, gridc, gridd);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/מרבב " + size + ".png", UriKind.Relative));
            myBrush.ImageSource = image.Source;

            grid2.Background = myBrush;
            // set default output
            BL.Class1.outputBinary = 0;
        }
        //מקודד
        public void addmkdd(int size, int ca, int cb, int cc, int cd, int ya, int yb, int yc, int yd, int hc, int hy, int gridh, int gridw, int grida, int gridb, int gridc, int gridd)
        {
            currDeviceResType = ResultType.ArrayRes;
            rtype = "mkdd";
            binaributton[] binaributtons = new binaributton[size];
            Image[] carray = new Image[(int)Math.Pow(2, size)];
            int[] tempNarray = new int[(int)Math.Pow(2, size)];
            for (int i = 0; i < size; i++)
            {
                binaributtons[i] = new binaributton(ya, yb, yc, yd, i, type);
                yb += hy; yd -= hy;
                grid1.Children.Add(binaributtons[i]);
            }

            for (int i = 0; i < (int)Math.Pow(2, size); i++)
            {
                carray[i] = new Image();
                carray[i].Margin = new Thickness(ca, cb, cc, cd);
                cb += hc; cd -= hc;
                random(carray, i,tempNarray, 0);
                grid1.Children.Add(carray[i]);
            }

            //// set expected result
            //BL.Class1.refOutputBinaryArr = BL.Class1.Decoder(BL.Class1.rndInputBinaryArr, BL.Class1.refOutputBinaryArr);
            currentNArray = tempNarray;
            currentType = "encoder";

            grid2.Height = gridh;
            grid2.Width = gridw;
            grid2.Margin = new Thickness(grida, gridb, gridc, gridd);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/מקודד " + size + ".png", UriKind.Relative));
            myBrush.ImageSource = image.Source;


            grid2.Background = myBrush;


        }
        public void mkddAfterSave(int size, int ca, int cb, int cc, int cd, int ya, int yb, int yc, int yd, int hc, int hy, int gridh, int gridw, int grida, int gridb, int gridc, int gridd, int[]arr)
        {
            currDeviceResType = ResultType.ArrayRes;
            rtype = "mkdd";
            binaributton[] binaributtons = new binaributton[size];
            Image[] carray = new Image[(int)Math.Pow(2, size)];
            for (int i = 0; i < size; i++)
            {
                binaributtons[i] = new binaributton(ya, yb, yc, yd, i, type);
                yb += hy; yd -= hy;
                grid1.Children.Add(binaributtons[i]);
            }

            for (int i = 0; i < (int)Math.Pow(2, size); i++)
            {
                carray[i] = new Image();
                carray[i].Margin = new Thickness(ca, cb, cc, cd);
                cb += hc; cd -= hc;
                addToImages(carray, i, arr);
                grid1.Children.Add(carray[i]);
            }

            //// set expected result
            //BL.Class1.refOutputBinaryArr = BL.Class1.Decoder(BL.Class1.rndInputBinaryArr, BL.Class1.refOutputBinaryArr);

            grid2.Height = gridh;
            grid2.Width = gridw;
            grid2.Margin = new Thickness(grida, gridb, gridc, gridd);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/מקודד " + size + ".png", UriKind.Relative));
            myBrush.ImageSource = image.Source;


            grid2.Background = myBrush;


        }

        // הגרלת מספר בינארי והצגת תמונה מתאימה
        public void random(Image[] carray, int i,int[] tempNArray ,int inputNum=0)
        {
            int rand = (int)BL.Class1.rnd.Next(0, 2);
            if (inputNum == 0)
            {
                BL.Class1.rndInputBinary += (int)(Math.Pow(2.0, (double)i) * rand);
                BL.Class1.rndInputBinaryArr[i] = rand;
            }
            else
            {
                BL.Class1.rndInput2Binary += (int)(Math.Pow(2.0, (double)i) * rand);
                BL.Class1.rndInput2BinaryArr[i] = rand;
            }

            if (rand == 0)
            {
                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c0.png", UriKind.Relative));
                tempNArray[i] = 0;
            }
            else
            {
                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c1.png", UriKind.Relative));
                tempNArray[i] = 1;
            }
        }
        // שימוש במספר ממערך השמירה להצגת תמונה מתאימה
        public void addToImages(Image[] carray, int i, int[] savedNArray, int inputNum = 0)
        {
            int currentNum = savedNArray[i];
            if (inputNum == 0)
            {
                BL.Class1.rndInputBinary += (int)(Math.Pow(2.0, (double)i) * currentNum);
                BL.Class1.rndInputBinaryArr[i] = currentNum;
            }
            else
            {
                BL.Class1.rndInput2Binary += (int)(Math.Pow(2.0, (double)i) * currentNum);
                BL.Class1.rndInput2BinaryArr[i] = currentNum;
            }

            if (currentNum == 0)
            {
                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c0.png", UriKind.Relative));
            }
            else
            {
                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c1.png", UriKind.Relative));
            }
        }




        private void save_Click(object sender, RoutedEventArgs e)
        {
            savepractice savepractice = new savepractice();
            savepractice.updateNarray(currentNArray);
            savepractice.updateType(currentType);
            savepractice.Show();
           

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            BL.Class1.ResetIo();
            typeselection typeselection = new typeselection();
            typeselection.part = 1;
            typeselection.Show();
            this.Close();
        }

        private void bdk_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currDeviceResType == ResultType.SingleRes)
            {
                if (BL.Class1.refOutputBinary == BL.Class1.outputBinary)
                {
                    successmessage successmessage = new successmessage();
                    successmessage.Show();
                    if (anableAuodio)
                    {
                        mediaPlayer = new MediaPlayer();
                        mediaPlayer.Open(new Uri(@"3.mp3", UriKind.Relative));
                        mediaPlayer.Play();
                    }
                }
                else
                {
                    failmessage failmessage = new failmessage();
                    failmessage.Show();
                    if (anableAuodio)
                    {
                        mediaPlayer = new MediaPlayer();
                        mediaPlayer.Open(new Uri(@"2.mp3", UriKind.Relative));
                        mediaPlayer.Play();
                    }
                }
            }
            else
            { // ArrayRes
                if (BL.Class1.refOutputBinaryArr.SequenceEqual(BL.Class1.outputBinaryArr))
                {
                    successmessage successmessage = new successmessage();
                    successmessage.Show();
                    if (anableAuodio)
                    {
                        mediaPlayer = new MediaPlayer();
                        mediaPlayer.Open(new Uri(@"3.mp3", UriKind.Relative));
                        mediaPlayer.Play();
                    }

                }
                else
                {
                    failmessage failmessage = new failmessage();
                    failmessage.Show();
                    if (anableAuodio)
                    {
                        mediaPlayer = new MediaPlayer();
                        mediaPlayer.Open(new Uri(@"2.mp3", UriKind.Relative));
                        mediaPlayer.Play();
                    }
                }
            }
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            BL.Class1.Help(rtype);
        }

        private void volume_MouseDown(object sender, MouseButtonEventArgs e)
        {
            anableAuodio = !(anableAuodio);

            

        }
    
 

        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

