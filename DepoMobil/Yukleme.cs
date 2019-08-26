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
    /// Summary description for Yukleme.
    /// </summary>
    public class Yukleme : System.Windows.Forms.Form
    {
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label5;
        private ListBox listBox1;
        private TextBox textBox5;
        private Label label4;
        private Label label6;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Button button1;
        private Label label1;
        SqlCeConnection CeConn = new SqlCeConnection("DataSource=ankara.sdf");
        Config config = new Config();
        SqlCeTransaction tr;
        bool BaslikKaydedilsinMi = true;
        Int64 BaslikNo = -1;
        bool txtDurum1 = false;
        bool txtDurum5 = false;
        bool txtDurum2 = false;
        private TextBox textBox6;
        private Label label16;
        private Button button2;
        private Label label17;
        private Label label18;
        private Label label19;
        bool txtDurum3 = false;

        public Yukleme()
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(10, 1);
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.Text = "Araç :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.Text = "Þoför :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(-2, 69);
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.Text = "Muavin :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.textBox1.Location = new System.Drawing.Point(60, 3);
            this.textBox1.Size = new System.Drawing.Size(56, 18);
            this.textBox1.Text = "06 TTE 05";
            this.textBox1.LostFocus += new System.EventHandler(this.textBox1_LostFocus);
            this.textBox1.GotFocus += new System.EventHandler(this.textBox1_GotFocus);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.textBox2.Location = new System.Drawing.Point(60, 43);
            this.textBox2.Size = new System.Drawing.Size(56, 18);
            this.textBox2.Text = "1";
            this.textBox2.LostFocus += new System.EventHandler(this.textBox2_LostFocus);
            this.textBox2.GotFocus += new System.EventHandler(this.textBox2_GotFocus);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.textBox3.Location = new System.Drawing.Point(60, 63);
            this.textBox3.Size = new System.Drawing.Size(56, 18);
            this.textBox3.Text = "1";
            this.textBox3.LostFocus += new System.EventHandler(this.textBox3_LostFocus);
            this.textBox3.GotFocus += new System.EventHandler(this.textBox3_GotFocus);
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.textBox4.ForeColor = System.Drawing.Color.Red;
            this.textBox4.Location = new System.Drawing.Point(60, 87);
            this.textBox4.Size = new System.Drawing.Size(103, 19);
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox4_KeyPress);
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(-2, 87);
            this.label5.Size = new System.Drawing.Size(44, 20);
            this.label5.Text = "Ft.No :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listBox1
            // 
            this.listBox1.Location = new System.Drawing.Point(8, 112);
            this.listBox1.Size = new System.Drawing.Size(105, 170);
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.textBox5.Location = new System.Drawing.Point(60, 23);
            this.textBox5.Size = new System.Drawing.Size(56, 18);
            this.textBox5.Text = "1";
            this.textBox5.LostFocus += new System.EventHandler(this.textBox5_LostFocus);
            this.textBox5.GotFocus += new System.EventHandler(this.textBox5_GotFocus);
            this.textBox5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox5_KeyPress);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(8, 23);
            this.label4.Size = new System.Drawing.Size(34, 18);
            this.label4.Text = "Þef :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(169, 89);
            this.label6.Size = new System.Drawing.Size(42, 18);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label11.Location = new System.Drawing.Point(119, 3);
            this.label11.Size = new System.Drawing.Size(118, 18);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label12.Location = new System.Drawing.Point(119, 23);
            this.label12.Size = new System.Drawing.Size(118, 18);
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label13.Location = new System.Drawing.Point(119, 63);
            this.label13.Size = new System.Drawing.Size(118, 18);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label14.Location = new System.Drawing.Point(119, 43);
            this.label14.Size = new System.Drawing.Size(118, 18);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 192);
            this.button1.Size = new System.Drawing.Size(73, 18);
            this.button1.Text = "Kapat";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(180, 109);
            this.textBox6.Size = new System.Drawing.Size(57, 21);
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label16.Location = new System.Drawing.Point(119, 112);
            this.label16.Size = new System.Drawing.Size(55, 18);
            this.label16.Text = "Kilometre :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 166);
            this.button2.Size = new System.Drawing.Size(73, 20);
            this.button2.Text = "Sil";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label17.Location = new System.Drawing.Point(113, 134);
            this.label17.Size = new System.Drawing.Size(61, 18);
            this.label17.Text = "Yükleme No :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.label18.Location = new System.Drawing.Point(180, 134);
            this.label18.Size = new System.Drawing.Size(61, 18);
            this.label18.Text = "Ft.Say :";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(153, 213);
            this.label19.Size = new System.Drawing.Size(74, 20);
            this.label19.Text = "label19";
            this.label19.Visible = false;
            // 
            // Yukleme
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Text = "Yukleme";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Yukleme_Load);

        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private string BilgiGetir(string Arama)
        {
            CeConn.Open();

            string Sql = "SELECT * FROM SevkAyar WHERE Kod = '"+ Arama + "'";
            SqlCeCommand cmd = new SqlCeCommand(Sql, CeConn);

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    return dr["AD"].ToString();
                else
                    return "bos";
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void SevkiyatYaz(string Arac, string Sef, string Sofor, string Muavin, double CikisKM, double DonusKM, string CikisSaat, string DonusSaat, string SevkiyatTarihi, Int64 Fatura_No, string Sevk_Durumu, string plaka)
        {
            

            DateTime st = Convert.ToDateTime(SevkiyatTarihi);
            string sevkTar = st.ToString("yyyy-MM-dd");

            string Sql = "INSERT INTO Sevkiyat(YuklemeNo,Arac,Sef,Sofor,Muavin,CikisKM,DonusKM,CikisSaat,DonusSaat,SevkiyatTarihi,Fatura_No,Sevk_Durumu) VALUES (" +
                "" + label18.Text + "," +
                "'" + plaka + "'," +
                "'" + Sef + "'," +
                "'" + Sofor + "'," +
                "'" + Muavin + "'," +
                "" + CikisKM + "," +
                "" + DonusKM + "," +
                "'" + CikisSaat + "'," +
                "'" + DonusSaat + "'," +
                "'" + sevkTar + "'," +
                "" + Fatura_No + "," +
                "'" + Sevk_Durumu + "')";

            SqlCeCommand cmd = new SqlCeCommand(Sql, CeConn);
            cmd.Transaction = tr;
            cmd.ExecuteNonQuery();
        }

        private bool Terminated(string Value)
        {
            bool sonuc;
            if (Value.EndsWith("#"))
            {
                sonuc = true;
            }
            else
            {
                sonuc = false;
            }

            return sonuc;

        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                try
                {
                    string FaturaNo = textBox4.Text;
                    if (ListedeVarMi(FaturaNo) == false) return;
                    if (SayisalMi(FaturaNo) == true)
                    {
                        int Km = 0;
                        string CikisSaat = label19.Text;

                        if (SayisalMi(textBox6.Text) == true) 
                            Km = Convert.ToInt32(textBox6.Text);
                        else
                            return;

                        CeConn.Open();
                        tr = CeConn.BeginTransaction();

                        SevkiyatYaz(label11.Text, label12.Text, label14.Text, label13.Text, Km, 0,
                            CikisSaat, "00:00", DateTime.Now.ToString(), Convert.ToInt64(FaturaNo), "Sevkiyatta", textBox1.Text);
                            

                        tr.Commit();
                        EkranKitle();
                    }
                    textBox4.Focus();
                    textBox4.SelectAll();
                    textBox4.Text = "";
                }
                catch
                {
                    tr.Rollback();
                }
                finally
                {
                    CeConn.Close();
                }
                //Listboxa yeni fatura no ekle
                ListeDoldur();
            }
        }

        private void EkranKitle()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
        }

        private void ListeDoldur()
        {
            CeConn.Open();

            string Sql = "SELECT COUNT(*) FROM Sevkiyat WHERE YuklemeNo = " + label18.Text;
            SqlCeCommand cmd = new SqlCeCommand(Sql, CeConn);

            try
            {
                Int64 FaturaAdet = Convert.ToInt64(cmd.ExecuteScalar().ToString());
                label6.Text = FaturaAdet.ToString();

                cmd.CommandText = "SELECT Fatura_No FROM Sevkiyat WHERE YuklemeNo = " + label18.Text;

                SqlCeDataReader dr = cmd.ExecuteReader();

                listBox1.Items.Clear();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr["Fatura_No"].ToString());
                }
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                string Bilgi = BilgiGetir(textBox1.Text);
                if (Bilgi == "bos")
                {
                    MessageBox.Show("Kayýt Bulunamadý.");
                    textBox1.Focus();
                    textBox1.SelectAll();
                }
                else
                {
                    label11.Text = Bilgi;
                    txtDurum1 = true;
                    textBox5.Focus();
                    textBox5.SelectAll();
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                string Bilgi = BilgiGetir(textBox5.Text);
                if (Bilgi == "bos")
                {
                    MessageBox.Show("Kayýt Bulunamadý.");
                    textBox5.Focus();
                    textBox5.SelectAll();
                }
                else
                {
                    label12.Text = Bilgi;
                    txtDurum5 = true;
                    textBox2.Focus();
                    textBox2.SelectAll();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                string Bilgi = BilgiGetir(textBox2.Text);
                if (Bilgi == "bos")
                {
                    MessageBox.Show("Kayýt Bulunamadý.");
                    textBox2.Focus();
                    textBox2.SelectAll();
                }
                else
                {
                    label14.Text = Bilgi;
                    txtDurum2 = true;
                    textBox3.Focus();
                    textBox3.SelectAll();
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                string Bilgi = BilgiGetir(textBox3.Text);
                if (Bilgi == "bos")
                {
                    MessageBox.Show("Kayýt Bulunamadý.");
                    textBox3.Focus();
                    textBox3.SelectAll();
                }
                else
                {
                    label13.Text = Bilgi;
                    txtDurum3 = true;
                    textBox6.Focus();
                    textBox6.SelectAll();
                }
            }
        }

        private bool SayisalMi(string deger)
        {
            int kontrol = 0;
            try
            {
                kontrol = Convert.ToInt32(deger);
            }
            catch
            {
                MessageBox.Show("Fatura no alanýna sayýsal bir deðer girilmelidir");
            }

            if (kontrol > 0)
                return true;
            else
                return false;
        }

        private bool ListedeVarMi(string FaturaNo)
        {
            bool Kontrol = true;
            try
            {
                CeConn.Open();
                string Sql = "SELECT Count(*) FROM Sevkiyat WHERE Fatura_No=" + FaturaNo;
                SqlCeCommand cmdYukNo = new SqlCeCommand(Sql, CeConn);

                int FaturaNoSayisi = Convert.ToInt32(cmdYukNo.ExecuteScalar().ToString());

                if (FaturaNoSayisi > 0)
                {
                    Kontrol = false;
                    MessageBox.Show("Bu Fatura No Listeye Eklenmiþ.");
                    textBox4.Focus();
                    textBox4.SelectAll();
                }
                
            }
            finally
            {
                CeConn.Close();
            }

            return Kontrol;
        }

        private void textBox1_LostFocus(object sender, EventArgs e)
        {
            if (txtDurum1 == false)
            {
                MessageBox.Show("Degeri kontrol ediniz.");
                textBox1.Focus();
                textBox1.SelectAll();
            }
        }

        private void Yukleme_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            textBox1.SelectAll();

            config.SetProertyes();
            label19.Text = DateTime.Now.ToShortTimeString();

            try
            {
                CeConn.Open();
                string Sql = "SELECT Max(YuklemeNo) + 1 AS SonYuklemeNo FROM Sevkiyat";
                SqlCeCommand cmdYukNo = new SqlCeCommand(Sql, CeConn);

                SqlCeDataReader drYuklemeNo;
                drYuklemeNo = cmdYukNo.ExecuteReader();
                drYuklemeNo.Read();

                if (drYuklemeNo["SonYuklemeNo"].ToString() != string.Empty)
                {
                    string YuklemeNo = drYuklemeNo["SonYuklemeNo"].ToString();
                    label18.Text = YuklemeNo;
                }
                else
                {
                    label18.Text = config.PDAKodu + "1";
                }
            }
            finally
            {
                CeConn.Close();
            }

        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            txtDurum1 = false;
        }

        private void textBox5_LostFocus(object sender, EventArgs e)
        {
            if (txtDurum5 == false)
            {
                MessageBox.Show("Degeri kontrol ediniz.");
                textBox5.Focus();
                textBox5.SelectAll();
            }
        }

        private void textBox5_GotFocus(object sender, EventArgs e)
        {
            txtDurum5 = false;
        }

        private void textBox2_LostFocus(object sender, EventArgs e)
        {
            if (txtDurum2 == false)
            {
                MessageBox.Show("Degeri kontrol ediniz.");
                textBox2.Focus();
                textBox2.SelectAll();
            }
        }

        private void textBox2_GotFocus(object sender, EventArgs e)
        {
            txtDurum2 = false;
        }

        private void textBox3_LostFocus(object sender, EventArgs e)
        {
            if (txtDurum3 == false)
            {
                MessageBox.Show("Degeri kontrol ediniz.");
                textBox3.Focus();
                textBox3.SelectAll();
            }
        }

        private void textBox3_GotFocus(object sender, EventArgs e)
        {
            txtDurum3 = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string FaturaNo = "";

            if (listBox1.SelectedIndex > -1)
            {
                FaturaNo = listBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Fatura Seçiniz");
                return;
            }

            CeConn.Open();

            string Sql = "DELETE FROM SevkDetay WHERE Fatura_No = " + FaturaNo + " AND " +
                "BaslikNo = "+ BaslikNo +" AND Sevk_Durumu = 'Sevk Edildi'";
            SqlCeCommand cmd = new SqlCeCommand(Sql, CeConn);

            try
            {
                // Item sil
                cmd.ExecuteNonQuery();
                
                //Listeyi Doldur
                cmd.CommandText = "SELECT Fatura_No FROM SevkDetay WHERE BaslikNo = " + BaslikNo;
                SqlCeDataReader dr = cmd.ExecuteReader();

                listBox1.Items.Clear();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr["Fatura_No"].ToString());
                }
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                textBox4.Focus();
                textBox4.SelectAll();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
