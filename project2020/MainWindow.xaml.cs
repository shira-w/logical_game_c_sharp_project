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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project2020
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BL.Class1.RandGenerator();            
        }

        private void newp_Mouseclic(object sender, RoutedEventArgs e)
        {
            
            typeselection typeselection = new typeselection();
            typeselection.Show();
            typeselection.part = 1;
            this.Close();
        }
        
        private void savedp_Mouseclic(object sender, RoutedEventArgs e)
        {
            savedpractice savedpractice = new savedpractice();
            savedpractice.Show();
            this.Close();
        }
        private void hdgm_Mouseclick(object sender, EventArgs e)
        {
            typeselection typeselection = new typeselection();
            typeselection.Show();
            typeselection.part = 2;
            this.Close();
        }

        private void info_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

       

        private void close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
