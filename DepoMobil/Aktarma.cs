#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

#endregion

namespace DepoMobil
{
    /// <summary>
    /// Summary description for Aktarma.
    /// </summary>
    public class Aktarma : System.Windows.Forms.Form
    {
        private Button button3;
        private Label label1;
        private Label mesaj;
        private CheckBox Offline;
        private Button button2;
        private Button baslat;
        private Button button1;
        DB db;
        private ProgressBar progressBar1;
        Config config = new Config();

        public Aktarma()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mesaj = new System.Windows.Forms.Label();
            this.Offline = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.baslat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(147, 250);
            this.button3.Size = new System.Drawing.Size(72, 20);
            this.button3.Text = "Kapat";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(84, 250);
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.Text = ".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // mesaj
            // 
            this.mesaj.Location = new System.Drawing.Point(34, 148);
            this.mesaj.Size = new System.Drawing.Size(176, 20);
            // 
            // Offline
            // 
            this.Offline.Checked = true;
            this.Offline.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Offline.Location = new System.Drawing.Point(65, 40);
            this.Offline.Size = new System.Drawing.Size(100, 20);
            this.Offline.Text = "Offline";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(34, 113);
            this.button2.Size = new System.Drawing.Size(176, 20);
            this.button2.Text = "Veri Gönder";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // baslat
            // 
            this.baslat.Location = new System.Drawing.Point(34, 77);
            this.baslat.Size = new System.Drawing.Size(176, 20);
            this.baslat.Text = "Veri Al";
            this.baslat.Click += new System.EventHandler(this.baslat_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 14);
            this.button1.Size = new System.Drawing.Size(176, 20);
            this.button1.Text = "Veritabaný Oluþtur";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(34, 206);
            this.progressBar1.Size = new System.Drawing.Size(176, 20);
            // 
            // Aktarma
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mesaj);
            this.Controls.Add(this.Offline);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.baslat);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Text = "Veri Aktarýmlarý";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Kayýtlý bütün veriler silinecektir emin misiniz? ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                if (config == null)
                {
                    config = new Config();
                    config.SetProertyes();

                }
                config.isOffline = true;

                try
                {
                    mesaj.Text = "Veri Tabaný Oluþturuluyor";
                    Application.DoEvents();

                    db = new DB(config);
                    MessageBox.Show("Veri tabaný oluþturuldu");

                    baslat.Enabled = true;
                    label1.Text = "";
                    mesaj.Text = "";
                }
                catch
                {
                    MessageBox.Show("Veri tabaný oluþturulurken bir hata oluþtu", "Dikkat");
                }
            }
        }

        private void baslat_Click(object sender, EventArgs e)
        {
            config.isOffline = Offline.Checked;
            config.SetProertyes();
            

            DialogResult dr = MessageBox.Show("Veriler aktarýlacak emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

             if (dr == DialogResult.Yes)
             {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                baslat.Enabled = false;
                try
                {
                    #region stok aktarma
                    try
                    {
                        mesaj.Text = "Stok bilgileri aktarýlýyor";
                        Application.DoEvents();

                        if (config == null)
                            config = new Config();

                        config.SetProertyes();
                        config.isOffline = Offline.Checked;

                        if (db == null)
                            db = new DB(config, true);
                        db.stokOkuYaz(progressBar1);

                        mesaj.Text = "";

                    }
                    catch
                    {
                        MessageBox.Show("Stok bilgileri aktarýlýrken bir hata oluþtu", "Dikkat");
                    }
                    #endregion

                    #region cari aktarma
                    try
                    {
                        mesaj.Text = "Cari aktarýlýyor";
                        Application.DoEvents();
                        if (config == null)
                        {
                            config = new Config();
                            config.SetProertyes();
                        }
                        if (db == null)
                            db = new DB(config, true);
                        db.CariOkuYaz(config.PlasiyerKodu, progressBar1);


                        mesaj.Text = "";
                        label1.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Cari aktarýlýrken bir hata oluþtu");
                    }
                    #endregion

                    #region barkod aktarma
                    try
                    {
                        mesaj.Text = "Barkod aktarýlýyor";
                        Application.DoEvents();
                        if (config == null)
                        {
                            config = new Config();
                            config.SetProertyes();
                        }
                        if (db == null)
                            db = new DB(config, true);
                        db.BarkodOkuYaz(config.PlasiyerKodu, progressBar1);


                        mesaj.Text = "";
                        label1.Text = "";
                    }
                    catch
                    {
                        MessageBox.Show("Barkod aktarýlýrken bir hata oluþtu");
                    }
                    #endregion

                    #region Kullanici aktarma
                    try
                    {
                        mesaj.Text = "Kullanici aktarýlýyor";
                        Application.DoEvents();
                        if (config == null)
                        {
                            config = new Config();
                            config.SetProertyes();
                        }
                        if (db == null)
                            db = new DB(config, true);
                        db.KullaniciOkuYaz(config.PlasiyerKodu, progressBar1);


                        mesaj.Text = "Aktarmalar tamamlandý";
                        label1.Text = "";
                    }

                    catch
                    {
                        MessageBox.Show("Kullanici aktarýlýrken bir hata oluþtu");
                    }
                    #endregion

                    #region Stok Durum aktarma
                    try
                    {
                        mesaj.Text = "Stok Durum aktarýlýyor";
                        Application.DoEvents();
                        if (config == null)
                        {
                            config = new Config();
                            config.SetProertyes();
                        }
                        if (db == null)
                            db = new DB(config, true);
                        db.StokDurumOkuYaz(config.PlasiyerKodu, progressBar1);

                        mesaj.Text = "Aktarmalar tamamlandý";
                        label1.Text = "";
                    }

                    catch
                    {
                        MessageBox.Show("Stok Durum bir hata oluþtu");
                    }
                    #endregion

                    #region Sevk Ayar aktarma
                    try
                    {
                        mesaj.Text = "Sevk Ayarlarý aktarýlýyor";
                        Application.DoEvents();
                        if (config == null)
                        {
                            config = new Config();
                            config.SetProertyes();
                        }
                        if (db == null)
                            db = new DB(config, true);
                        db.SevkAyarOkuYaz(config.PlasiyerKodu, progressBar1);

                        mesaj.Text = "Aktarmalar tamamlandý";
                        label1.Text = "";
                    }

                    catch
                    {
                        MessageBox.Show("Sevk Ayar bir hata oluþtu");
                    }
                    #endregion

                }
                finally
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    baslat.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            config.CeConn.Close();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            config.isOffline = Offline.Checked;

            if (config == null)
            {
                config = new Config();
                config.SetProertyes();
            }

            if (db == null)
            {
                config.SetProertyes();
                db = new DB(config, true);
            }

            /*bool err = false;
            if (VeriKontrol(out err, config))
            {
                MessageBox.Show("Sunucuda aktarýlmamýþ veriler var!\r\nAktarma devam edemez. Lütfen Sql servdan verileri alýnýz");
                button2.Enabled = true;
                return;
            }*/

            DialogResult dr = MessageBox.Show("Verileri aktarmak istediðinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                baslat.Enabled = false;
                try
                {
                    mesaj.Text = "Ýrsaliye tablosu aktarýlýyor";
                    Application.DoEvents();
                    db.IrsaliyeKaydet(progressBar1);

                    /*mesaj.Text = "Ýrsaliye Ýade tablosu aktarýlýyor";
                    Application.DoEvents();
                    db.IrsaliyeIadeKaydet(progressBar1);

                    mesaj.Text = "Transfer tablosu aktarýlýyor";
                    Application.DoEvents();
                    db.TransferKaydet(progressBar1);

                    mesaj.Text = "Sayim tablosu aktarýlýyor";
                    Application.DoEvents();
                    db.SayimKaydet(progressBar1);*/

                    mesaj.Text = "Sevk tablosu aktarýlýyor";
                    Application.DoEvents();
                    db.Sevkiyat(progressBar1);

                    mesaj.Text = "Aktarmalar tamamlandý";
                    label1.Text = "";
                }
                catch (Exception Ex)
                {
                    Application.DoEvents();
                    label1.Text = "Baðlantý Hatasý.Sistem Durdu, Hata: " + Ex.Message;
                }
                finally
                {
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    baslat.Enabled = true;
                }
            }

            button2.Enabled = true;
        }

        bool VeriKontrol(out bool err, Config config)
        {
            Int64 Irsaliye = 0;
            Int64 Iade = 0;
            Int64 Transfer = 0;
            Int64 Sayim = 0;

            try
            {
                
                SqlConnection conn = new SqlConnection(config.ConnectionString);
                conn.Open();
               
                string sql = " select count(*) from DEPO_Irsaliye";
                SqlCommand cmd = new SqlCommand(sql, conn);
                Irsaliye = Convert.ToInt64(cmd.ExecuteScalar().ToString());

                sql = " select count(*) from DEPO_Irsaliye_Iade";
                cmd.CommandText = sql;
                Iade = Convert.ToInt64(cmd.ExecuteScalar().ToString());

                sql = " select count(*) from DEPO_Transfer";
                cmd.CommandText = sql;
                Transfer = Convert.ToInt64(cmd.ExecuteScalar().ToString());

                sql = " select count(*) from DEPO_Sayim";
                cmd.CommandText = sql;
                Sayim = Convert.ToInt64(cmd.ExecuteScalar().ToString());

                conn.Close();
                err = true;
            }
            catch
            {
                err = false;
                return false;

            }

            return (Irsaliye + Iade + Transfer + Sayim) > 0;

        }

    }
}
