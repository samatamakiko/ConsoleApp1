using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static test.Test;
using System.Reflection.PortableExecutable;

namespace test
{
    public class Test
    {
        static void Main(string[] args)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(@"C:\Users\makik\Downloads\test (1).csv", Encoding.GetEncoding("Shift-JIS")))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();
                //ヘッダー名出力
                Console.WriteLine(string.Join(",", csv.HeaderRecord!));
            
                foreach (var record in csv.GetRecords<Csv1>())
                {
                    Console.WriteLine($"{record.社員番号},{record.部署番号},{record.名前}");
                }
            }

            var config2 = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader2 = new StreamReader(@"C:\Users\makik\Downloads\testcsv.csv", Encoding.GetEncoding("Shift-JIS")))
            using (var csv2 = new CsvReader(reader2, config2))
            {
                csv2.Read();
                csv2.ReadHeader();
                //ヘッダー名出力
                Console.WriteLine(string.Join(",", csv2.HeaderRecord!));

                foreach (var record2 in csv2.GetRecords<Csv2>())
                {
                    Console.WriteLine($"{record2.部署番号},{record2.部署名}");
                }
            }
        }

        public class Csv1
        {
            public int 社員番号 { get; set; }
            public int 部署番号 { get; set; }
            public string 名前 { get; set; }
        }

        public class Csv2
        {
            public int 部署番号 { get; set; }
            public string 部署名 { get; set; }
        }

    }

}
