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
                    
                    foreach (var i in records)
                    {
                       Console.WriteLine($"{i.受注コード},{i.購入者名1},{i.購入者名2}");
                       //Console.WriteLine($"{i.ColumnName}");
                    }
                }
            }
        }
        public class Data
        {
            public string 受注コード { get; set; }
            public string 購入者名1 { get; set; }

            public string 購入者名2 { get; set; }

        }
    }
}


