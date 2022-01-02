using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace otomasyon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=database2;Integrated Security=True");
            string sqlcommandsec = "Select * from Table_1";
            
            
            SqlCommand cmdsec = new SqlCommand(sqlcommandsec,conn);
            basla:
            Console.WriteLine("Yapmak istediğiniz işlemi seçin. 1)kayıtları görüntüle 2) veri ekleme 3) veri güncelleme 4)veri silme 5) çıkış.");
            int sec=int.Parse(Console.ReadLine());
            switch (sec)
            {
                case 1:
                    conn.Open();
                    SqlDataReader dr = cmdsec.ExecuteReader();
                    while (dr.Read())
                    {
                        Console.WriteLine("\t {0}\t {1}", dr[0], dr[1]);
                    }
                    dr.Close();
                    conn.Close();
                    Console.WriteLine("Başka bir işlem yapmak ister misini?1) evet 2) hayır");
                    int islem = int.Parse(Console.ReadLine());
                    if (islem == 1)
                    {
                        goto basla;
                    }
                    else
                        goto case 5;
                case 2:
                    Console.WriteLine("no:");
                    int no=int.Parse(Console.ReadLine());
                    Console.WriteLine("ad:");
                    string ad = Console.ReadLine();
                    conn.Open();
                    string sqlcommandekle = "insert into Table_1 (no,ad) values (" + no + " , '" + ad + "'); " ;
                    SqlCommand cmdek = new SqlCommand(sqlcommandekle,conn);
                    cmdek.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("işlem tamam.");
                    Console.WriteLine("Başka bir işlem yapmak ister misini?1) evet 2) hayır");
                    int islemekl = int.Parse(Console.ReadLine());
                    if (islemekl == 1)
                    {
                        goto basla;
                    }
                    else
                        goto case 5;
                case 3:
                    conn.Open();
                    SqlDataReader dru = cmdsec.ExecuteReader();
                    while (dru.Read())
                    {
                        Console.WriteLine("\t {0}\t {1}", dru[0], dru[1]);
                    }
                    dru.Close();
                    conn.Close();
                    Console.WriteLine("no:");
                    int no1u = int.Parse(Console.ReadLine());
                    Console.WriteLine("no:");
                    int nou = int.Parse(Console.ReadLine());
                    Console.WriteLine("ad:");
                    string adu = Console.ReadLine();
                    string sqlcommandgcl = "update Table_1 set no=" + nou + ",ad='" + adu + "' where no=" + no1u + ";";
                    conn.Open();
                    SqlCommand gcl = new SqlCommand( sqlcommandgcl,conn);
                    gcl.ExecuteNonQuery();
                    conn.Close( );
                    Console.WriteLine("işlem tmm..");
                    Console.WriteLine("Başka bir işlem yapmak ister misini?1) evet 2) hayır");
                    int islemgncl = int.Parse(Console.ReadLine());
                    if (islemgncl == 1)
                    {
                        goto basla;
                    }
                    else
                        goto case 5;
                case 4:
                    conn.Open();
                    SqlDataReader drs = cmdsec.ExecuteReader();
                    while (drs.Read())
                    {
                        Console.WriteLine("\t {0}\t {1}", drs[0], drs[1]);
                    }
                    drs.Close();
                    conn.Close ();
                    Console.WriteLine("no:");
                    int nosil = int.Parse(Console.ReadLine());
                    Console.WriteLine("ad:");
                    string adsil = Console.ReadLine();
                    string sqlcommandsil = "delete from Table_1 where no="+nosil+";";
                    conn.Open();
                    SqlCommand cmil = new SqlCommand(sqlcommandsil,conn);
                    cmil.ExecuteNonQuery();
                    conn.Close();
                    Console.WriteLine("işlem başarılı..");
                    Console.WriteLine("Başka bir işlem yapmak ister misini?1) evet 2) hayır");
                    int islemsil = int.Parse(Console.ReadLine());
                    if (islemsil == 1)
                    {
                        goto basla;
                    }
                    else
                    goto case 5;
                case 5:
                    Console.WriteLine("İyi günler dileriz...");
                    break;
            }
            Console.ReadLine();
        }
    }
}
