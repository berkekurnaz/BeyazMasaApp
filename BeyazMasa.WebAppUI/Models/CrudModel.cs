using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BeyazMasa.WebAppUI.Models
{
    public class CrudModel
    {
        public DataTable GetAllBasvurularByBelediye(int id)
        {
            DataTable dt = new DataTable();
            string strConString = @"Data Source=DESKTOP-DF3RRQ5;Initial Catalog=DbBeyazMasa;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(strConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select (Basvurulars.Id),Baslik,Icerik,Dosya,Tarih,Durum,(Vatandaslars.VatandasIsim),(Vatandaslars.VatandasSoyad),(Birimlers.BirimAd),(Belediyelers.BelediyeAd) From Basvurulars INNER JOIN Vatandaslars ON Basvurulars.VatandasId = Vatandaslars.Id INNER JOIN Birimlers On Basvurulars.BirimId = Birimlers.Id INNER JOIN Belediyelers On Basvurulars.BelediyeId = Belediyelers.Id Where (Basvurulars.BelediyeId) = " + id + " ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
    }
}