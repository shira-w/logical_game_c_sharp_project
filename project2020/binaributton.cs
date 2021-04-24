using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Media;

namespace project2020
{
  public  class binaributton:Image
 
    {//לצורך הפונקציה שמחליפה את התמונה
      int flag=0;
      int muflag = 1; /*צליל*/


        public int anableAudio { get; set; } = 0;
        enum LogicalType
        {
            Practice                    = 1,
            IllustrationFirstInput      = 2,
            IllustrationSecondInput     = 3
        }

        private LogicalType TemplatePartAttribute;
        private MediaPlayer mediaPlayer;

        //בנאי שלא מקבל מיקום

        public binaributton():base()
        {
           this.Source= new BitmapImage(new Uri(@"../../IMG1/00.png", UriKind.Relative));
          
            this.MouseDown += binaributton_Mouseclick;
        }

        public int nameToNum(string name)
        {
            return (int)(Int16.Parse(name.Substring(1)));
        }

        // בנאי שמקבל ערכים למיקום הכפתור בגריד
        public binaributton(int a, int b, int c, int d, int num, int part) : base()
        {
            this.Source = new BitmapImage(new Uri(@"../../IMG1/00.png", UriKind.Relative));
            this.Margin = new Thickness(a, b, c, d);
            this.MouseDown += binaributton_Mouseclick;
            string Name = "_" + num.ToString();
            this.Name = Name;
            this.TemplatePartAttribute = (LogicalType)part;
        }
        public binaributton( int num, int part) : base()
        {
            this.Source = new BitmapImage(new Uri(@"../../IMG1/00.png", UriKind.Relative));
            this.MouseDown += binaributton_Mouseclick;
            string Name = "_" + num.ToString();
            this.Name = Name;
            this.TemplatePartAttribute = (LogicalType)part;

        }


        //פונקציה להחלפת התמונה בלחיצה
        void binaributton_Mouseclick(object sender, EventArgs e)
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"1.mp3", UriKind.Relative));
            mediaPlayer.Play();
            //new SoundPlayer(@"../audio/1.wav").Play();
            if (this.flag == 0)
            {
                this.Source = new BitmapImage(new Uri(@"../IMG1/11.png", UriKind.Relative));
                flag = 1;
                if (TemplatePartAttribute == LogicalType.Practice)
                {
                    BL.Class1.outputBinary += (int)(Math.Pow(2, (double)(nameToNum(Name))));
                    BL.Class1.outputBinaryArr[(int)nameToNum(Name)] = 1;
                }
                else
                {
                    if (TemplatePartAttribute == LogicalType.IllustrationFirstInput)
                    {// first input
                        BL.Class1.rndInputBinary += (int)(Math.Pow(2, (double)(nameToNum(Name))));
                        BL.Class1.rndInputBinaryArr[(int)nameToNum(Name)] = 1;
                    }
                    else
                    {// second input
                        BL.Class1.rndInput2Binary += (int)(Math.Pow(2, (double)(nameToNum(Name))));
                        BL.Class1.rndInput2BinaryArr[(int)nameToNum(Name)] = 1;
                    }
                }
            }
            else
            {
                this.Source = new BitmapImage(new Uri(@"../IMG1/00.png", UriKind.Relative));
                flag = 0;
                if (TemplatePartAttribute == LogicalType.Practice)
                {
                    BL.Class1.outputBinary -= (int)(Math.Pow(2, (double)(nameToNum(Name))));
                    BL.Class1.outputBinaryArr[(int)nameToNum(Name)] = 0;
                }
                else
                {
                    if (TemplatePartAttribute == LogicalType.IllustrationFirstInput)
                    {
                        BL.Class1.rndInputBinary -= (int)(Math.Pow(2, (double)(nameToNum(Name))));
                        BL.Class1.rndInputBinaryArr[(int)nameToNum(Name)] = 0;
                    }
                    else
                    {
                        BL.Class1.rndInput2Binary -= (int)(Math.Pow(2, (double)(nameToNum(Name))));
                        BL.Class1.rndInput2BinaryArr[(int)nameToNum(Name)] = 0;
                    }
                }
            }

             //btn_Click();
        }


        // void btn_Click()
        //{
        //    System.Windows.Media.MediaPlayer mplayer = new MediaPlayer();
        //    mplayer.Open(new Uri(@"../IMG1/ding.wav", UriKind.Relative));
        //    mplayer.Play();
            
        // }

    }
}
