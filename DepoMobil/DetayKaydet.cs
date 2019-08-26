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
    /// Summary description for DetayKaydet.
    /// </summary>
    public class DetayKaydet : System.Windows.Forms.Form
    {
        private Button button4;
        private ComboBox comboBox1;
        private Button button3;
        private Button button2;
        private Button button1;
        private CheckBox chkBirim;
        private Button btnOnayla;
        private Button btnSil;
        private Button btnKapat;
        private ComboBox cmbBirim;
        private TextBox txtMiktar;
        private Label label3;
        private Label label1;
        private TextBox txtBarkod;
        SqlCeConnection CeConn = new SqlCeConnection("DataSource=ankara.sdf");
        Int64 SiparisNo;
        string PlasiyerKodu;
        string tabloAd;
        bool Grid;
        private Button button5;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        bool Goster;
        private Label label2;
        Int64 SecilenSipDetayNo = -1;
        string Tur;
        Int64 BelgeNo;

        public DetayKaydet(Int64 SiparisNo, string PlasiyerKodu, string tabloAd, bool Grid, string Tur, Int64 BelgeNo)
        {
            this.SiparisNo = SiparisNo;
            this.PlasiyerKodu = PlasiyerKodu;
            this.tabloAd = tabloAd;
            this.Grid = Grid;
            this.Tur = Tur;
            this.BelgeNo = BelgeNo;

            InitializeComponent();

            if (Grid == true)
            {
                ListeDoldurEskiBelgeNo();
            }
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
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkBirim = new System.Windows.Forms.CheckBox();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnKapat = new System.Windows.Forms.Button();
            this.cmbBirim = new System.Windows.Forms.ComboBox();
            this.txtMiktar = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBarkod = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label2 = new System.Windows.Forms.Label();
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 80);
            this.button4.Size = new System.Drawing.Size(71, 17);
            this.button4.Text = "Ekle";
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.comboBox1.Location = new System.Drawing.Point(7, 100);
            this.comboBox1.Size = new System.Drawing.Size(228, 19);
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(124, 272);
            this.button3.Size = new System.Drawing.Size(58, 18);
            this.button3.Text = "Stok Ara";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(64, 272);
            this.button2.Size = new System.Drawing.Size(58, 18);
            this.button2.Text = "Sýralý Liste";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(4, 272);
            this.button1.Size = new System.Drawing.Size(58, 18);
            this.button1.Text = "Toplu Liste";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkBirim
            // 
            this.chkBirim.Checked = true;
            this.chkBirim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBirim.Location = new System.Drawing.Point(127, 77);
            this.chkBirim.Size = new System.Drawing.Size(100, 17);
            this.chkBirim.Text = "Koli Birim";
            // 
            // btnOnayla
            // 
            this.btnOnayla.Enabled = false;
            this.btnOnayla.Location = new System.Drawing.Point(163, 100);
            this.btnOnayla.Size = new System.Drawing.Size(72, 20);
            this.btnOnayla.Text = "Onayla";
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(85, 100);
            this.btnSil.Size = new System.Drawing.Size(72, 20);
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Location = new System.Drawing.Point(7, 100);
            this.btnKapat.Size = new System.Drawing.Size(72, 20);
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // cmbBirim
            // 
            this.cmbBirim.Items.Add("Birim");
            this.cmbBirim.Items.Add("Birim");
            this.cmbBirim.Location = new System.Drawing.Point(130, 55);
            this.cmbBirim.Size = new System.Drawing.Size(100, 22);
            this.cmbBirim.SelectedIndexChanged += new System.EventHandler(this.cmbBirim_SelectedIndexChanged);
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(64, 56);
            this.txtMiktar.MaxLength = 10;
            this.txtMiktar.Size = new System.Drawing.Size(54, 21);
            this.txtMiktar.TextChanged += new System.EventHandler(this.txtMiktar_TextChanged);
            this.txtMiktar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMiktar_KeyPress);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.Text = "Miktar";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 4);
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.Text = "Barkod";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(64, 3);
            this.txtBarkod.Size = new System.Drawing.Size(166, 21);
            this.txtBarkod.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button5.Location = new System.Drawing.Point(184, 272);
            this.button5.Size = new System.Drawing.Size(52, 18);
            this.button5.Text = "Kontrol";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(7, 122);
            this.listView1.Size = new System.Drawing.Size(227, 146);
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sicil Adý";
            this.columnHeader1.Width = 140;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Miktar";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Birim";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "sdn";
            this.columnHeader4.Width = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Size = new System.Drawing.Size(229, 26);
            this.label2.Text = "Ürün Adý";
            // 
            // DetayKaydet
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkBirim);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.cmbBirim);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarkod);
            this.Location = new System.Drawing.Point(0, 0);
            this.Text = "DetayKaydet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DetayKaydet_Load);

        }

        #endregion

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                CeConn.Open();

                string SelectSQL = "SELECT * FROM Barkod WHERE Barkod_kodu = '" + txtBarkod.Text + "'";
                SqlCeCommand cmdBarkod = new SqlCeCommand(SelectSQL, CeConn);

                SqlCeDataReader drBarkod;
                try
                {
                    drBarkod = cmdBarkod.ExecuteReader();

                    if (drBarkod.Read())
                    {
                        
                        label2.Text = drBarkod["Sicil_Adi"].ToString();
                        string GrupKodu = drBarkod["Grup_Kodu"].ToString();
                        string SicilKodu = drBarkod["Sicil_Kodu"].ToString();

                        BirimComboDoldur(GrupKodu, SicilKodu);
                        txtMiktar.Text = "1";
                        txtMiktar.Focus();
                        txtMiktar.SelectAll();
                        btnOnayla.Enabled = true;
                    }
                    else
                    {
                        label2.Text = "";
                        MessageBox.Show("Okunan barkod degeri tanýmsýz !");
                        txtBarkod.Text = "";
                        txtBarkod.Focus();
                    }
                }
                finally
                {
                    CeConn.Close();
                }


                if (chkBirim.Checked)
                {
                    cmbBirim.SelectedIndex = 1;
                }
                else
                {
                    cmbBirim.SelectedIndex = 0;
                }
            }
        }

        private void BirimComboDoldur(string GrupKodu, string SicilKodu)
        {
            string SelectSQL = "SELECT * FROM Stok WHERE GRUP_KODU = '" + GrupKodu.Trim() + "' AND SICIL_KODU = '" + SicilKodu.Trim() + "'";
            SqlCeCommand cmdBirimDoldur = new SqlCeCommand(SelectSQL, CeConn);

            SqlCeDataReader drBirimDoldur;
            drBirimDoldur = cmdBirimDoldur.ExecuteReader();

            cmbBirim.Items.Clear();
            while (drBirimDoldur.Read())
            {
                cmbBirim.Items.Add(drBirimDoldur["Birim"].ToString());
                cmbBirim.Items.Add(drBirimDoldur["Birim1A"].ToString());
            }
        }

        private void chkBirim_Click(object sender, EventArgs e)
        {
            if (chkBirim.Checked)
            {
                chkBirim.Text = "Koli Birim";
            }
            else
            {
                chkBirim.Text = "Adet Birim";
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            if (txtBarkod.Text == "" || txtMiktar.Text == "" || cmbBirim.Text == "")
            {
                MessageBox.Show("Tüm alanlarý doldurunuz.");
            }
            else
            {
                Int64 vade = 0;
                try
                {
                    vade = Convert.ToInt64(txtMiktar.Text);
                }
                catch
                {
                    MessageBox.Show("Miktar alanýna sayýsal bir deðer girilmelidir");
                    return;
                }

                CeConn.Open();

                string SelectSQL = "SELECT * FROM Barkod WHERE Barkod_kodu = '" + txtBarkod.Text + "'";
                SqlCeCommand cmdBarkod = new SqlCeCommand(SelectSQL, CeConn);

                SqlCeDataReader drBarkod;
                try
                {
                    drBarkod = cmdBarkod.ExecuteReader();

                    if (drBarkod.Read())
                    {
                        string GrupKodu = drBarkod["Grup_kodu"].ToString();
                        string SicilKodu = drBarkod["Sicil_kodu"].ToString();
                        InsertIrsaliyeDetay(GrupKodu, SiparisNo, SicilKodu, PlasiyerKodu, label2.Text,
                            Convert.ToDouble(txtMiktar.Text), cmbBirim.Text, txtBarkod.Text);
                    }
                }
                finally
                {
                    CeConn.Close();
                }

                btnOnayla.Enabled = false;
                ListeDoldur();
                label2.Text = "";
                txtBarkod.Text = "";
                txtMiktar.Text = "";
                txtBarkod.Focus();
            }
        }

        private void InsertIrsaliyeDetay(string GrupKodu,
                                          Int64 SiparisNo,
                                          string SicilKodu,
                                          string PlasiyerKodu,
                                          string SicilAdi,
                                          double Miktar,
                                          string Birim,
                                          string Barkod)
        {
            string InsertSQL = "INSERT INTO " + tabloAd + "Detay(grup_kodu,siparis_no,Tur,sicil_kodu,plasiyer_kodu,sicil_adi,Miktar,birim,birim_fiyat,Tutar,iskonto1,iskonto2,iskonto3,iskonto4,iskonto5,kolimiktar,Belge_No) " +
                "VALUES(" +
                "'" + GrupKodu.Trim() + "'," +
                "" + SiparisNo + "," +
                "'" + Tur + "'," +
                "'" + SicilKodu.Trim() + "'," +
                "'" + PlasiyerKodu.Trim() + "'," +
                "'" + SicilAdi.Trim() + "'," +
                "" + Miktar + "," +
                "'" + Birim.Trim() + "'," +
                "0,0,0,0,0,0,0," +
                "'" + Barkod + "'," +
                " " + BelgeNo + ")";

            SqlCeCommand cmd = new SqlCeCommand(InsertSQL, CeConn);
            cmd.ExecuteNonQuery();

            cmd.Dispose();

        }

        private void ListeDoldur()
        {
            CeConn.Open();

            string SelectSQL = "SELECT sicil_adi,Miktar,birim,kolimiktar,siparisdetay_no FROM " + tabloAd + "Detay " +
                               "WHERE siparis_no = " + SiparisNo;
            SqlCeCommand cmd = new SqlCeCommand(SelectSQL, CeConn);

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();
                listView1.Items.Clear();
                while (dr.Read())
                {
                    // Listview içeriðini doldur
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = dr["sicil_adi"].ToString();
                    lvi.SubItems.Add(dr["Miktar"].ToString());
                    lvi.SubItems.Add(dr["birim"].ToString());
                    lvi.SubItems.Add(dr["siparisdetay_no"].ToString());

                    listView1.Items.Add(lvi);
                }
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void ListeDoldurEskiBelgeNo()
        {
            CeConn.Open();

            string SelectSQL = "SELECT sicil_adi,Miktar,birim,kolimiktar,siparisdetay_no FROM " + tabloAd + "Detay " +
                               "WHERE Belge_No = " + BelgeNo;
            SqlCeCommand cmd = new SqlCeCommand(SelectSQL, CeConn);

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();
                listView1.Items.Clear();
                while (dr.Read())
                {
                    // Listview içeriðini doldur
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = dr["sicil_adi"].ToString();
                    lvi.SubItems.Add(dr["Miktar"].ToString());
                    lvi.SubItems.Add(dr["birim"].ToString());
                    lvi.SubItems.Add(dr["siparisdetay_no"].ToString());

                    listView1.Items.Add(lvi);
                }
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (SecilenSipDetayNo > 0)
            {
                IrsaliyeDetaySil(SecilenSipDetayNo);
                ListeDoldur();
            }
            else
            {
                MessageBox.Show("Lütfen silinecek satýrý seçin.");
            }
        }

        public void IrsaliyeDetaySil(Int64 siparisdetay_no)
        {
            CeConn.Open();

            string sql = "DELETE FROM " + tabloAd + "Detay WHERE siparisdetay_no = " + siparisdetay_no;
            SqlCeCommand cmdDetaySil = new SqlCeCommand(sql, CeConn);

            try
            {
                cmdDetaySil.ExecuteNonQuery();
            }
            finally
            {
                CeConn.Close();
                SecilenSipDetayNo = -1;
            }
        }

        private Int64 DetayKayitVarMi(Int64 KayitNo)
        {
            CeConn.Open();

            string sql = "SELECT COUNT(*) FROM " + tabloAd + "Detay WHERE siparis_no = " + KayitNo;
            SqlCeCommand cmdDetaySil = new SqlCeCommand(sql, CeConn);

            Int64 KayitSay = 0;
            try
            {
                KayitSay = Convert.ToInt64(cmdDetaySil.ExecuteScalar().ToString());
            }
            finally
            {
                CeConn.Close();
            }

            return KayitSay;
        }

        private void BaslikSil(Int64 BaslikNo)
        {
            CeConn.Open();

            string sql = "DELETE FROM " + tabloAd + " WHERE siparis_no = " + BaslikNo;
            SqlCeCommand cmdBaslikSil = new SqlCeCommand(sql, CeConn);

            try
            {
                cmdBaslikSil.ExecuteNonQuery();
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            if (DetayKayitVarMi(SiparisNo) < 1)
                BaslikSil(SiparisNo);

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            topluliste toplu = new topluliste(tabloAd, SiparisNo);
            toplu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            siraliliste sirali = new siraliliste(tabloAd, SiparisNo);
            sirali.Show();
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                if (txtBarkod.Text == "" || txtMiktar.Text == "" || cmbBirim.Text == "")
                {
                    MessageBox.Show("Tüm alanlarý doldurunuz.");
                }
                else
                {
                    Int64 vade = 0;
                    try
                    {
                        vade = Convert.ToInt64(txtMiktar.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Miktar alanýna sayýsal bir deðer girilmelidir");
                        return;
                    }

                    CeConn.Open();

                    string SelectSQL = "SELECT * FROM Barkod WHERE Barkod_kodu = '" + txtBarkod.Text + "'";
                    SqlCeCommand cmdBarkod = new SqlCeCommand(SelectSQL, CeConn);

                    SqlCeDataReader drBarkod;
                    try
                    {
                        drBarkod = cmdBarkod.ExecuteReader();

                        if (drBarkod.Read())
                        {
                            string GrupKodu = drBarkod["Grup_kodu"].ToString();
                            string SicilKodu = drBarkod["Sicil_kodu"].ToString();
                            InsertIrsaliyeDetay(GrupKodu, SiparisNo, SicilKodu, PlasiyerKodu, label2.Text,
                                Convert.ToDouble(txtMiktar.Text), cmbBirim.Text, txtBarkod.Text);
                        }


                        btnOnayla.Enabled = false;
                    }
                    finally
                    {
                        CeConn.Close();
                    }

                    ListeDoldur();
                    label2.Text = "";
                    txtBarkod.Text = "";
                    txtMiktar.Text = "";
                    txtBarkod.Focus();

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Goster == true)
            {
                comboBox1.Visible = true;
                button4.Visible = true;
                Goster = false;
                button3.Enabled = false;

                CeConn.Open();

                string sql = "SELECT * FROM stok WHERE GRUP_KODU NOT LIKE 'ZY' ORDER BY sicil_adi ";
                SqlCeCommand cmdStok = new SqlCeCommand(sql, CeConn);

                SqlCeDataReader drStok;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    drStok = cmdStok.ExecuteReader();
                    while (drStok.Read())
                    {
                        comboBox1.Items.Add(drStok["sicil_adi"].ToString());
                    }

                }
                finally
                {
                    CeConn.Close();
                    Cursor.Current = Cursors.Default;
                    button3.Enabled = true;
                }
            }
            else
            {
                comboBox1.Visible = false;
                button4.Visible = false;
                Goster = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = comboBox1.Text;
            CeConn.Open();

            string sql = "SELECT * FROM stok WHERE sicil_adi = '" + comboBox1.Text + "'";
            SqlCeCommand cmdStok = new SqlCeCommand(sql, CeConn);

            SqlCeDataReader drStok;
            try
            {
                drStok = cmdStok.ExecuteReader();
                if (drStok.Read())
                {
                    string GrupKodu = drStok["Grup_kodu"].ToString();
                    string SicilKodu = drStok["Sicil_kodu"].ToString();

                    BirimComboDoldur(GrupKodu, SicilKodu);
                }

            }
            finally
            {
                CeConn.Close();
            }

            if (chkBirim.Checked)
            {
                cmbBirim.SelectedIndex = 1;
            }
            else
            {
                cmbBirim.SelectedIndex = 0;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || txtMiktar.Text == "" || cmbBirim.Text == "")
            {
                MessageBox.Show("Tüm alanlarý doldurunuz.");
            }
            else
            {
                Int64 vade = 0;
                try
                {
                    vade = Convert.ToInt64(txtMiktar.Text);
                }
                catch
                {
                    MessageBox.Show("Miktar alanýna sayýsal bir deðer girilmelidir");
                    return;
                }

                CeConn.Open();

                string sql = "SELECT * FROM stok WHERE sicil_adi = '" + comboBox1.Text + "'";
                SqlCeCommand cmdStok = new SqlCeCommand(sql, CeConn);

                SqlCeDataReader drStok;
                try
                {
                    drStok = cmdStok.ExecuteReader();
                    if (drStok.Read())
                    {
                        string GrupKodu = drStok["Grup_kodu"].ToString();
                        string SicilKodu = drStok["Sicil_kodu"].ToString();
                        InsertIrsaliyeDetay(GrupKodu, SiparisNo, SicilKodu, PlasiyerKodu, label2.Text,
                            Convert.ToDouble(txtMiktar.Text), cmbBirim.Text, txtBarkod.Text);
                    }
                }
                finally
                {
                    CeConn.Close();
                }

                ListeDoldur();
                label2.Text = "";
                txtBarkod.Text = "";
                txtMiktar.Text = "";
                txtBarkod.Focus();
            }
        }

        private void DetayKaydet_Load(object sender, EventArgs e)
        {
            txtBarkod.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StokKontrol sk = new StokKontrol();
            sk.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listView1.SelectedIndices.Count <= 0)
                return;

            int selNdx = this.listView1.SelectedIndices[0];
            SecilenSipDetayNo = Convert.ToInt64(listView1.Items[selNdx].SubItems[3].Text);
        }

        private void cmbBirim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBirim.Text != "KOLÝ")
            {
                MessageBox.Show("Ana birim seçildi.");
                txtMiktar.Focus();
                txtMiktar.SelectAll();
            }
        }

        private void txtMiktar_TextChanged(object sender, EventArgs e)
        {
            int uzunluk = txtMiktar.Text.Length;

            if (uzunluk > 4)
            {
                MessageBox.Show("Geçersiz miktar giriþi");
                txtMiktar.Focus();
                txtMiktar.Text = "";
            }
        }
    }
}
