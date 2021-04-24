using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace BL
{
    public class Class1
    {
        public const int MaxEntries = 31;
        public const int MaxExits = MaxEntries;
        public static Random rnd;
        // inputs
        public static int rndInputBinary; // input as no.
        public static int[] rndInputBinaryArr = new int[MaxEntries]; // binary input in array per bit
        public static int rndInput2Binary; // second input as no.
        public static int[] rndInput2BinaryArr = new int[MaxEntries]; // second binary input in array per bit
        // outputs
        public static int outputBinary; // user binary output as no.
        public static int[] outputBinaryArr = new int[MaxExits]; // user binary outputs as no. in array
        public static int refOutputBinary; // reference binary output as no.
        public static int[] refOutputBinaryArr = new int[MaxExits]; // reference binary output in array per bit

        //public static int[] OutpoutBinaryArr { get; set; }
        /*

        public static void sendBinArray(int[]narray)
        {
            //DAL.sqlclass.
        }*/
        public static void ResetArray(int[] array, int length)
        {
            for (int i = 0; i < length; i++)
            {
                outputBinaryArr[i] = 0;
            }
        }
        public static void ResetInputs()
        {
            BL.Class1.rndInputBinary = 0;
            BL.Class1.ResetArray(BL.Class1.rndInputBinaryArr, BL.Class1.MaxEntries);
            BL.Class1.rndInput2Binary = 0;
            BL.Class1.ResetArray(BL.Class1.rndInput2BinaryArr, BL.Class1.MaxEntries);
        }

        public static void ResetOutputs()
        {
            BL.Class1.outputBinary = 0;
            BL.Class1.ResetArray(BL.Class1.outputBinaryArr, BL.Class1.MaxEntries);
            BL.Class1.refOutputBinary = 0;
            BL.Class1.ResetArray(BL.Class1.refOutputBinaryArr, BL.Class1.MaxEntries);
        }

        public static void ResetIo()
        {
            ResetInputs();
            ResetOutputs();
        }
        public static void RandGenerator()
        {
            rnd = new Random(GetSeed());
        }

        public static int GetSeed()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var intBytes = new byte[4];
                rng.GetBytes(intBytes);
                return BitConverter.ToInt32(intBytes, 0);
            }
        }
        //המרה של תמונה למספר
        public int PictureToNumber(Image binImages)
        {
            if (binImages.ToString() == "./wpf-master/project2020/IMG/00.png")
                return 0;
            if (binImages.ToString() == "./הורדות/wpf-master/project2020/IMG/11.png")
                return 1;
            return 0;
        }

        //הפיכת רצף סיביות למספר   
        // this function creates a number from ints:
        public static int BinToDec(int[] ints)
        {
            int binNum = 0;//variable for save the binary digit as number
            for (int i = 0; i < ints.Length; i++)
            {
                binNum += ints[i] * (int)Math.Pow(2, i);
            }
            return binNum;
        }

        //המרת מס' עשרוני לבינארי
        //a converting from decimal to binary function:
        public static int[] DecToBin(int dec, int[] outputBinaryArr, int size)
        {
            int numBits = 0;
            while (dec > 0 && numBits < size)
            {
                outputBinaryArr[numBits++] = dec & 1; //get lsb
                dec >>= 1;
            }
            return outputBinaryArr;
        }
        //חצי מחבר ומחבר מלא
        //This function does the operation of half adder and full adder:
        public static int[] Adder(int[] entrance, int[] outputBinaryArr, int rsize)
        {
            int result = 0;
            for (int i = 0; i < rsize; i++)
            {
                result += entrance[i];
            }
            outputBinaryArr = DecToBin(result, outputBinaryArr, entrance.Length);
            return outputBinaryArr;
        }
        ////מחבר מקבילי
        ////This function does the operation of parallel adder:
        //public static void ParallelAdder(int[] aEntrance, int[] bEntrance, int cIn,
        //    ref int[] sExiting, ref int cOut)//יש לשלוח את cOut מאופס למקרה שאין נשא
        //{
        //    //This variable exits the sum of a and b entrance:
        //    double s = (int)BinToDec(aEntrance) | (int)BinToDec(bEntrance) | cIn;
        //    //Later we have to make n exit of one bit:
        //    for (int i = 0; i < sExiting.Length; i++)
        //    {
        //        sExiting[i] = (int)(s % 10);
        //        s /= 10;
        //    }
        //    //if we have carry it exits in c exit:
        //    if (s != 0)
        //        cOut = (int)s;
        //}


        //משווה גודל
        //This function does the operation of magnitude comparator:
        public static int[] MagnitudeComparator(int[] aEntrance, int[] bEntrance, int[] output)
        {
            int a, b;//This variables represent the bits from the entrance as binary numbers
            a = BinToDec(aEntrance);
            b = BinToDec(bEntrance);
            int resIdx = 1; //equal
            if (a > b)
            {
                resIdx = 0;
            }
            else if (a < b)
            {
                resIdx = 2;
            }
            output[resIdx] = 1;
            return output;
        }

        //מפענח
        //This function does the operation of decoder:
        public static int[] Decoder(int[] entrance, int[] output)
        {
            output[(int)(BinToDec(entrance))] = 1;
            return output;
        }
        //מקודד
        //This function does the operation of enecoder:
        public static int[] Encoder(int[] entrance, int[] output)
        {
            int decNum = 0;
            for (int i = 0; i < entrance.Length; i++)
            {
                if (entrance[i] == 1)
                {
                    decNum = i;
                    break;
                }
            }
            return DecToBin(decNum, output, (int)Math.Log(decNum, 2));
        }

        //מרבב
        //This function does the operation of multiplexer:
        public static int Multiplexer(int[] select, int[] info)
        {
            int s = (int)BinToDec(select);
            return info[s];
        }


        //הסבר אודות פעולת הרכיב
        public static void Help(string type)
        {
            switch (type)
            {
                case "mg":
                    {
                        MessageBox.Show("משווה גודל משווה בין שני מספרים בינאריים. אם הם שווים נוציא ביציאה האמצעית 1, ואם לא- נוציא 1 ביציאה המקבילה לכניסה שבה המספר הגדול יותר. בהצלחה");
                        break;
                    }
                case "hmechaber":
                    {
                        MessageBox.Show(".חצי מחבר מבצע פעולת חיבור בין 2 מספרים בינאריים ומוציא את תוצאת החיבור ב-2 יציאות: הספרה הימנית ביציאה הראשית והשמאלית- אם יש- ביציאת הנשא ");
                        break;
                    }
                case "mechaber":
                    {
                        MessageBox.Show("מחבר מבצע פעולת חיבור בין 3 מספרים בינאריים: 2 כניסות+ הנשא מפעולת החיבור הקודם- אם יש, ומוציא את תוצאת החיבור ב-2 יציאות: הספרה הימנית ביציאה הראשית והשמאלית- אם יש- ביציאת הנשא");
                        break;
                    }

                case "merabev":
                    {
                        MessageBox.Show("למרבב שני סוגי כניסות: כניסות ברירה וכניסות מידע. מספר כניסות המידע הוא: מספר כניסות הברירה ^ 2. הספרות בכניסות הברירה מייצגות יחד מספר בינארי המסמל את המספר הסידורי של כניסת המידע שנבחרה (המספור מתחיל מ-0) המידע שבכניסה שנבחרה הוא זה שיצא ביציאה. בהצלחה רבה");
                        break;
                    }
                case "mefaaneah":
                    {
                        MessageBox.Show("מפענח מקבל מספר בינארי ומוציא 1 ביציאה שמספרה הסידורי הוא המספר שנכנס (המספור מתחיל מ-0). בהצלחה רבה");
                        break;
                    }
            }
        }





        public static void save(string name, string type, int size, int[] array)
        {
            string bname = name;
            string btype = type;
            int bsize = size;
            
            // PictureToNumberArray(size );
            DAL.sqlclass.SaveGame1(bname, btype,bsize,array);

        }

    }
}