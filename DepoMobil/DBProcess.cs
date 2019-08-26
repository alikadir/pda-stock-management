#region Using directives
using System;
using System.IO;
using System.Data.SqlServerCe;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Windows.Forms;


#endregion

namespace DepoMobil
{
    public class DB
    {
        SqlCeConnection CeConn;
        SqlConnection SqlConn = new SqlConnection();
        Config config;

        public DB(Config c)
        {
            this.config = c;

            SqlConn.ConnectionString = config.ConnectionString;

            if (!IsDbExist())
            {
                CreateDB();
                CeConn = new SqlCeConnection("DataSource=ankara.sdf");

                CreateTables();

            }
            else
            {
                File.Delete("ankara.sdf");
                CreateDB();
                CeConn = new SqlCeConnection("DataSource=ankara.sdf");

                CreateTables();
            }
        }

        bool IsDbExist()
        {
            return File.Exists("ankara.sdf");
        }

        public static void CreateDB()
        {
            SqlCeEngine Engine = new SqlCeEngine("DataSource=ankara.sdf");
            Engine.CreateDatabase();

            Engine.Dispose();
        }

        public DB(Config c, bool isnull)
        {
            config = c;
            CeConn = new SqlCeConnection("DataSource=ankara.sdf");
            SqlConn.ConnectionString = config.ConnectionString;
        }

        public Int64 SiparisNoHesapla()
        {
            string Sip1 = config.PDAKodu;

            string yil = Convert.ToString(DateTime.Now.Year);
            string Gun = Convert.ToString(DateTime.Now.Day);
            string Ay = Convert.ToString(DateTime.Now.Month);

            Int64 Basla = Convert.ToInt64("3" + Ay + Sip1 + Gun + "000");

            return Basla;
        }


        #region Tablolarý yaratýr
        void CreateTables()
        {
            config.SetProertyes();
            CeConn.Open();
            
            try
            {
                string CreateCariTableSql = " CREATE TABLE CARI ( " +
                    " CR_CARI_NO nvarchar (10), " +
                    " CR_CARI_ADI1 nvarchar (37), " +
                    " CR_ADRES1	nvarchar (38), " +
                    " CR_ADRES2 nvarchar (26), " +
                    " CR_TEL1 nvarchar (12), " +
                    " CR_VERGI_DA nvarchar (14), " +
                    " CR_VERGI_NO nvarchar (10), " +
                    " CR_RISK_LIM float , " +
                    " CR_TOPLAM_RISK float , " +
                    " CR_PLAS_HS nvarchar (10), " +
                    " rg_pt float, " +
                    " rg_sl float, " +
                    " rg_cr float, " +
                    " rg_pr float, " +
                    " rg_cm float, " +
                    " rg_ct float, " +
                    " borc_bakiye float," +
                    " ort_vade datetime ," +
                    " rg_pz float) ";


                SqlCeCommand cmd = new SqlCeCommand(CreateCariTableSql, CeConn);
                cmd.ExecuteNonQuery();


                string CreateStokTableString = " CREATE TABLE Stok (" +
                    " GRUP_KODU nvarchar (12), " +
                    " SICIL_KODU nvarchar (12), " +
                    " SICIL_ADI nvarchar (58), " +
                    " ISKOD3 nvarchar (8)," +
                    " BIRIM nvarchar (7)," +
                    " BIRIM1A nvarchar (8)," +
                    " BIRIM1C float) ";


                cmd.CommandText = CreateStokTableString;
                cmd.ExecuteNonQuery();


                string CreateIrsaliye = "CREATE TABLE Baslik ( " +
                    " Musteri_Kodu nvarchar (15)," +
                    " Siparis_No int IDENTITY (" + SiparisNoHesapla() + ", 1)," +
                    " Tur nvarchar(50)," +
                    " Musteri_Adi nvarchar (60) ," +
                    " Plasiyer_Kodu nvarchar (15)," +
                    " Siparis_Tarihi datetime, " +
                    " Teslim_Tarihi datetime, " +
                    " Vade_Gunu int, " +
                    " Odeme_Sekli nvarchar (1)," +
                    " Teslim_Alan nvarchar (20)," +
                    " Belge_No int)";

                cmd.CommandText = CreateIrsaliye;
                cmd.ExecuteNonQuery();

                string CreateIrsaliyeDetay = "CREATE TABLE BaslikDetay( " +
                    " Grup_Kodu nvarchar (15), " +
                    " Siparis_No nvarchar(20), " +
                    " Tur nvarchar(50)," +
                    " SiparisDetay_No int IDENTITY(" + config.PDAKodu + "0000, 1)," +
                    " Sicil_Kodu nvarchar (15), " +
                    " Plasiyer_Kodu nvarchar (15), " +
                    " Sicil_Adi nvarchar (70), " +
                    " Miktar float, " +
                    " Birim nvarchar (10), " +
                    " Birim_Fiyat float, " +
                    " Tutar float, " +
                    " iskonto1 float, " +
                    " iskonto2 float, " +
                    " iskonto3 float, " +
                    " iskonto4 float, " +
                    " iskonto5 float, " +
                    " kolimiktar float, "+
                    " Belge_No int)";
                cmd.CommandText = CreateIrsaliyeDetay;
                cmd.ExecuteNonQuery();

              
                
               
                string CreateBarkod = "CREATE TABLE Barkod( " +
                    "barkod_kodu nvarchar (50)," +
                    "Grup_kodu nvarchar (50)," +
                    "Sicil_kodu nvarchar (50)," +
                    "Birim nvarchar (50) NULL," +
                    "sicil_adi nvarchar (200) NULL," +
                    "birim1c nvarchar (50) NULL," +
                    "ana_birim nvarchar (50) NULL)";

                cmd.CommandText = CreateBarkod;
                cmd.ExecuteNonQuery();

                string CreateKullanici = "CREATE TABLE DEPO_Kullanici( " +
                    "kodu nvarchar (15)," +
                    "adi nvarchar (20) NULL)";

                cmd.CommandText = CreateKullanici;
                cmd.ExecuteNonQuery();
                
                string CreateStokDurum = "CREATE TABLE DEPO_StokDurum( " +
                    "Grup_Kodu nvarchar (20)," +
                    "Sicil_Kodu nvarchar (20)," +
                    "Miktar float," +
                    "Depo nvarchar (10))";

                cmd.CommandText = CreateStokDurum;
                cmd.ExecuteNonQuery();

                string CreateSevkBaslik = "CREATE TABLE SevkBaslik( " +
                    "Arac nvarchar (20) ," +
                    "RecNo int IDENTITY ("+ config.PDAKodu +"0000, 1)," + 
                    "Sef nvarchar (20) ," +
	                "Sofor nvarchar (20) ," +
	                "Muavin nvarchar (20) ," +
	                "CikisKM float ," +
                    "DonusKM float ," +
	                "CikisSaat nvarchar (8)," +
	                "DonusSaat nvarchar (8)," +
                    "SevkiyatTarihi datetime)";

                cmd.CommandText = CreateSevkBaslik;
                cmd.ExecuteNonQuery();

                string CreateSevkDetay = "CREATE TABLE SevkDetay( " + 
	                "RecNo int IDENTITY (1, 1)," +
	                "BaslikNo int NOT NULL ," +
	                "Fatura_No int NULL ," +
	                "Sevk_Durumu nvarchar (50)," +
                    "DonusSaat nvarchar (8))";

                cmd.CommandText = CreateSevkDetay;
                cmd.ExecuteNonQuery();


                string CreateSevkAyar = "CREATE TABLE SevkAyar ( " +
                    "Kod nvarchar (50) NULL ," +
                    "AD nvarchar (200) NULL)";

                cmd.CommandText = CreateSevkAyar;
                cmd.ExecuteNonQuery();

                string CreateSevkiyat = "CREATE TABLE Sevkiyat ( " +
                    "Arac nvarchar (20) ," +
                    "YuklemeNo int, " +    
                    "RecNo int IDENTITY (" + config.PDAKodu + "0000, 1)," +
                    "Sef nvarchar (20) ," +
                    "Sofor nvarchar (20) ," +
                    "Muavin nvarchar (20) ," +
                    "CikisKM float ," +
                    "DonusKM float ," +
                    "CikisSaat nvarchar (8)," +
                    "DonusSaat nvarchar (8)," +
                    "SevkiyatTarihi datetime," +
                    "Fatura_No int NULL ," +
                    "Sevk_Durumu nvarchar (50)," +
                    "Durum nvarchar (30))";

                cmd.CommandText = CreateSevkiyat;
                cmd.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Tablo Oluþturma Hatasý");
            }

            CeConn.Close();
            CeConn.Dispose();
        }

        #endregion

        //==========================================//
        // PC 'den PDA 'ya Veri Transfer Rutinleri  //
        //==========================================//

        #region Stok sicil bilgileri aktarma
        public void stokOkuYaz(ProgressBar pb)
        {
            
            SqlConn.Open();
            CeConn.Open();

            string sql = "delete from stok ";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

            string StokSelect = "select * from stok";
            string stokadet = "select count (*) as adet from stok";
            SqlCommand cmd = new SqlCommand(stokadet, SqlConn);

            int i = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            pb.Minimum = 0;
            pb.Maximum = i;

            cmd.CommandText = StokSelect;
            int k = 1;

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {

                StokYaz(
                    rdr["GRUP_KODU"].ToString().Replace("'", "''"),
                    rdr["SICIL_KODU"].ToString().Replace("'", "''"),
                    rdr["SICIL_ADI"].ToString().Replace("'", "''"),
                    rdr["ISKOD3"].ToString().Replace("'", "''"),
                    rdr["BIRIM"].ToString().Replace("'", "''"),
                    rdr["BIRIM1A"].ToString().Replace("'", "''"),
                    ((float)Convert.ToDouble(rdr["BIRIM1C"].ToString().Replace(",", "."))));

                pb.Value = k;
                System.Windows.Forms.Application.DoEvents();
                k += 1;

            }
            rdr.Close();
            SqlConn.Close();
            CeConn.Close();
        }

        void StokYaz(string GRUP_KODU,string SICIL_KODU,string SICIL_ADI,string ISKOD3,
            string BIRIM, string BIRIM1A,float BIRIM1C)
        {
            string InsertStok = "INSERT INTO Stok " +
                "(GRUP_KODU, SICIL_KODU, SICIL_ADI, ISKOD3, BIRIM, BIRIM1A, BIRIM1C)" +
                " VALUES " +
                " ('" + GRUP_KODU + "','" + SICIL_KODU + "','" + SICIL_ADI + "','" + ISKOD3 + "','" + BIRIM + "','" + BIRIM1A + "'," + BIRIM1C + ")";

            SqlCeCommand cmd = new SqlCeCommand(InsertStok, CeConn);
            cmd.ExecuteNonQuery();

        }
        #endregion

        #region cari bilgileri aktarma
        public void CariOkuYaz(string PlasiyerKodu, ProgressBar pb)
        {

            SqlConn.Open();
            CeConn.Open();

            string sql = "delete from CARI";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

            string cariadet = "select count(*) from CARI where CR_PLAS_HS = '" + PlasiyerKodu + "'";
            SqlCommand cmd = new SqlCommand(cariadet, SqlConn);
            int i = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            pb.Minimum = 0;
            pb.Maximum = i;

            sql = "select * from CARI where CR_PLAS_HS = '" + PlasiyerKodu + "'";
            cmd.CommandText = sql;
            int k = 1;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                CariYaz(
                    rdr["CR_CARI_NO"].ToString().Replace("'", "''"),
                    rdr["CR_CARI_ADI1"].ToString().Replace("'", "''"),
                    rdr["CR_ADRES1"].ToString().Replace("'", "''"),
                    rdr["CR_ADRES2"].ToString().Replace("'", "''"),
                    rdr["CR_TEL1"].ToString().Replace("'", "''"),
                    rdr["CR_VERGI_DA"].ToString().Replace("'", "''"),
                    rdr["CR_VERGI_NO"].ToString().Replace("'", "''"),
                    ((float)Convert.ToDouble(rdr["CR_RISK_LIM"].ToString().Replace(",", "."))),
                    ((float)Convert.ToDouble(rdr["CR_TOPLAM_RISK"].ToString().Replace(",", "."))),
                    rdr["CR_PLAS_HS"].ToString().Replace("'", "''"),
                    ((float)Convert.ToDouble(rdr["rg_pt"].ToString().Replace(",", "."))),
                    ((float)Convert.ToDouble(rdr["rg_sl"].ToString().Replace(",", "."))),
                    ((float)Convert.ToDouble(rdr["rg_pr"].ToString().Replace(",", "."))),
                    ((float)Convert.ToDouble(rdr["rg_cm"].ToString().Replace(",", "."))),
                    ((float)Convert.ToDouble(rdr["rg_cr"].ToString().Replace(",", "."))),
                    ((float)Convert.ToDouble(rdr["rg_ct"].ToString().Replace(",", "."))),
                    ((float)Convert.ToDouble(rdr["rg_pz"].ToString().Replace(",", "."))),
                    ((float)Convert.ToDouble(rdr["BORC_BAKIYE"].ToString().Replace(",", "."))),
                    Convert.ToDateTime(rdr["ort_vade"].ToString())
                    );


                pb.Value = k;
                System.Windows.Forms.Application.DoEvents();
                k += 1;
            }

            SqlConn.Close();
            CeConn.Close();
        }

        void CariYaz(
            string CR_CARI_NO,
            string CR_CARI_ADI1,
            string CR_ADRES1,
            string CR_ADRES2,
            string CR_TEL1,
            string CR_VERGI_DA,
            string CR_VERGI_NO,
            float CR_RISK_LIM,
            float CR_TOPLAM_RISK,
            string CR_PLAS_HS,
            float rg_pt,
            float rg_sl,
            float rg_pr,
            float rg_cm,
            float rg_cr,
            float rg_ct,
            float rg_pz,
            float borc_bakiye,
            DateTime ort_vade
            )
        {

            string vd = ort_vade.ToString("MM/dd/yyyy");
            string sql = " INSERT INTO CARI " +
                " (CR_CARI_NO, CR_CARI_ADI1, CR_ADRES1, CR_ADRES2, CR_TEL1, CR_VERGI_DA, CR_VERGI_NO, CR_RISK_LIM, CR_TOPLAM_RISK, CR_PLAS_HS," +
                " rg_pt, rg_sl, rg_pr, rg_cm, rg_cr, rg_ct, rg_pz,borc_bakiye, ort_vade) " +
                " VALUES  " +
                " ('" + CR_CARI_NO + "','" + CR_CARI_ADI1 + "','" + CR_ADRES1 + "','" +
                CR_ADRES2 + "','" + CR_TEL1 + "','" +
                CR_VERGI_DA + "','" + CR_VERGI_NO + "'," + CR_RISK_LIM + "," + CR_TOPLAM_RISK + ",'" + CR_PLAS_HS + "'," +
                rg_pt + "," + rg_sl + "," + rg_pr + "," + rg_cm + "," + rg_cr + "," + rg_ct + "," + rg_pz + "," + borc_bakiye + ",'" + vd + "')";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

        }
        #endregion

        #region barkod bilgileri aktarma
        public void BarkodOkuYaz(string PlasiyerKodu, ProgressBar pb)
        {

            SqlConn.Open();
            CeConn.Open();

            string sql = "delete from Barkod";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

            string barkodadet = "select count(*) from Barkod";
            SqlCommand cmd = new SqlCommand(barkodadet, SqlConn);
            int i = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            pb.Minimum = 0;
            pb.Maximum = i;

            sql = "select * from Barkod";
            cmd.CommandText = sql;
            int k = 1;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                BarkodYaz(
                    rdr["barkod_kodu"].ToString().Replace("'", "''"),
                    rdr["Grup_kodu"].ToString().Replace("'", "''"),
                    rdr["Sicil_kodu"].ToString().Replace("'", "''"),
                    rdr["Birim"].ToString().Replace("'", "''"),
                    rdr["sicil_adi"].ToString().Replace("'", "''"),
                    rdr["birim1c"].ToString().Replace("'", "''"),
                    rdr["ana_birim"].ToString().Replace("'", "''")
                    );

                pb.Value = k;
                System.Windows.Forms.Application.DoEvents();
                k += 1;
            }

            SqlConn.Close();
            CeConn.Close();
        }

        void BarkodYaz(
            string barkod_kodu,
            string Grup_kodu,
            string Sicil_kodu,
            string Birim,
            string sicil_adi,
            string birim1c,
            string ana_birim)
        {

            string sql = "INSERT INTO BARKOD(barkod_kodu,Grup_kodu,Sicil_kodu,Birim,sicil_adi,birim1c,ana_birim) VALUES (" +
                "'" + barkod_kodu + "'," +
                "'" + Grup_kodu + "'," +
                "'" + Sicil_kodu + "'," +
                "'" + Birim + "'," +
                "'" + sicil_adi + "'," +
                "'" + birim1c + "'," +
                "'" + ana_birim + "')";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

        }
        #endregion

        #region Kullanici bilgileri aktarma
        public void KullaniciOkuYaz(string PlasiyerKodu, ProgressBar pb)
        {

            SqlConn.Open();
            CeConn.Open();

            string sql = "delete from DEPO_Kullanici";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

            string Kuladet = "select count(*) from DEPO_Kullanici";
            SqlCommand cmd = new SqlCommand(Kuladet, SqlConn);
            int i = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            pb.Minimum = 0;
            pb.Maximum = i;

            sql = "select * from DEPO_Kullanici";
            cmd.CommandText = sql;
            int k = 1;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                KullaniciYaz(
                    rdr["Kodu"].ToString().Replace("'", "''"),
                    rdr["Adi"].ToString().Replace("'", "''")
                    );

                pb.Value = k;
                System.Windows.Forms.Application.DoEvents();
                k += 1;
            }

            SqlConn.Close();
            CeConn.Close();
        }

        void KullaniciYaz(string kodu, string adi)
        {

            string sql = "INSERT INTO DEPO_Kullanici(Kodu,Adi) VALUES (" +
                "'" + kodu + "'," +
                "'" + adi + "')";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

        }
        #endregion

        #region Stok Durum bilgileri aktarma
        public void StokDurumOkuYaz(string PlasiyerKodu, ProgressBar pb)
        {

            SqlConn.Open();
            CeConn.Open();

            string sql = "delete from DEPO_StokDurum";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

            string Stokadet = "select count(*) from DEPO_StokDurum";
            SqlCommand cmd = new SqlCommand(Stokadet, SqlConn);
            int i = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            pb.Minimum = 0;
            pb.Maximum = i;

            sql = "select * from DEPO_StokDurum";
            cmd.CommandText = sql;
            int k = 1;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                StokDurumYaz(
                    rdr["Grup_kodu"].ToString().Replace("'", "''"),
                    rdr["Sicil_Kodu"].ToString().Replace("'", "''"),
                    ((float)Convert.ToDouble(rdr["Miktar"].ToString().Replace(",", "."))),
                    rdr["Depo"].ToString().Replace("'", "''"));

                pb.Value = k;
                System.Windows.Forms.Application.DoEvents();
                k += 1;
            }

            SqlConn.Close();
            CeConn.Close();
        }

        void StokDurumYaz(string GrupKodu, string SicilKodu, double Miktar, string DepoKodu)
        {

            string sql = "INSERT INTO DEPO_StokDurum(Grup_Kodu,Sicil_Kodu,Miktar,Depo) VALUES (" +
                "'" + GrupKodu + "'," +
                "'" + SicilKodu + "'," +
                "" + Miktar + "," +
                "'" + DepoKodu + "')"; 

            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

        }
        #endregion

        #region Sevk Ayar bilgileri aktarma
        public void SevkAyarOkuYaz(string PlasiyerKodu, ProgressBar pb)
        {

            SqlConn.Open();
            CeConn.Open();

            string sql = "delete from SevkAyar";
            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

            string Stokadet = "select count(*) from SEVK_AYAR";
            SqlCommand cmd = new SqlCommand(Stokadet, SqlConn);
            int i = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            pb.Minimum = 0;
            pb.Maximum = i;

            sql = "select * from SEVK_AYAR";
            cmd.CommandText = sql;
            int k = 1;
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                SevkAyarYaz(
                    rdr["Kod"].ToString().Replace("'", "''"),
                    rdr["Ad"].ToString().Replace("'", "''"));

                pb.Value = k;
                System.Windows.Forms.Application.DoEvents();
                k += 1;
            }

            SqlConn.Close();
            CeConn.Close();
        }

        void SevkAyarYaz(string Kod, string Ad)
        {

            string sql = "INSERT INTO SevkAyar(Kod,AD) VALUES (" +
                "'" + Kod + "'," +
                "'" + Ad + "')";

            new SqlCeCommand(sql, CeConn).ExecuteNonQuery();

        }
        #endregion


        //============================================//
        // PDA 'dan PC 'ye  Veri Transfer Rutinleri   //
        //============================================// 

        #region Irsaliye Kaydet
        public void IrsaliyeKaydet(ProgressBar pb)
        {
            CeConn.Open();
            SqlConn.Open();

            SqlCommand cmdBaslikKaydet = new SqlCommand();
            SqlCommand cmdDetayKaydet = new SqlCommand();

            SqlCeCommand cmdDelete = new SqlCeCommand();

            SqlTransaction tr;
            tr = SqlConn.BeginTransaction();

            try
            {
                // Sipariþ Baþlýk Tablosundan Oku
                string sqlCe = " select * from Baslik";
                SqlCeCommand cmdCe = new SqlCeCommand(sqlCe, CeConn);
                SqlCeDataReader rdr = cmdCe.ExecuteReader();
                #region Irsaliye Kaydet
                while (rdr.Read())
                {

                    string sql = "insert into DEPO_Baslik " +
                    "(Musteri_Kodu, Musteri_Adi, Plasiyer_Kodu,Siparis_Tarihi,Teslim_Tarihi," +
                    " Vade_Gunu,Odeme_Sekli,Siparis_No, Tur, Teslim_Alan,Belge_No)" +
                    " VALUES (" +
                    "'" + rdr["Musteri_Kodu"].ToString() + "'," +
                    "'" + rdr["Musteri_Adi"].ToString() + "'," +
                    "'" + rdr["Plasiyer_Kodu"].ToString() + "'," +
                    "'" + String.Format("{0:MM/dd/yyyy}", rdr["Siparis_Tarihi"]) + "'," +
                    "'" + String.Format("{0:MM/dd/yyyy}", rdr["Teslim_Tarihi"]) + "'," +
                    " " + Convert.ToInt64(rdr["Vade_Gunu"].ToString()) + "," +
                    "'" + rdr["Odeme_Sekli"].ToString().ToLower() + "'," +
                    " " + Convert.ToInt64(rdr["Siparis_No"].ToString()) + "," +
                    "'" + rdr["Tur"].ToString() + "'," +
                    "'" + rdr["Teslim_Alan"].ToString() + "'," +
                    " " + rdr["Belge_No"].ToString() + ")";

                    cmdBaslikKaydet.Connection = SqlConn;
                    cmdBaslikKaydet.CommandText = sql;
                    cmdBaslikKaydet.Transaction = tr;
                    cmdBaslikKaydet.ExecuteNonQuery();
                }
                #endregion

                // Sipariþ Detay Tablosundan Oku
                string sqlCe2 = " select count(*) from BaslikDetay";
                SqlCeCommand cmdCe2 = new SqlCeCommand(sqlCe2, CeConn);
                int i = Convert.ToInt32(cmdCe2.ExecuteScalar().ToString());
                pb.Minimum = 0;
                pb.Maximum = i;

                sqlCe2 = "select * from BaslikDetay";
                cmdCe2.CommandText = sqlCe2;

                SqlCeDataReader rdrDetay = cmdCe2.ExecuteReader();
                #region Sipariþ Detay Kaydet
                int k = 0;
                while (rdrDetay.Read())
                {
                    string sql2 = "Insert Into DEPO_BaslikDetay(Grup_Kodu,Siparis_No,Tur,Sicil_Kodu,Plasiyer_Kodu,Sicil_Adi,Miktar,Birim,Birim_Fiyat,Tutar,iskonto1,iskonto2,iskonto3,iskonto4,iskonto5,kolimiktar)" +
                    " VALUES(" +
                    " '" + rdrDetay["Grup_Kodu"].ToString() + "'	,	" +
                    " " + Convert.ToInt64(rdrDetay["Siparis_No"].ToString()) + "	,	" +
                    " '" + rdrDetay["Tur"].ToString() + "'	,	" +
                    " '" + rdrDetay["Sicil_Kodu"].ToString() + "'	,	" +
                    " '" + rdrDetay["Plasiyer_Kodu"].ToString() + "',	" +
                    " '" + rdrDetay["Sicil_Adi"].ToString().Replace("'", "''") + "'	,	" +
                    " " + Convert.ToSingle(rdrDetay["Miktar"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " '" + rdrDetay["Birim"].ToString() + "'		,	" +
                    " " + Convert.ToSingle(rdrDetay["Birim_Fiyat"].ToString()).ToString().Replace(",", ".") + "	,	" +
                    " " + Convert.ToSingle(rdrDetay["Tutar"].ToString()).ToString().Replace(",", ".") + "			,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto1"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto2"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto3"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto4"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto5"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["kolimiktar"].ToString()).ToString().Replace(",", ".") + "	)	";

                    cmdDetayKaydet.Connection = SqlConn;
                    cmdDetayKaydet.CommandText = sql2;
                    cmdDetayKaydet.Transaction = tr;
                    cmdDetayKaydet.ExecuteNonQuery();

                    k += 1;
                    pb.Value = k;
                    System.Windows.Forms.Application.DoEvents();
                }
                #endregion

                tr.Commit();

                //Sipariþ Baþlýk Sil
                cmdDelete.Connection = CeConn;
                cmdDelete.CommandText = "DELETE FROM Baslik";
                cmdDelete.ExecuteNonQuery();

                //Sipariþ Detay Sil
                cmdDelete.Connection = CeConn;
                cmdDelete.CommandText = "DELETE FROM BaslikDetay";
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Hata oluþtu, iþlem iptal edildi. Hata Detayý: " + Ex.Message);
                tr.Rollback();
                throw;
            }
            finally
            {
                SqlConn.Close();
                CeConn.Close();
            }
        }

        #endregion

        #region Sayim Kaydet
        public void SayimKaydet(ProgressBar pb)
        {
            CeConn.Open();
            SqlConn.Open();

            SqlCommand cmdBaslikKaydet = new SqlCommand();
            SqlCommand cmdDetayKaydet = new SqlCommand();

            SqlCeCommand cmdDelete = new SqlCeCommand();

            SqlTransaction tr;
            tr = SqlConn.BeginTransaction();

            try
            {
                // Sipariþ Baþlýk Tablosundan Oku
                string sqlCe = " select * from Sayim";
                SqlCeCommand cmdCe = new SqlCeCommand(sqlCe, CeConn);

                SqlCeDataReader rdr = cmdCe.ExecuteReader();
                #region Irsaliye Kaydet
                while (rdr.Read())
                {
                    DateTime sp = Convert.ToDateTime(rdr["Siparis_Tarihi"].ToString());
                    DateTime tt = Convert.ToDateTime(rdr["Teslim_Tarihi"].ToString());
                    string dt = sp.ToString("MM/dd/yyyy");
                    string tsdt = tt.ToString("MM/dd/yyyy");
                    string sql = "insert into DEPO_Sayim " +
                    "(Musteri_Kodu, Musteri_Adi, Plasiyer_Kodu,Siparis_Tarihi, Teslim_Tarihi, " +
                    " Vade_Gunu, Odeme_Sekli,Siparis_No,Teslim_Alan)" +
                    " VALUES (" +
                    " '" + rdr["Musteri_Kodu"].ToString() + "'," +
                    " '" + rdr["Musteri_Adi"].ToString() + "'," +
                    " '" + rdr["Plasiyer_Kodu"].ToString() + "'," +
                    " '" + dt + "'," +
                    " '" + tsdt + "'," +
                    " " + Convert.ToInt64(rdr["Vade_Gunu"].ToString()) + "," +
                    " '" + rdr["Odeme_Sekli"].ToString().ToLower() + "'," +
                    " " + Convert.ToInt64(rdr["Siparis_No"].ToString()) + "," +
                    "'" + rdr["Teslim_Alan"].ToString() + "')";

                    cmdBaslikKaydet.Connection = SqlConn;
                    cmdBaslikKaydet.CommandText = sql;
                    cmdBaslikKaydet.Transaction = tr;
                    cmdBaslikKaydet.ExecuteNonQuery();
                }
                #endregion

                // Sipariþ Detay Tablosundan Oku
                string sqlCe2 = " select count(*) from SayimDetay";
                SqlCeCommand cmdCe2 = new SqlCeCommand(sqlCe2, CeConn);
                int i = Convert.ToInt32(cmdCe2.ExecuteScalar().ToString());
                pb.Minimum = 0;
                pb.Maximum = i;

                sqlCe2 = "select * from SayimDetay";
                cmdCe2.CommandText = sqlCe2;

                SqlCeDataReader rdrDetay = cmdCe2.ExecuteReader();
                #region Sipariþ Detay Kaydet
                int k = 0;
                while (rdrDetay.Read())
                {
                    string sql2 = "Insert Into DEPO_SayimDetay (Grup_Kodu,Siparis_No,Sicil_Kodu,Plasiyer_Kodu,Sicil_Adi,Miktar,Birim,Birim_Fiyat,Tutar,iskonto1,iskonto2,iskonto3,iskonto4,iskonto5,kolimiktar)" +
                    " VALUES(" +
                    " '" + rdrDetay["Grup_Kodu"].ToString() + "'	,	" +
                    " " + Convert.ToInt64(rdrDetay["Siparis_No"].ToString()) + "	,	" +
                    " '" + rdrDetay["Sicil_Kodu"].ToString() + "'	,	" +
                    " '" + rdrDetay["Plasiyer_Kodu"].ToString() + "',	" +
                    " '" + rdrDetay["Sicil_Adi"].ToString().Replace("'", "''") + "'	,	" +
                    " " + Convert.ToSingle(rdrDetay["Miktar"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " '" + rdrDetay["Birim"].ToString() + "'		,	" +
                    " " + Convert.ToSingle(rdrDetay["Birim_Fiyat"].ToString()).ToString().Replace(",", ".") + "	,	" +
                    " " + Convert.ToSingle(rdrDetay["Tutar"].ToString()).ToString().Replace(",", ".") + "			,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto1"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto2"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto3"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto4"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["iskonto5"].ToString()).ToString().Replace(",", ".") + "		,	" +
                    " " + Convert.ToSingle(rdrDetay["kolimiktar"].ToString()).ToString().Replace(",", ".") + "	)	";

                    cmdDetayKaydet.Connection = SqlConn;
                    cmdDetayKaydet.CommandText = sql2;
                    cmdDetayKaydet.Transaction = tr;
                    cmdDetayKaydet.ExecuteNonQuery();

                    k += 1;
                    pb.Value = k;
                    System.Windows.Forms.Application.DoEvents();
                }
                #endregion

                tr.Commit();

                //Sipariþ Baþlýk Sil
                cmdDelete.Connection = CeConn;
                cmdDelete.CommandText = "DELETE FROM Sayim";
                cmdDelete.ExecuteNonQuery();

                //Sipariþ Detay Sil
                cmdDelete.Connection = CeConn;
                cmdDelete.CommandText = "DELETE FROM SayimDetay";
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Hata oluþtu, iþlem iptal edildi. Hata Detayý: " + Ex.Message);
                tr.Rollback();
            }
            finally
            {
                SqlConn.Close();
                CeConn.Close();
            }
        }

        #endregion

        #region SevkBaslik Kaydet 
        public void Sevk(ProgressBar pb)
        {
            CeConn.Open();
            SqlConn.Open();

            SqlCommand cmdBaslikKaydet = new SqlCommand();
            SqlCommand cmdDetayKaydet = new SqlCommand();

            SqlCeCommand cmdDelete = new SqlCeCommand();

            SqlTransaction tr;
            tr = SqlConn.BeginTransaction();

            try
            {
                // Sipariþ Baþlýk Tablosundan Oku
                string sqlCe = " select * from SevkBaslik WHERE DonusSaat > '00:00'";
                SqlCeCommand cmdCe = new SqlCeCommand(sqlCe, CeConn);

                SqlCeDataReader rdr = cmdCe.ExecuteReader();
                #region DEPO_SevkBaslik Kaydet
                while (rdr.Read())
                {
                    DateTime st = Convert.ToDateTime(rdr["SevkiyatTarihi"].ToString());
                    string sevkTar = st.ToString("MM/dd/yyyy");
                    
                    string sql = "INSERT INTO DEPO_SevkBaslik(RecNo, Sef, Sofor, Muavin, " +
                        "Arac, CikisKM, DonusKM, CikisSaat, DonusSaat, SevkiyatTarihi)" +
                        " VALUES (" +
                        " " + rdr["RecNo"].ToString() + "," +
                        " '" + rdr["Sef"].ToString() + "'," +
                        " '" + rdr["Sofor"].ToString() + "'," +
                        " '" + rdr["Muavin"].ToString() + "'," +
                        " '" + rdr["Arac"].ToString() + "'," +
                        " " + Convert.ToDouble(rdr["CikisKM"].ToString()) + "," +
                        " " + Convert.ToDouble(rdr["DonusKM"].ToString()) + "," +
                        "'" + rdr["CikisSaat"].ToString() + "'," +
                        "'" + rdr["DonusSaat"].ToString() + "'," +
                        "'" + sevkTar + "')";

                    cmdBaslikKaydet.Connection = SqlConn;
                    cmdBaslikKaydet.CommandText = sql;
                    cmdBaslikKaydet.Transaction = tr;
                    cmdBaslikKaydet.ExecuteNonQuery();
                }
                #endregion

                // Sipariþ Detay Tablosundan Oku
                string sqlCe2 = " select count(*) from SevkDetay";
                SqlCeCommand cmdCe2 = new SqlCeCommand(sqlCe2, CeConn);
                int i = Convert.ToInt32(cmdCe2.ExecuteScalar().ToString());
                pb.Minimum = 0;
                pb.Maximum = i;

                sqlCe2 = "select * from SevkDetay WHERE DonusSaat > '00:00'";
                cmdCe2.CommandText = sqlCe2;

                SqlCeDataReader rdrDetay = cmdCe2.ExecuteReader();
                #region Sipariþ Detay Kaydet
                int k = 0;
                while (rdrDetay.Read())
                {
                    string sql2 = "INSERT INTO DEPO_SevkDetay(RecNo, BaslikNo, Fatura_No, Sevk_Durumu) " +
                        " VALUES(" +
                        "" + Convert.ToInt32(rdrDetay["RecNo"].ToString()) + "," +
                        "" + Convert.ToInt32(rdrDetay["BaslikNo"].ToString()) + "," +
                        "" + Convert.ToInt32(rdrDetay["Fatura_No"].ToString()) + "," +
                        "'" + rdrDetay["Sevk_Durumu"].ToString() + "')";

                    cmdDetayKaydet.Connection = SqlConn;
                    cmdDetayKaydet.CommandText = sql2;
                    cmdDetayKaydet.Transaction = tr;
                    cmdDetayKaydet.ExecuteNonQuery();

                    k += 1;
                    pb.Value = k;
                    System.Windows.Forms.Application.DoEvents();
                }
                #endregion

                tr.Commit();

                //Sipariþ Baþlýk Sil
                cmdDelete.Connection = CeConn;
                cmdDelete.CommandText = "DELETE FROM SevkBaslik WHERE DonusSaat > '00:00'";
                cmdDelete.ExecuteNonQuery();

                //Sipariþ Detay Sil
                cmdDelete.Connection = CeConn;
                cmdDelete.CommandText = "DELETE FROM SevkDetay WHERE DonusSaat > '00:00'";
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Hata oluþtu, iþlem iptal edildi. Hata Detayý: " + Ex.Message);
                tr.Rollback();
            }
            finally
            {
                SqlConn.Close();
                CeConn.Close();
            }
        }

        #endregion

        #region Sevkiyat Tablosu Kaydet
        public void Sevkiyat(ProgressBar pb)
        {
            CeConn.Open();
            SqlConn.Open();

            SqlCommand cmdSevkiyat = new SqlCommand();
            SqlCeCommand cmdDelete = new SqlCeCommand();

            SqlTransaction tr;
            tr = SqlConn.BeginTransaction();

            try
            {
                // Sevkiyat Tablosu Kayýt Sayýsý
                string sqlCe2 = "select count(*) from Sevkiyat";
                SqlCeCommand cmdCe2 = new SqlCeCommand(sqlCe2, CeConn);
                int i = Convert.ToInt32(cmdCe2.ExecuteScalar().ToString());
                pb.Minimum = 0;
                pb.Maximum = i;

                // Sevkiyat Tablosundan Oku
                string sqlCe = " select * from Sevkiyat";
                SqlCeCommand cmdCe = new SqlCeCommand(sqlCe, CeConn);
                SqlCeDataReader rdr = cmdCe.ExecuteReader();

                #region DEPO_Sevkiyat Tablosuna Yaz
                int k = 0;
                while (rdr.Read())
                {
                    DateTime st = Convert.ToDateTime(rdr["SevkiyatTarihi"].ToString());
                    string sevkTar = st.ToString("MM/dd/yyyy");

                    string sql = "INSERT INTO DEPO_Sevkiyat(RecNo,YuklemeNo,Sef,Sofor,Muavin,Arac,CikisKM,DonusKM,CikisSaat,DonusSaat,SevkiyatTarihi,Fatura_No,Sevk_Durumu,Durum)" +
                        "VALUES (" +
                        " " + Convert.ToInt32(rdr["RecNo"].ToString()) + "," +
                        " " + Convert.ToInt32(rdr["YuklemeNo"].ToString()) + "," +
                        "'" + rdr["Sef"].ToString() + "'," +
                        "'" + rdr["Sofor"].ToString() + "'," +
                        "'" + rdr["Muavin"].ToString() + "'," +
                        "'" + rdr["Arac"].ToString() + "'," +
                        " " + Convert.ToDouble(rdr["CikisKM"].ToString()) + "," +
                        " " + Convert.ToDouble(rdr["DonusKM"].ToString()) + "," +
                        "'" + rdr["CikisSaat"].ToString() + "'," +
                        "'" + rdr["DonusSaat"].ToString() + "'," +
                        "'" + sevkTar + "'," +
                        "" + Convert.ToInt32(rdr["Fatura_No"].ToString()) + "," +
                        "'" + rdr["Sevk_Durumu"].ToString() + "'," +
                        "'" + rdr["Durum"].ToString() + "')";
           
                    cmdSevkiyat.Connection = SqlConn;
                    cmdSevkiyat.CommandText = sql;
                    cmdSevkiyat.Transaction = tr;
                    cmdSevkiyat.ExecuteNonQuery();

                    k += 1;
                    pb.Value = k;
                    System.Windows.Forms.Application.DoEvents();
                }
                #endregion

                tr.Commit();

                //Yükleme Kaydý Sil
                cmdDelete.Connection = CeConn;
                cmdDelete.CommandText = "DELETE FROM Sevkiyat WHERE DonusSaat > '00:00'";
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Hata oluþtu, iþlem iptal edildi. Hata Detayý: " + Ex.Message);
                tr.Rollback();
            }
            finally
            {
                SqlConn.Close();
                CeConn.Close();
            }
        }

        #endregion
    }
}
