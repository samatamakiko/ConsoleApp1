using System;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            StreamReader sr = new StreamReader(@"C:\Users\makik\Downloads\test.csv", Encoding.GetEncoding("Shift-JIS"));
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] values = line.Split(',');
                List<string> lists = new List<string>();
                lists.AddRange(values);
                foreach(string value in lists)
                {
                    Console.Write("{0}",value);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
        public class Data
        {
            public string 受注コード　{ get; set; }
            public string 購入者名1 { get; set; }
            public string 購入者名2 { get; set; }
        }
    }
}



/* var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
            };
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var reader = new StreamReader(@"C:\Users\makik\Downloads\test.csv", Encoding.GetEncoding("Shift-JIS")))
            using (var csv = new CsvReader(reader, config))
            {
                var data = new List<Data>();
                var lines = File.ReadAllLines(reader);
                Console.WriteLine(data);
                //ヘッダー取得
                csv.Read();
                csv.ReadHeader();
                Console.WriteLine(string.Join(",", csv.HeaderRecord!));
                // 内容取得
                foreach (var record in csv.GetRecords<Data>())
                {
                    Console.WriteLine($"{record.受注コード},{record.購入者名1},{record.購入者名2}");
                }
            }*/