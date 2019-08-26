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
    /// Summary description for YuklemeDetay.
    /// </summary>
    public class YuklemeDetay : System.Windows.Forms.Form
    {
        private ColumnHeader columnHeader1;
        private Button Kapat;
        private ListView listView1;
        private ColumnHeader columnHeader2;
        private Button button1;
        private ComboBox comboBox1;
        private ColumnHeader columnHeader3;
        int KayitDetayNo;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private Button button2;
        private ContextMenu contextMenu1;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private TextBox textBox1;
        string DetayTabloAd;
        SqlCeConnection ConnCe = new SqlCeConnection("DataSource=ankara.sdf");

        public YuklemeDetay(string DetayTabloAd, int KayitDetayNo)
        {
            this.DetayTabloAd = DetayTabloAd;
            this.KayitDetayNo = KayitDetayNo;
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
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.Kapat = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Detay No";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 85;
            // 
            // Kapat
            // 
            this.Kapat.Location = new System.Drawing.Point(186, 269);
            this.Kapat.Size = new System.Drawing.Size(51, 22);
            this.Kapat.Text = "Kapat";
            this.Kapat.Click += new System.EventHandler(this.Kapat_Click_1);
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader5);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Size = new System.Drawing.Size(234, 242);
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Durumu";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Durum";
            this.columnHeader5.Width = 60;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Saat";
            this.columnHeader3.Width = 45;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(104, 269);
            this.button1.Size = new System.Drawing.Size(76, 22);
            this.button1.Text = "Geri Döndü";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Items.Add("Geri Döndü");
            this.comboBox1.Items.Add("Sipariþi Yok");
            this.comboBox1.Items.Add("Ödeme Yapmadý");
            this.comboBox1.Items.Add("Malý Almadý");
            this.comboBox1.Items.Add("Ýadesi Var");
            this.comboBox1.Items.Add("Sevk Edildi");
            this.comboBox1.Location = new System.Drawing.Point(3, 269);
            this.comboBox1.Size = new System.Drawing.Size(100, 22);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(22, 247);
            this.button2.Size = new System.Drawing.Size(196, 20);
            this.button2.Text = "Sevkiyatý Tamamla";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.Add(this.menuItem1);
            this.contextMenu1.MenuItems.Add(this.menuItem2);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Satýr Sil";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Text = "Satýr Ekle";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(71, 81);
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.Visible = false;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // YuklemeDetay
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Kapat);
            this.Controls.Add(this.listView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Text = "YuklemeDetay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.YuklemeDetay_Load);

        }

        #endregion

        private void DetayGetir()
        {
            ConnCe.Open();

            string Sql = "SELECT * FROM Sevkiyat WHERE YuklemeNo=" + KayitDetayNo;
            SqlCeCommand cmdDetay = new SqlCeCommand(Sql, ConnCe);

            SqlCeDataReader drDetay;

            try
            {
                drDetay = cmdDetay.ExecuteReader();
                listView1.Items.Clear();
                while (drDetay.Read())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = drDetay["Fatura_No"].ToString();
                    lvi.SubItems.Add(drDetay["Sevk_Durumu"].ToString());
                    lvi.SubItems.Add(drDetay["Durum"].ToString());
                    lvi.SubItems.Add(drDetay["DonusSaat"].ToString());
                    lvi.SubItems.Add(drDetay["RecNo"].ToString());
                    listView1.Items.Add(lvi);
                }
            }
            finally
            {
                ConnCe.Close();
            }
        }

        private void SevkTablosunuGuncelle(string DonusDurumu, string RecNo)
        {
            try
            {
                ConnCe.Open();
                string UpdateSql = "UPDATE Sevkiyat SET Durum = '" + DonusDurumu + "' WHERE RecNo = " + RecNo;
                SqlCeCommand cmdDetay = new SqlCeCommand(UpdateSql, ConnCe);

                cmdDetay.ExecuteNonQuery();
            }
            finally
            {
                ConnCe.Close();
            }
        }

        private void YuklemeDetay_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            DetayGetir();
        }

        private void Kapat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                int selNdx = listView1.SelectedIndices[0];
                SevkTablosunuGuncelle(comboBox1.Text, listView1.Items[selNdx].SubItems[4].Text);

                DetayGetir();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            DialogResult dr = MessageBox.Show("Dönüþ kaydý yapmak istediðinize emin misiniz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question,
			MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    ConnCe.Open();
                    string UpdateSql = "UPDATE Sevkiyat SET Durum = 'Sevk Edildi' WHERE (Durum IS NULL) AND YuklemeNo = " + KayitDetayNo;
                    SqlCeCommand cmdDetay = new SqlCeCommand(UpdateSql, ConnCe);
                    cmdDetay.ExecuteNonQuery();

                    String DonusSaat = DateTime.Now.ToShortTimeString();
                    string UpdateSql2 = "UPDATE Sevkiyat SET DonusSaat = '" + DonusSaat + "' WHERE YuklemeNo = " + KayitDetayNo;
                    cmdDetay.CommandText = UpdateSql2;
                    cmdDetay.ExecuteNonQuery();
                }
                finally
                {
                    ConnCe.Close();
                }

                DetayGetir();
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count < 1)
            {
                MessageBox.Show("Rut seçimi yapýn");
                return;
            }

            DialogResult dr = MessageBox.Show("Kaydý silmek istediðinize emin misiniz?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    int selNdx = listView1.SelectedIndices[0];
                    int SecilenNo = Convert.ToInt32(listView1.Items[selNdx].Text);

                    ConnCe.Open();

                    string DeleteSQL = "DELETE FROM Sevkiyat WHERE Fatura_No = " + SecilenNo;
                    SqlCeCommand cmd = new SqlCeCommand(DeleteSQL, ConnCe);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Kayýt Silindi !");
                }
                finally
                {
                    ConnCe.Close();
                    DetayGetir();
                }
            }
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count < 1)
            {
                MessageBox.Show("Rut seçimi yapýn");
                return;
            }
            listView1.Enabled = false;
            textBox1.Visible = true;
            textBox1.Focus();
            textBox1.Text = "";
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                ConnCe.Open();
                string Sql = "SELECT Count(*) FROM Sevkiyat WHERE Fatura_No=" + FaturaNo;
                SqlCeCommand cmdYukNo = new SqlCeCommand(Sql, ConnCe);

                int FaturaNoSayisi = Convert.ToInt32(cmdYukNo.ExecuteScalar().ToString());

                if (FaturaNoSayisi > 0)
                {
                    Kontrol = false;
                    MessageBox.Show("Bu Fatura No Listeye Eklenmiþ.");
                    textBox1.Focus();
                    textBox1.SelectAll();
                }

            }
            finally
            {
                ConnCe.Close();
            }

            return Kontrol;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                Int64 FaturaNo;

                if (textBox1.Text == "")
                {
                    textBox1.Visible = false;
                    listView1.Enabled = true;
                    return;
                }

                if (ListedeVarMi(textBox1.Text) == false)
                {                    
                    return; 
                }

                if (SayisalMi(textBox1.Text) == true)
                    FaturaNo = Convert.ToInt32(textBox1.Text);
                else
                    return;

                int selNdx = listView1.SelectedIndices[0];
                int SecilenNo = Convert.ToInt32(listView1.Items[selNdx].Text);

                ConnCe.Open();

                string SelectSQL = "SELECT * FROM Sevkiyat WHERE Fatura_No = " + SecilenNo;
                SqlCeCommand cmd = new SqlCeCommand(SelectSQL, ConnCe);

                try
                {
                    SqlCeDataReader dr;
                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        SevkiyatYaz(dr["yuklemeno"].ToString(),
                                    dr["arac"].ToString(),
                                    dr["sef"].ToString(),
                                    dr["sofor"].ToString(),
                                    dr["muavin"].ToString(),
                                    Convert.ToDouble(dr["cikisKM"].ToString()),
                                    Convert.ToDouble(dr["donusKM"].ToString()),
                                    dr["cikisSaat"].ToString(),
                                    dr["donusSaat"].ToString(),
                                    dr["SevkiyatTarihi"].ToString(),
                                    FaturaNo,
                                    "Sevkiyatta");
                    }
                }
                finally
                {
                    ConnCe.Close();
                    textBox1.Visible = false;
                    listView1.Enabled = true;
                }
                DetayGetir();
            }
        }

        private void SevkiyatYaz(string YuklemeNo, string Arac, string Sef, string Sofor, string Muavin, double CikisKM, double DonusKM, string CikisSaat, string DonusSaat, string SevkiyatTarihi, Int64 Fatura_No, string Sevk_Durumu)
        {
            DateTime st = Convert.ToDateTime(SevkiyatTarihi);
            string sevkTar = st.ToString("yyyy-MM-dd");

            string Sql = "INSERT INTO Sevkiyat(YuklemeNo,Arac,Sef,Sofor,Muavin,CikisKM,DonusKM,CikisSaat,DonusSaat,SevkiyatTarihi,Fatura_No,Sevk_Durumu) VALUES (" +
                "" + YuklemeNo + "," +
                "'" + Arac + "'," +
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

            SqlCeCommand cmd = new SqlCeCommand(Sql, ConnCe);
            cmd.ExecuteNonQuery();
        }
    }
}
