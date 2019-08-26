#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlServerCe;

#endregion

namespace DepoMobil
{
    /// <summary>
    /// Summary description for BaslikKaydet.
    /// </summary>
    public class BaslikKaydet : System.Windows.Forms.Form
    {
        private Button button1;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private ComboBox comboBox2;
        private TextBox txtIrsaliyeNo;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label7;
        private Label label3;
        private ComboBox comboBox1;
        private Button Kaydet;
        private ComboBox Yil;
        private ComboBox Ay;
        private ComboBox Gun;
        private Label label5;
        private Label label6;
        private Label carino;
        private Label label4;
        private Label label2;
        private Label label1;
        DateCombos dc;
        Config config;
        string tabloAd;
        string Tur;
        Int64 SiparisNo;

        public BaslikKaydet(string tabloAd, string Tur)
        {
            this.tabloAd = tabloAd;
            this.Tur = Tur;

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
            this.button1 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txtIrsaliyeNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Kaydet = new System.Windows.Forms.Button();
            this.Yil = new System.Windows.Forms.ComboBox();
            this.Ay = new System.Windows.Forms.ComboBox();
            this.Gun = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.carino = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 211);
            this.button1.Size = new System.Drawing.Size(115, 50);
            this.button1.Text = "Kapat";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(81, 160);
            this.label14.Size = new System.Drawing.Size(5, 15);
            this.label14.Text = ":";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(4, 160);
            this.label13.Size = new System.Drawing.Size(70, 25);
            this.label13.Text = "Teslim Alan";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(81, 135);
            this.label12.Size = new System.Drawing.Size(5, 15);
            this.label12.Text = ":";
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(4, 135);
            this.label11.Size = new System.Drawing.Size(70, 25);
            this.label11.Text = "Irsaliye No";
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.comboBox2.Location = new System.Drawing.Point(89, 158);
            this.comboBox2.Size = new System.Drawing.Size(100, 19);
            // 
            // txtIrsaliyeNo
            // 
            this.txtIrsaliyeNo.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.txtIrsaliyeNo.Location = new System.Drawing.Point(89, 134);
            this.txtIrsaliyeNo.Size = new System.Drawing.Size(100, 18);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular);
            this.label8.Location = new System.Drawing.Point(89, 77);
            this.label8.Size = new System.Drawing.Size(139, 20);
            this.label8.Text = "bos";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(81, 77);
            this.label9.Size = new System.Drawing.Size(8, 20);
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label10.Location = new System.Drawing.Point(4, 77);
            this.label10.Size = new System.Drawing.Size(68, 20);
            this.label10.Text = "Plasiyer Kodu";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(89, 57);
            this.label7.Size = new System.Drawing.Size(139, 20);
            this.label7.Text = "bos";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(81, 57);
            this.label3.Size = new System.Drawing.Size(8, 20);
            this.label3.Text = ":";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.comboBox1.Location = new System.Drawing.Point(4, 3);
            this.comboBox1.Size = new System.Drawing.Size(232, 19);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Kaydet
            // 
            this.Kaydet.Location = new System.Drawing.Point(123, 211);
            this.Kaydet.Size = new System.Drawing.Size(115, 50);
            this.Kaydet.Text = "Ýleri";
            this.Kaydet.Click += new System.EventHandler(this.Kaydet_Click_1);
            // 
            // Yil
            // 
            this.Yil.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Yil.Location = new System.Drawing.Point(186, 97);
            this.Yil.Size = new System.Drawing.Size(50, 19);
            // 
            // Ay
            // 
            this.Ay.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Ay.Location = new System.Drawing.Point(131, 97);
            this.Ay.Size = new System.Drawing.Size(54, 19);
            // 
            // Gun
            // 
            this.Gun.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.Gun.Location = new System.Drawing.Point(89, 97);
            this.Gun.Size = new System.Drawing.Size(40, 19);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(81, 100);
            this.label5.Size = new System.Drawing.Size(5, 15);
            this.label5.Text = ":";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(4, 100);
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.Text = "Ýrsaliye Tarihi";
            // 
            // carino
            // 
            this.carino.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular);
            this.carino.Location = new System.Drawing.Point(89, 37);
            this.carino.Size = new System.Drawing.Size(139, 20);
            this.carino.Text = "bos";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(4, 57);
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.Text = "Cari Adý";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(81, 37);
            this.label2.Size = new System.Drawing.Size(8, 20);
            this.label2.Text = ":";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(4, 37);
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.Text = "Cari No";
            // 
            // BaslikKaydet
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.txtIrsaliyeNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Kaydet);
            this.Controls.Add(this.Yil);
            this.Controls.Add(this.Ay);
            this.Controls.Add(this.Gun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.carino);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Text = "BaslikKaydet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BaslikKaydet_Load);

        }

        #endregion

        private void BaslikKaydet_Load(object sender, EventArgs e)
        {
            Config config = new Config();
            config.SetProertyes();

            SqlCeConnection CeConn = new SqlCeConnection("DataSource=ankara.sdf");
            CeConn.Open();

            string SelectSQL = "SELECT * FROM CARI ORDER BY CR_CARI_ADI1";
            SqlCeCommand cmdCombo = new SqlCeCommand(SelectSQL, CeConn);

            SqlCeDataReader drCombo;
            try
            {
                drCombo = cmdCombo.ExecuteReader();

                while (drCombo.Read())
                {
                    comboBox1.Items.Add(drCombo["CR_CARI_ADI1"].ToString());
                }

                cmdCombo.CommandText = "SELECT * FROM DEPO_Kullanici";
                drCombo = cmdCombo.ExecuteReader();

                while (drCombo.Read())
                {
                    comboBox2.Items.Add(drCombo["adi"].ToString());
                }
            }
            finally
            {
                CeConn.Close();
            }

            dc = new DateCombos(Gun, Ay, Yil);
            dc.SetDate(DateTime.Now.AddDays(1));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCeConnection CeConn = new SqlCeConnection("DataSource=ankara.sdf");
            CeConn.Open();

            string SelectSQL = "SELECT * FROM CARI WHERE CR_CARI_ADI1 = '" + comboBox1.Text + "'";
            SqlCeCommand cmdCombo = new SqlCeCommand(SelectSQL, CeConn);

            SqlCeDataReader drCombo;
            try
            {
                drCombo = cmdCombo.ExecuteReader();

                if (drCombo.Read())
                {
                    carino.Text = drCombo["CR_CARI_NO"].ToString();
                    label7.Text = drCombo["CR_CARI_ADI1"].ToString();
                    label8.Text = drCombo["CR_PLAS_HS"].ToString();
                }
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void Kaydet_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || txtIrsaliyeNo.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Tüm alanlarý doldurunuz.");
            }
            else
            {
                Int64 vade = 0;
                try
                {
                    vade = Convert.ToInt64(txtIrsaliyeNo.Text);
                }
                catch
                {
                    MessageBox.Show("Irsaliye No alanýna sayýsal bir deðer girilmelidir");
                    return;
                }

               
                if (SiparisNoVarMi(Convert.ToInt64(txtIrsaliyeNo.Text)) == true)
                {
                    DialogResult dr = MessageBox.Show("Bu numara kayýtlýdýr. Düzenlemek istermisun ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.Yes)
                    {
                        Int64 SiparisNo = SiparisNoBul(Convert.ToInt64(txtIrsaliyeNo.Text));
                        DetayKaydet dk = new DetayKaydet(SiparisNo, label8.Text, tabloAd, true, Tur, Convert.ToInt64(txtIrsaliyeNo.Text));
                        dk.Show();
                        this.Close();
                    }
                }
                else
                {
                    IrsaliyeBaslikKaydet();
                }
            }
        }

        private Int64 SiparisNoBul(Int64 BelgeNo)
        {
            SqlCeConnection CeConn = new SqlCeConnection("DataSource=ankara.sdf");
            CeConn.Open();

            string sql = "SELECT Siparis_no FROM Baslik WHERE Belge_No = " + BelgeNo;
            SqlCeCommand cmd = new SqlCeCommand(sql, CeConn);
            Int64 SipNo = 0;
            
            try
            {
                SqlCeDataReader dr;
                dr = cmd.ExecuteReader();

               

                if (dr.Read())
                {
                    SipNo = Convert.ToInt32(dr[0].ToString());                
                }
            }
            finally
            {
                CeConn.Close();
            }

            return SipNo;
        }

        private bool SiparisNoVarMi(Int64 SiparisNo)
        {
            SqlCeConnection CeConn = new SqlCeConnection("DataSource=ankara.sdf");
            CeConn.Open();

            string sql = "SELECT COUNT(*) FROM " + tabloAd + " WHERE Belge_No = " + SiparisNo;
            SqlCeCommand cmd = new SqlCeCommand(sql, CeConn);

            try
            {
                int SiparisNoAdet = Convert.ToInt32(cmd.ExecuteScalar());

                if (SiparisNoAdet > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void IrsaliyeBaslikKaydet()
        {
            Int64 vade = 0;
            try
            {
                vade = Convert.ToInt64(txtIrsaliyeNo.Text);
            }
            catch
            {
                MessageBox.Show("Irsaliye No alanýna sayýsal bir deðer girilmelidir");
                return;
            }

            SqlCeConnection CeConn = new SqlCeConnection("DataSource=ankara.sdf");
            CeConn.Open();

            DateTime IrsaliyeTarihi = dc.Getdate;
            Int64 SipNo = 0;

            string dt = DateTime.Now.ToString("MM/dd/yyyy");
            string Irsdt = IrsaliyeTarihi.ToString("MM/dd/yyyy");
            string sql = "insert into " + tabloAd +
                "(Musteri_Kodu, Belge_No, Tur, Musteri_Adi, Plasiyer_Kodu,Siparis_Tarihi, Teslim_Tarihi, " +
                " Vade_Gunu, Odeme_Sekli, Teslim_Alan)" +
                " VALUES (" +
                " '" + carino.Text + "'," +
                " '" + txtIrsaliyeNo.Text + "'," +
                " '" + Tur + "'," +
                " '" + label7.Text + "'," +
                " '" + label8.Text + "'," +
                " '" + dt + "'," +
                " '" + Irsdt + "',1,'k'," +
                " '" + comboBox2.Text + "')";

            try
            {
                SqlCeCommand cmd = new SqlCeCommand(sql, CeConn);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select @@identity";
                SipNo = Convert.ToInt64(cmd.ExecuteScalar().ToString());

                SiparisNo = SipNo;
            }
            finally
            {
                CeConn.Close();
            }

            DetayKaydet dk = new DetayKaydet(SipNo, label8.Text, tabloAd, false, Tur, Convert.ToInt64(txtIrsaliyeNo.Text));
            dk.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
