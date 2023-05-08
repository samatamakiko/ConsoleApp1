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
using System;
using System.Collections.ObjectModel;
using System.Collections;

namespace test
{
    public class Test
    {
        
        static void Main(string[] args)
        {
            //リスト定義（定義だけで）
            var aaa = new List<Csv1>();
            var bbb = new List<Csv2>();
            //１つ目CSV出力
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
                //Console.WriteLine(string.Join(",", csv.HeaderRecord!));

                foreach (var record in csv.GetRecords<Csv1>())
                {
                    aaa.Add(record);
                    //Console.WriteLine($"{record.社員番号},{record.部署番号},{record.名前}");
                }
               
            }

            //２つ目CSV出力
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
                //Console.WriteLine(string.Join(",", csv2.HeaderRecord!));

                foreach (var record2 in csv2.GetRecords<Csv2>())
                {
                    bbb.Add(record2);
                    //Console.WriteLine($"{record2.部署番号},{record2.部署名}");
                }
            }


            var query = from p in aaa
                        join q in bbb
                        on p.部署番号 equals q.部署番号
                        select new { 社員番号 = p.社員番号, jobID = p.部署番号, name = p.名前, joobname = q.部署名 };

            // クエリの実行と出力
            foreach (var s in query)
            {
                Console.WriteLine($"{s.社員番号},{s.jobID},{s.name},{s.joobname},");
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


//複数のフォーマットがある時、CSVは一つに保存できないので、複数ある時は各CSVに保存する

