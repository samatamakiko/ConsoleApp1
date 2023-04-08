using System;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(@"C:\Users\makik\Downloads\test.csv",Encoding.GetEncoding("Shift-JIS")))
            { 
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Data>();

                    // records は IEnumerable なので、こんな使い方ができます。
                    foreach (var i in records)
                    {
                        Console.Write(i);
                    }
                }
            }
        }
        public class Data
        {
            public string companyname { get; set; }
            public string buyer1 { get; set; }
            public string buyer2 { get; set;}
            //;;;;;;;;;;
        }
    }
}


