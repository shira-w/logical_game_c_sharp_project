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


namespace project2020
{
    /// <summary>
    /// Interaction logic for Illustration.xaml
    /// </summary>
    public partial class Illustration : Window
    {
        const int type = 2;
        public Illustration()
        {
            InitializeComponent();
        }

        string rtype;
        int rsize;
        public binaributton[] binaributtons;
        public Image[] carray = new Image[6];

        // פונקציה להוספת משווה גודל
     
            public void illuaddmg(int size, int hc, int c1a, int c1b, int c1c, int c1d, int c2a, int c2b, int c2c, int c2d)
            {

                binaributton[] binaributtons1 = new binaributton[size];
                binaributton[] binaributtons2 = new binaributton[size];
                Image[] carray = new Image[3];
                int ca = 309, cc = 444;

                for (int i = 0; i < size; i++)
                {
                    binaributtons1[i] = new binaributton(c1a, c1b, c1c, c1d, 0, 0);
                    c1a += hc; c1c -= hc;
                    grid11.Children.Add(binaributtons1[i]);

                }

                for (int i = 0; i < size; i++)
                {
                    binaributtons2[i] = new binaributton(c2a, c2b, c2c, c2d, 0, 0);
                    c2a += hc; c2c -= hc;
                    grid11.Children.Add(binaributtons2[i]);

                }


                for (int i = 0; i < 3; i++)
                {
                    carray[i] = new Image();
                    carray[i].Margin = new Thickness(ca, 235, cc, 120);
                    ca += 52; cc -= 52;
                    //בפתרון נוסיף את המערך שכבר נוצר!!!
                    //grid11.Children.Add(carray[i]);

                }


                grid2.Height = 178;
                grid2.Width = 198;
                grid2.Margin = new Thickness(284, 80, 0, 0);
                ImageBrush myBrush = new ImageBrush();
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"../../IMG1/משווה גודל.png", UriKind.Relative));
                myBrush.ImageSource = image.Source;
                grid2.Background = myBrush;


            }

       



            //חצי מחבר
            public void illuaddhzmechaber(int numof)
        {
            rsize = numof;

            if (numof == 2)
            {
                rtype = "hmechaber";

                // מערך הכניסות
                binaributton[] binaributtons = new binaributton[2];
                for (int i = 1; i >= 0; i--)
                {
                    binaributtons[i] = new binaributton(i, type);

                    grid11.Children.Add(binaributtons[i]);
                }
                binaributtons[1].Margin = new Thickness(352, 56, 407, 341);
                binaributtons[0].Margin = new Thickness(413, 56, 346, 341);
                grid2.Height = 178;
                grid2.Width = 198;
                grid2.Margin = new Thickness(284, 80, 0, 0);
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
                

                //CIN מערך הכניסות-במקרה שהמחבר מלא תהיינה 3 כניסות שאחת מהן היא -האיבר האחרון במערך
                binaributton[] binaributtons = new binaributton[3];
                for (int i = 0; i < 3; i++)
                {
                    binaributtons[i] = new binaributton(i, type);

                    grid11.Children.Add(binaributtons[i]);
                }

                binaributtons[0].Margin = new Thickness(340, 59, 419, 341);
                binaributtons[1].Margin = new Thickness(392, 59, 367, 341);
                binaributtons[2].Margin = new Thickness(457, 59, 302, 341);
                grid2.Height = 178;
                grid2.Width = 198;
                grid2.Margin = new Thickness(284, 80, 0, 0);
                ImageBrush myBrush = new ImageBrush();
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(@"../../IMG1/מחבר מלאא.png", UriKind.Relative));
                myBrush.ImageSource = image.Source;
                grid2.Background = myBrush;

            }



        }




        //מפענח
        public void illuaddmefaaneh(int size, int ca, int cb, int cc, int cd, int hc, int gridh, int gridw, int grida, int gridb, int gridc, int gridd)
        {
            rtype = "mefaaneah";
            rsize = size;
            binaributton[] binaributtons = new binaributton[size];            

            for (int i = 0; i < size; i++)
            {
                binaributtons[i] = new binaributton(ca, cb, cc, cd, i, type);
                cb += hc; cd -= hc;
                grid11.Children.Add(binaributtons[i]);
            }

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
        public void illuaddmerabev(int size, int ca, int cb, int cc, int cd, int cma, int cmb, int cmc, int cmd, int hc, int hcm, int gridh, int gridw, int grida, int gridb, int gridc, int gridd)
        {
            rtype = "merabev";
            rsize = size;


            binaributton[] binaributtonsc = new binaributton[size];
            binaributton[] binaributtonscm = new binaributton[(int)Math.Pow(2, size)];
            // input data
            for (int i = 0; i < (int)Math.Pow(2, size); i++)
            {
                binaributtonscm[i] = new binaributton(cma, cmb, cmc, cmd, i, type);

                cmb += hcm; cmd -= hcm;

                grid11.Children.Add(binaributtonscm[i]);
            }
            // input select
            for (int i = size - 1; i >= 0; i--)
            {
                binaributtonsc[i] = new binaributton(ca, cb, cc, cd, i, type + 1);

                ca += hc; cc -= hc;

                grid11.Children.Add(binaributtonsc[i]);
            }

            grid2.Height = gridh;
            grid2.Width = gridw;
            grid2.Margin = new Thickness(grida, gridb, gridc, gridd);
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(@"../../IMG1/מרבב " + size + ".png", UriKind.Relative));
            myBrush.ImageSource = image.Source;

            grid2.Background = myBrush;
            // set default output
            //BL.Class1.outputBinary = 0;

        }




        // הגרלת מספר בינארי והצגת תמונה מתאימה
        public void random(Image[] carray, int i, int inputNum = 0)
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
                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c0.png", UriKind.Relative));
            else
                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c1.png", UriKind.Relative));
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            BL.Class1.ResetIo();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void help_Click(object sender, RoutedEventArgs e)
        {
            BL.Class1.Help(rtype);
        }

        private void show_Result(object sender, RoutedEventArgs e)
        {
            BL.Class1.ResetArray(BL.Class1.outputBinaryArr, BL.Class1.MaxEntries);
            switch (rtype)
            {
                case "mg":
                    {
                        // set expected result
                        BL.Class1.outputBinaryArr = BL.Class1.MagnitudeComparator(BL.Class1.rndInputBinaryArr,
                                                                                    BL.Class1.rndInput2BinaryArr,
                                                                                    BL.Class1.outputBinaryArr);
                        // show result
                        int ca = 309, cc = 444;
                        for (int i = 2; i >= 0; i--)
                        {
                            carray[i] = new Image();
                            carray[i].Margin = new Thickness(ca, 235, cc, 120);
                            ca += 52; cc -= 52;
                            if (BL.Class1.outputBinaryArr[i] == 0)
                            {
                                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c0.png", UriKind.Relative));
                            }
                            else
                            {
                                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c1.png", UriKind.Relative));
                            }
                            grid11.Children.Add(carray[i]);

                        }
                        break;
                    }
                case "hmechaber":
                case "mechaber":
                    {
                        // set expected result
                        BL.Class1.outputBinaryArr = BL.Class1.Adder(BL.Class1.rndInputBinaryArr, BL.Class1.outputBinaryArr, rsize);

                        // show result
                        //C-שארית Z-תוצאה
                        Image z = new Image();
                        z.Margin = new Thickness(381, 235, 372, 120);

                        if (BL.Class1.outputBinaryArr[0] == 0)
                        {
                            z.Source = new BitmapImage(new Uri(@"..\IMG1\c0.png", UriKind.Relative));
                        }
                        else
                        {
                            z.Source = new BitmapImage(new Uri(@"..\IMG1\c1.png", UriKind.Relative));
                        }
                        grid11.Children.Add(z);

                        Image c = new Image();
                        c.Margin = new Thickness(272, 235, 481, 120);
                        if (BL.Class1.outputBinaryArr[1] == 0)
                        {
                            c.Source = new BitmapImage(new Uri(@"..\IMG1\c0.png", UriKind.Relative));
                        }
                        else
                        {
                            c.Source = new BitmapImage(new Uri(@"..\IMG1\c1.png", UriKind.Relative));
                        }
                        if (rsize == 3)
                        {
                            c.Margin = new Thickness(272, 227, 484, 130);
                            z.Margin = new Thickness(365, 235, 391, 122);
                        }

                        grid11.Children.Add(c);
                        break;
                    }

                case "merabev":
                    {
                        // set expected result
                        BL.Class1.outputBinary = BL.Class1.Multiplexer(BL.Class1.rndInput2BinaryArr, BL.Class1.rndInputBinaryArr);

                        // show result
                        Image y = new Image();
                        int ya = 0, yb = 0, yc = 0, yd = 0;
                        switch (rsize)
                        {
                            case 2:
                                ya = 480; yb = 120; yc = 270; yd = 265;
                                break;
                            case 3:
                                ya = 478; yb = 125; yc = 267; yd = 259;
                                break;
                            case 4:
                                ya = 480; yb = 97; yc = 271; yd = 233;
                                break;
                        }
                        y.Margin = new Thickness(ya, yb, yc, yd);

                        if (BL.Class1.outputBinary == 0)
                        {
                            y.Source = new BitmapImage(new Uri(@"..\IMG1\c0.png", UriKind.Relative));
                        }
                        else
                        {
                            y.Source = new BitmapImage(new Uri(@"..\IMG1\c1.png", UriKind.Relative));
                        }

                        grid11.Children.Add(y);
                        break;

                    }

                case "mefaaneah":
                    {
                        // set expected result

                        BL.Class1.outputBinaryArr = BL.Class1.Decoder(BL.Class1.rndInputBinaryArr, BL.Class1.refOutputBinaryArr);
                        // show result
                        int ya, yb, yc, yd, hy;
                        ya = 483; yb = 45; yc = 269; yd = 285; hy = 44;
                        
                        if (rsize == 3)
                        {
                            ya = 484; yb = 31; yc = 275; yd = 307; hy = 24;
                        }
                        if (rsize == 4)
                        {
                            ya = 487; yb = 33; yc = 284; yd = 334; hy = 13;
                        }
                        Image[] carray = new Image[(int)Math.Pow(2, rsize)];
                        for (int i = 0; i < (int)Math.Pow(2, rsize); i++)
                        {
                            carray[i] = new Image();
                            carray[i].Margin = new Thickness(ya, yb, yc, yd);
                            yb += hy; yd -= hy;
                            if (BL.Class1.outputBinaryArr[i] == 0)
                            {
                                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c0.png", UriKind.Relative));
                            }
                            else
                            {
                                carray[i].Source = new BitmapImage(new Uri(@"..\IMG1\c1.png", UriKind.Relative));
                            }
                            grid11.Children.Add(carray[i]);
                        }
                        break;
                    }

            }
        }

       


        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();

        }

        private void volume_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
