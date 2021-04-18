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
    /// Interaction logic for savepractice.xaml
    /// </summary>
    public partial class savepractice : Window
    {
        public savepractice()
        {
            InitializeComponent();
        }

        string currentType;
        Image[] images;
        int esize;
        int[] narray;
        /*
        public void name(string typename, Image[] array, int size)
        {
            d = typename;
            esize = size;
            PictureToNumberArray(array, size);

        }
        */
        public void updateNarray(int[] randArray)
        {
            narray = randArray;
        }
        public void updateType(string type)
        {
            currentType = type;
        }
        public static int PictureToNumber(Image binImages)
        {
            if (binImages.ToString() == "./wpf-master/project2020/IMG1/00.png")
                return 0;
            if (binImages.ToString() == "./הורדות/wpf-master/project2020/IMG1/11.png")
                return 1;
            return 0;
        }


        public void PictureToNumberArray(Image[] binImages, int size)
        {
          /*  int[] numarray = new int[size];*/
            for (int i = 0; i < size; i++)
            {
                narray[i] = PictureToNumber(binImages[i]);

            }
            //return numarray;
        }

        private void savep_Click(object sender, RoutedEventArgs e)
        {
            string name = tname.Text;
            string etype = currentType;
            Image[] image1 = images;
            PictureToNumberArray(images, esize);
            BL.Class1.save(name,etype, esize,narray);
           
         //   Console.WriteLine("array" + narray[0]);
            //Console.WriteLine("SIZE OF IMAGES %d", image1.Length); 
        }

        private void tname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    }
