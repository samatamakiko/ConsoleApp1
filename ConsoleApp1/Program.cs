using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Linq;
using System.Collections.Generic;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(@"C:\Users\makik\Downloads\test.csv", Encoding.GetEncoding("Shift-JIS")))
            using (var csv = new CsvReader(reader, config))
            {
               
                //ヘッダー取得
                csv.Read();
                csv.ReadHeader();
                //ヘッダー名出力
                //Console.WriteLine(string.Join(",", csv.HeaderRecord!));
                csv.GetRecords<Data>().Where(A => A.購入者名1.EndsWith("A")).ToList().ForEach(data => Console.WriteLine(data.購入者名1));
                // 内容取得
               /* foreach (var record in csv.GetRecords<Data>())
                {
                    Console.WriteLine($"{record.受注コード},{record.購入者名1},{record.購入者名2}");
                  
                }*/
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