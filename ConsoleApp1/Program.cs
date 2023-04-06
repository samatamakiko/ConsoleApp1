// See https://aka.ms/new-console-template for more information

using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;
using System.Text;

class Program
{
    public static void Main()
    {
        //ファイル名書く
        string file = (@"C:\Users\makik\Downloads\test.csv");
        // Encoding.GetEncodingがShift-JISサポートされていないため、下記の文を書く
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        //CSVファイルをメモ帳に出力して文字コードを確認する
        StreamReader reader = new StreamReader(file, Encoding.GetEncoding("Shift-JIS"));
        
       
            string[] cols = reader.ReadToEnd().Split(",");
            for (int n = 0; n < cols.Length; n++)
            {
                Console.Write(cols[n] + ",");
            }
           // Console.ReadLine();
      
        reader.Close();
    }
}


