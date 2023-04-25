// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.Cache;

class Program
{
    static void Main(string[] args)
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand command = new SqlCommand();
        DataTable dt = new DataTable();

        int ID = 0;
        string Name = string.Empty;
        int Age = 0;
        string Prefecture = string.Empty;

        //接続
        conn.ConnectionString = "Data Source = LAPTOP-861DHBEM; Initial Catalog = Test-db; Integrated Security = True ;TrustServerCertificate=true;";
        conn.Open();

        //SELECT文の設定
        command.CommandText = "SELECT * FROM PROFILE_TBL";
        command.Connection = conn;

        //SQL実行
        SqlDataReader reader = command.ExecuteReader();

        //結果表示
        while (reader.Read())
        {
            ID = (int)reader.GetInt32(0);
            Name = (string)reader.GetString(1);
            Age = (int)reader.GetInt32(2);
            Prefecture = (string)reader.GetString(3);

            Console.WriteLine("ID:" + ID + "名前:" + Name + "年齢:" + Age + "出身地:" + Prefecture);
        }
        conn.Close();


    }
}





// ; TrustServerCertificate = true 暗号化を利用した接続
//↓接続文字列
//Data Source = LAPTOP - 861DHBEM; Initial Catalog = Test - db; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate=False; Application Intent = ReadWrite; Multi Subnet Failover=False