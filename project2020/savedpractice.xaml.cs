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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DataGridCell = System.Windows.Controls.DataGridCell;
using System.Xml.Linq;

namespace project2020
{
    /// <summary>
    /// Interaction logic for savedpractice.xaml
    /// </summary>
    public partial class savedpractice : Window
    {
        string type;
        XDocument xmlDoc = new XDocument();
        public savedpractice()
        {
            InitializeComponent();
           FillDataGrid();
          //  grdEmployee.MouseDown += new System.Windows.Input.MouseEventHandler(this.myDataGrid_MouseDown);
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        //DataGridView dataGridView1 = new DataGridView();

        private void FillDataGrid()
        {
            string ConString = @"Server=LAPTOP-0SA5RLTP;Initial Catalog = efratDB;Trusted_Connection=True;";
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {               
                
                CmdString = "SELECT id,name,date,type  FROM GameTable";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("GameTable");
               sda.Fill(dt);
                grdEmployee.ItemsSource = dt.DefaultView;      
            }
            
        }
        private void DataGrid_MouseRightButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            var hit = VisualTreeHelper.HitTest((Visual)sender, e.GetPosition((IInputElement)sender));
            DependencyObject cell = VisualTreeHelper.GetParent(hit.VisualHit);
            while (cell != null && !(cell is DataGridCell)) cell = VisualTreeHelper.GetParent(cell);
            DataGridCell targetCell = cell as DataGridCell;
            //var celldata = targetCell.Column.DisplayIndex;
            DataGridRow r2 = DataGridRow.GetRowContainingElement(targetCell);
            if (r2 != null)
            {
                int rowindex = r2.GetIndex() + 10004;
                // At this point targetCell should be the cell that was clicked or null if something went wrong.
                SqlConnection con = new SqlConnection(@"Server=LAPTOP-0SA5RLTP;Initial Catalog = efratDB;Trusted_Connection=True;");
                string query = string.Format("SELECT type, carray From GameTable Where id={0}", rowindex);
                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                // cmd1.ExecuteNonQuery();
                SqlDataReader reader = cmd1.ExecuteReader();
                if (reader.Read())
                {
                    type = (string)reader["type"];
                    xmlDoc = XDocument.Parse((string)reader["carray"]);
                    xmlDoc.Save("foo2.xml");
                }
                con.Close();
            }
            
            string [] pathsList = xmlDoc.Descendants("item").Select(x => x.Value).ToArray();
            int[] arr1 = new int [pathsList.Length];
            int size = 0;
            int [] arr2 = new int[pathsList.Length];
            int i;
            for (i=0; i< pathsList.Length; i++)
            {
                if (pathsList[i]=="-2")
                {
                    break;
                }
                arr1[i] =Int32.Parse( pathsList[i]);
                size++;
            }
            int t = 0;
            for (int k=i+1; k < pathsList.Length; k++)
            {
                arr2[t] = Int32.Parse(pathsList[k]);
                t++;
            }
            switch (type)
            {
                case "merabev":
                    {
                        newpractice newpractice = new newpractice();
                        newpractice.Show();

                        if (size == 2)
                        {
                            newpractice.merabevAfterSave(2, 378, 222, 372, 108, 250, 45, 500, 287, 44, 32, 198, 197, 283, 56, 0, 0, 480, 98, 283, 243 ,arr1,arr2);
                        }
                        else if (size == 3)
                        {
                            newpractice.merabevAfterSave(3, 391, 246, 362, 126, 262, 64, 505, 326, 34, 20, 198, 197, 283, 62, 0, 0, 480, 110, 283, 231, arr1,arr2);
                        }
                        else if (size == 4)
                        {
                            newpractice.merabevAfterSave(4, 415, 254, 350, 128, 268, 48, 506, 341, 29, 11, 212, 210, 283, 54, 0, 0, 493, 107, 270, 234, arr1,arr2);
                        }
                        this.Close(); 
                        //newpractice.merabevAfterSave(xmlDoc);
                        break;
                    }
                case "mefaaneah":
                    {
                        newpractice newpractice = new newpractice();
                        newpractice.Show();
                        if (size == 2)
                        {
                            newpractice.mefaanehAfterSave(2, 245, 83, 505, 249, 493, 62, 270, 279, 68, 40, 197, 213, 280, 66, 0, 0,arr1);
                        }
                        else if (size == 3)
                        {
                            newpractice.mefaanehAfterSave(3, 210, 87, 515, 293, 494, 46, 277, 314, 59, 25, 226, 235, 258, 53, 0, 0, arr1);
                        }
                        else if (size == 4)
                        {      
                            newpractice.mefaanehAfterSave(4, 209, 68, 523, 312, 505, 40, 276, 342, 50, 14, 238, 250, 255, 47, 0, 0, arr1);
                        }
                        this.Close();
                        break;
                    }
                case "mg":
                    {
                        newpractice newpractice = new newpractice();
                        newpractice.Show();
                        if (size == 2)
                        {
                            newpractice.mgAfterSave(2, 20, 331, 35, 430, 315, 392, 35, 369, 315,arr1,arr2);
                        }
                        if (size == 3)
                        {
                            newpractice.mgAfterSave(3, 18, 326, 37, 437, 314, 387, 37, 376, 314, arr1, arr2);
                        }
                        if (size == 4)
                        {
                            newpractice.mgAfterSave(4, 12, 324, 39, 441, 313, 387, 39, 378, 313, arr1, arr2);
                        }
                        this.Close();
                        break;
                    }
                case "hmechaber":
                    {
                        newpractice newpractice = new newpractice();
                        newpractice.Show();
                        newpractice.hzmechaberafterSave(2,arr1);
                        this.Close();
                        break;
                    }
                case "mechaber":
                    {
                        newpractice newpractice = new newpractice();
                        newpractice.Show();
                        newpractice.hzmechaberafterSave(3,arr1);
                        this.Close();
                        break;
                    }
            }
        }
        /*
        private void myDataGrid_MouseDown(object sender,System.Windows.Input.MouseEventArgs e)
        {
            System.Windows.Controls.DataGrid myGrid = (System.Windows.Controls.DataGrid)sender;
            System.Windows.Controls.DataGrid.HitTestInfo hti;
           // hti = myGrid.HitTest(e.X, e.Y);
            string message = "You clicked ";

            switch (hti.Type)
            {
                case System.Windows.Forms.DataGrid.HitTestType.None:
                    message += "the background.";
                    break;
                case System.Windows.Forms.DataGrid.HitTestType.Cell:
                    message += "cell at row " + hti.Row + ", col " + hti.Column;
                    break;
                case System.Windows.Forms.DataGrid.HitTestType.ColumnHeader:
                    message += "the column header for column " + hti.Column;
                    break;
                case System.Windows.Forms.DataGrid.HitTestType.RowHeader:
                    message += "the row header for row " + hti.Row;
                    break;
                case System.Windows.Forms.DataGrid.HitTestType.ColumnResize:
                    message += "the column resizer for column " + hti.Column;
                    break;
                case System.Windows.Forms.DataGrid.HitTestType.RowResize:
                    message += "the row resizer for row " + hti.Row;
                    break;
                case System.Windows.Forms.DataGrid.HitTestType.Caption:
                    message += "the caption";
                    break;
                case System.Windows.Forms.DataGrid.HitTestType.ParentRows:
                    message += "the parent row";
                    break;
            }

            Console.WriteLine(message);
        }*/
        /*
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.dataGridView1.Columns["button"].Index)
            {
                string query = string.Format("SELECT type From GameTable Where id={0}+2", e.ColumnIndex);
                SqlConnection con = new SqlConnection(@"Server=LAPTOP-0SA5RLTP;Initial Catalog = efratDB;Trusted_Connection=True;");
                SqlCommand cmd1 = new SqlCommand(query, con);
                 con.Open();
                 cmd1.ExecuteNonQuery();
                using (SqlDataReader reader = cmd1.ExecuteReader())
                {
                    // iterate your results here
                    type=(string) reader["type"];
                }

                con.Close();
            }
            else
            {

            }
        }*/
        private void ok_click(object sender, RoutedEventArgs e)
        {


            /*switch (type)
        {
            case "mg":
                {
                    break;
                }

                case "hmechaber":
                    {
                    break;
                }*/
        }

        private void grdEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
