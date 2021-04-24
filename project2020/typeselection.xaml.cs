using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for typeselection.xaml
    /// </summary>
    public partial class typeselection : Window
    {
      public int part = 0; //תרגול או הדגמה
      public  string type;
      public int size=0;
        private MediaPlayer mediaPlayer;
        public typeselection()
        {
            InitializeComponent();
        }

        private void mfan_click(object sender, RoutedEventArgs e)
        {
           
            type = "mefaaneah";
            selectsizeopen();
        }

        private void mkdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            type = "mkdd";
            selectsizeopen();
        }

        private void mrbv_click(object sender, RoutedEventArgs e)
        {
            type = "merabev";
            selectsizeopen();
        }

        private void mg_click(object sender, RoutedEventArgs e)
        {
            type = "mg";
            selectsizeopen();
        }

        private void hemchaber_click(object sender, RoutedEventArgs e)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"223445__six-ways__mouse-click.wav", UriKind.Relative));
            mediaPlayer.Play();
            type = "hmechaber";
        }
        private void mechaber_click(object sender, RoutedEventArgs e)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"223445__six-ways__mouse-click.wav", UriKind.Relative));
            mediaPlayer.Play();
            type = "mechaber";
        }

        private void tw_click(object sender, RoutedEventArgs e)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"223445__six-ways__mouse-click.wav", UriKind.Relative));
            mediaPlayer.Play();
            size = 2;
        }
        private void th_click(object sender, RoutedEventArgs e)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"223445__six-ways__mouse-click.wav", UriKind.Relative));
            mediaPlayer.Play();
            size = 3;
        }
        private void f_click(object sender, RoutedEventArgs e)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"223445__six-ways__mouse-click.wav", UriKind.Relative));
            mediaPlayer.Play();
            size = 4;
        }

        // הצגת כפתורים לבחירת גודל
        private void selectsizeopen()
        {
            this.mechaber.Visibility=Visibility.Hidden;
            this.mg.Visibility = Visibility.Hidden;
            this.hmechaber.Visibility = Visibility.Hidden;
            this.mefaaneah.Visibility = Visibility.Hidden;
            this.merabev.Visibility = Visibility.Hidden;
            this.mkdd.Visibility = Visibility.Hidden;

            if (this.type=="merabev")
                this.merabev2.Visibility = Visibility.Visible;
            if (this.type == "mefaaneah")
                this.mefaaneah2.Visibility = Visibility.Visible;
            if (this.type == "mkdd")
                this.mkdd2.Visibility = Visibility.Visible;

            tw.Visibility = Visibility.Visible;
            th.Visibility = Visibility.Visible;
            f.Visibility = Visibility.Visible;

        }

        private void ok_click(object sender, RoutedEventArgs e)
        {
            BL.Class1.ResetIo();
            if (part == 1)//תרגול
            {
                switch (type)
                {
                    case "mg":
                        {
                            if (size == 0)
                                MessageBox.Show("אנא בחר מספר כניסות לרכיב");

                            //   (int size, int hc, int c1a, int c1b, int c1c, int c1d, int c2a, int c2b, int c2c, int c2d)

                            if (size == 2)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmg(2, 20, 331, 35, 430, 315, 392, 35, 369, 315);
                                this.Close();
                            }

                            if (size == 3)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmg(3, 18, 326, 37, 437, 314, 387, 37, 376, 314);
                                this.Close();
                            }


                            if (size == 4)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmg(4, 12, 324, 39, 441, 313, 387, 39, 378, 313);
                                this.Close();
                            }


                            break;
                        }
                    case "hmechaber":
                        {
                            newpractice newpractice = new newpractice();
                            newpractice.Show();
                            newpractice.addhzmechaber(2);
                            this.Close();
                            break;
                        }
                    case "mechaber":
                        {
                            newpractice newpractice = new newpractice();
                            newpractice.Show();
                            newpractice.addhzmechaber(3);
                            this.Close();
                            break;
                        }

                    case "merabev":
                        {
                            if (size == 0)
                                MessageBox.Show("אנא בחר מספר כניסות לרכיב");



                            if (size == 2)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmerabev(2, 378, 222, 372, 108, 250, 45, 500, 287, 44, 32, 198, 197, 283, 56, 0, 0, 480, 98, 283, 243);
                                this.Close();
                            }

                            if (size == 3)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmerabev(3, 391, 246, 362, 126, 262, 64, 505, 326, 34, 20, 198, 197, 283, 62, 0, 0, 480, 110, 283, 231);
                                this.Close();
                            }


                            if (size == 4)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmerabev(4, 415, 254, 350, 128, 268, 48, 506, 341, 29, 11, 212, 210, 283, 54, 0, 0, 493, 107, 270, 234);
                                this.Close();
                            }


                            break;

                        }

                    case "mefaaneah":
                        {

                            if (size == 0)
                                MessageBox.Show("אנא בחר מספר כניסות לרכיב");
                            if (size == 2)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmefaaneh(2, 245, 83, 505, 249, 493, 62, 270, 279, 68, 40, 197, 213, 280, 66, 0, 0);
                                this.Close();
                            }


                            if (size == 3)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmefaaneh(3, 210, 87, 515, 293, 494, 46, 277, 314, 59, 25, 226, 235, 258, 53, 0, 0);
                                this.Close();
                            }


                            if (size == 4)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmefaaneh(4, 209, 68, 523, 312, 505, 40, 276, 342, 50, 14, 238, 250, 255, 47, 0, 0);
                                this.Close();

                            }

                            break;
                        }
                    case "mkdd":
                        {

                            if (size == 0)
                                MessageBox.Show("אנא בחר מספר כניסות לרכיב");
                            if (size == 2)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();// int size, int ca, int cb, int cc, int cd, int ya, int yb, int yc, int yd, int hc, int hy, int gridh, int gridw, int grida, int gridb, int gridc, int gridd
                                newpractice.addmkdd(2, 235, 59, 515, 273, 494, 92, 269, 248, 44, 71, 212, 222, 271, 64, 0, 0);
                                this.Close();
                            }


                            if (size == 3)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmkdd(3, 245, 51, 516, 302, 493, 73, 270, 267, 24, 54, 212, 222, 271, 64, 0, 0);
                                this.Close();
                            }


                            if (size == 4)
                            {
                                newpractice newpractice = new newpractice();
                                newpractice.Show();
                                newpractice.addmkdd(4, 255, 48, 519, 328, 494, 59, 269, 280, 13, 46, 212, 222, 271, 64, 0, 0);
                                this.Close();

                            }

                            break;
                        }

                }

            }



            else//הדגמה
            {
                switch (type)
                {
                    case "mkdd":
                        {


                            if (size == 0)
                                MessageBox.Show("אנא בחר מספר כניסות לרכיב");
                            if (size == 2)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmkdd(2, 240, 67, 524, 282, 44, 212, 222, 271, 64, 0, 0);
                                this.Close();
                            }

                            //int size, int ca, int cb, int cc, int cd, int hc, int gridh, int gridw, int grida, int gridb, int gridc, int gridd
                            if (size == 3)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmkdd(3, 247, 53, 523, 304, 24, 212, 222, 271, 64, 0, 0);
                                this.Close();
                            }


                            if (size == 4)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmkdd(4, 259, 46, 523, 325, 13, 212, 222, 271, 64, 0, 0);
                                this.Close();

                            }

                            break;
                        }


                    case "mg":
                        {
                            if (size == 0)
                                MessageBox.Show("אנא בחר מספר כניסות לרכיב");

                            //   (int size, int hc, int c1a, int c1b, int c1c, int c1d, int c2a, int c2b, int c2c, int c2d)

                            if (size == 2)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmg(2, 28, 315, 55, 445, 342, 387, 55, 372, 342);
                                this.Close();
                            }

                            if (size == 3)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmg(3, 22, 311, 58, 460, 343, 387, 58, 382, 343);
                                this.Close();
                            }


                            if (size == 4)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmg(4, 18, 306, 62, 467, 343, 384, 62, 388, 343);
                                this.Close();
                            }

                            break;
                        }
                    case "hmechaber":
                        {
                            Illustration illustration = new Illustration();
                            illustration.Show();
                            illustration.illuaddhzmechaber(2);
                            this.Close();
                            break;
                        }
                    case "mechaber":
                        {
                            Illustration illustration = new Illustration();
                            illustration.Show();
                           illustration.illuaddhzmechaber(3);
                            this.Close();
                            break;
                        }

                    case "merabev":
                        {
                            if (size == 0)
                                MessageBox.Show("אנא בחר מספר כניסות לרכיב");



                            if (size == 2)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmerabev(2, 349, 263, 417, 135, 255, 74, 506, 322, 47, 34, 212, 207, 285, 51, 0, 0);
                                this.Close();
                            }
                            
                            if (size == 3)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmerabev(3, 335, 262, 431, 139, 260, 60, 505, 341, 36, 21, 212, 208, 285, 51, 0, 0);
                                this.Close();
                            }


                            if (size == 4)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                               illustration.illuaddmerabev(4, 284, 263, 386, 138, 274, 57 ,508, 354, 28, 11, 212, 207, 285, 51, 0, 0);
                                this.Close();
                            }


                            break;

                        }

                    case "mefaaneah":
                        {


                            if (size == 0)
                                MessageBox.Show("אנא בחר מספר כניסות לרכיב");
                            if (size == 2)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmefaaneh(2, 247, 103, 510, 285, 73, 214, 211, 284, 51, 0, 0);
                                this.Close();
                            }


                            if (size == 3)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmefaaneh(3, 251, 88, 506, 306, 55, 214, 211, 284, 51, 0, 0);
                                this.Close();
                            }


                            if (size == 4)
                            {
                                Illustration illustration = new Illustration();
                                illustration.Show();
                                illustration.illuaddmefaaneh(4, 252, 74, 507, 321, 46, 214, 211, 284, 51, 0, 0);
                                this.Close();

                            }

                            break;
                        }

                }

            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void info_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SystemSounds.Beep.Play();
           


        }
       
      



        private void Window_Loaded()
        {
            mediaElement1.Source = new Uri(@"../IMG1/11.mp3", UriKind.Relative);
           
        }

    }
}
  
