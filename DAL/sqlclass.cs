using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Drawing;
using System.Xml;
using System.Xml.Linq;

namespace DAL
{
    public class sqlclass
    {

        public static DataTable table;


        public static SqlConnection con = new SqlConnection(@"Server=LAPTOP-0SA5RLTP
;Initial Catalog = efratDB;Trusted_Connection=True;");

        public static void SaveGame1(string nname, string ntype, int nsize, int[] narray)
        {
            string ename = nname;
            string etype = ntype;
            string date = DateTime.Today.Month.ToString() + "/" + DateTime.Today.Day.ToString() + "/" + DateTime.Today.Year.ToString();
            /*
            string dquery = "SET ANSI_WARNINGS OFF";
            SqlCommand cmd1 = new SqlCommand(dquery, con);
            string query = string.Format("exec SaveGame1 '{0}','{1}','{2}'", ename, date, etype);
            SqlCommand cmd = new SqlCommand(query, con);*/
            //string insertToTable
            /*
            XDocument doc = new XDocument();
            doc.Add(new XElement("root", narray.Select(x => new XElement("item", x))));*/
            //XDocument xmlFile = 
            new XDocument(
               new XElement("root",narray.Select(x => new XElement("item", x))
                        )
                                                   )
            .Save("foo.xml");
            //string convertedXml= "SELECT CONVERT(XML, BulkColumn) AS carray FROM OPENROWSET(BULK 'foo.xml')";
            string myXml = XDocument.Load("foo.xml").ToString();

            string insertDetials = string.Format("INSERT INTO GameTable (name, date, type, carray) VALUES ('{0}','{1}', '{2}', '{3}');", ename,date,etype,
               myXml);
            SqlCommand cmd1 = new SqlCommand(insertDetials, con);
            //SqlCommand cmd2 = new SqlCommand("INSERT into GameTable (name, date, type) VALUES ({0}, {1}, {2}");
            //Console.WriteLine("array" + narray[0]);
           con.Open();
            cmd1.ExecuteNonQuery();
            //cmd.ExecuteNonQuery();
            con.Close();
        }


        //public static XmlElement LoadXML(int[] images)
        //{
        //     public static XmlDocument document = new XmlDocument();
        //    List<XElement> list = new List<XElement>();
        //    string temp;
        //    for (int i = 0; i < images.Length; i++)
        //    {
        //        int r = images[i];
        //       .Add(new XmlElement(r);

        //    }


        //}


        public static XElement rootScore;
        public static XElement rootCard;
        public static XElement rootNewCard;
        public static XDocument myDocScore;
        public static XDocument myDocCard;
        public static XDocument myDocNewCard;

        public static void init()
        {//Environment.CurrentDirectory.Substring(0,Environment.CurrentDirectory.indexOf("bin"))+ XMLFile.xml

            myDocScore = XDocument.Load(@"..\..\XMLsavesGames.xml");
            rootScore = myDocScore.Root;
        }

        //public static XmlElement getClassXml(int[] array, string name)
        //{
        //    //init();
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        int r = array[i];
        //        rootScore.Add(new XElement(@"name", new XAttribute(@"i", r)));
        //        XmlElement x=new XmlElement(new XAttribute(@"i", r));
        //}


        //    myDocScore.Save(@"..\..\XMLsavesGames.xml");
        //    return myDocScore ;
        //}


    }
}
