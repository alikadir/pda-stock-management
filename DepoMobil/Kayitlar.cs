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
    /// Summary description for Kayitlar.
    /// </summary>
    public class Kayitlar : System.Windows.Forms.Form
    {
        private Button button2;
        private Button button1;
        private ComboBox comboBox1;
        private Button button3;
        private ContextMenu contextMenu1;
        private MenuItem menuItem1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        string DetayTablo;

        public Kayitlar()
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 271);
            this.button2.Size = new System.Drawing.Size(72, 20);
            this.button2.Text = "Kapat";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 271);
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.Text = "Detay";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.Add(this.menuItem1);
            // 
            // menuItem1
            // 
            this.menuItem1.Text = "Sil";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Items.Add("Ýrsaliye");
            this.comboBox1.Items.Add("Ýade");
            this.comboBox1.Items.Add("Transfer");
            this.comboBox1.Items.Add("Sayim");
            this.comboBox1.Items.Add("Yükleme");
            this.comboBox1.Location = new System.Drawing.Point(2, 3);
            this.comboBox1.Size = new System.Drawing.Size(122, 22);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(155, 5);
            this.button3.Size = new System.Drawing.Size(72, 20);
            this.button3.Text = "Dönüþ";
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.Info;
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.Columns.Add(this.columnHeader5);
            this.listView1.Columns.Add(this.columnHeader6);
            this.listView1.ContextMenu = this.contextMenu1;
            this.listView1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.listView1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 31);
            this.listView1.Size = new System.Drawing.Size(234, 234);
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "No";
            this.columnHeader2.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Irs.Tarihi";
            this.columnHeader4.Width = 60;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Müþteri Adý";
            this.columnHeader1.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tür";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Teslim Tarihi";
            this.columnHeader5.Width = 60;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Teslim Alan";
            this.columnHeader6.Width = 60;
            // 
            // Kayitlar
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Text = "Kayitlar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ýrsaliye")
            {
                button3.Visible = false;
                BaslikGetir("Baslik", "Irsaliye");
                DetayTablo = "BaslikDetay";
            }
            else if (comboBox1.Text == "Ýade")
            {
                button3.Visible = false;
                BaslikGetir("Baslik", "Iade");
                DetayTablo = "BaslikDetay";
            }
            else if (comboBox1.Text == "Transfer")
            {
                button3.Visible = false;
                BaslikGetir("Baslik","Transfer");
                DetayTablo = "BaslikDetay";
            }
            else if (comboBox1.Text == "Sayim")
            {
                button3.Visible = false;
                BaslikGetir("Baslik", "Sayim");
                DetayTablo = "BaslikDetay";
            }
            else if (comboBox1.Text == "Yükleme")
            {
                button3.Visible = false;
                BaslikGetir("Sevkiyat", "");
                DetayTablo = "Sevkiyat";
            }
        }

        private void BaslikGetir(string TabloAd, string Tur)
        {
            SqlCeConnection ConnCe = new SqlCeConnection("DataSource=ankara.sdf");
            ConnCe.Open();

            string SelectSQL;

            if (TabloAd == "Sevkiyat")
            {
                SelectSQL = "SELECT DISTINCT YuklemeNo,Sofor,CikisSaat,DonusSaat,SevkiyatTarihi,Sef FROM " + TabloAd;
            }
            else
            {
                SelectSQL = "SELECT * FROM " + TabloAd + " WHERE Tur = '" + Tur + "'";
            }
            
            SqlCeCommand cmdBaslik = new SqlCeCommand(SelectSQL, ConnCe);

            SqlCeDataReader drBaslik;

            try
            {
                drBaslik = cmdBaslik.ExecuteReader();
                listView1.Items.Clear();


                if (TabloAd == "Sevkiyat")
                {
                    listView1.Columns[0].Text = "No";
                    listView1.Columns[1].Text = "Þoför";
                    listView1.Columns[2].Text = "Ç.Saat";
                    listView1.Columns[3].Text = "D.Saat";
                    listView1.Columns[4].Text = "S.Tarih";
                    listView1.Columns[5].Text = "Þef";

                    listView1.Columns[0].Width = 40;
                    listView1.Columns[1].Width = 70;
                    listView1.Columns[2].Width = 45;
                    listView1.Columns[3].Width = 45;
                    listView1.Columns[4].Width = 70;
                    listView1.Columns[5].Width = 60;

                    while (drBaslik.Read())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = drBaslik["YuklemeNo"].ToString();
                        lvi.SubItems.Add(drBaslik["Sofor"].ToString());
                        lvi.SubItems.Add(drBaslik["CikisSaat"].ToString());
                        lvi.SubItems.Add(drBaslik["DonusSaat"].ToString());
                        lvi.SubItems.Add(drBaslik["SevkiyatTarihi"].ToString());
                        lvi.SubItems.Add(drBaslik["Sef"].ToString());

                        listView1.Items.Add(lvi);
                    }
                }
                else
                {
                    listView1.Columns[0].Text = "No";
                    listView1.Columns[1].Text = "Tarih";
                    listView1.Columns[2].Text = "Cari Adý";
                    listView1.Columns[3].Text = "Tür";
                    listView1.Columns[4].Text = "T.Tarihi";
                    listView1.Columns[5].Text = "T.Alan";

                    listView1.Columns[0].Width = 40;
                    listView1.Columns[1].Width = 60;
                    listView1.Columns[2].Width = 110;
                    listView1.Columns[3].Width = 50;
                    listView1.Columns[4].Width = 60;
                    listView1.Columns[5].Width = 60;

                    while (drBaslik.Read())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = drBaslik["Siparis_No"].ToString();
                        lvi.SubItems.Add(drBaslik["Siparis_Tarihi"].ToString());
                        lvi.SubItems.Add(drBaslik["Musteri_Adi"].ToString());
                        lvi.SubItems.Add(drBaslik["Tur"].ToString());
                        lvi.SubItems.Add(drBaslik["Teslim_Tarihi"].ToString());
                        lvi.SubItems.Add(drBaslik["Teslim_Alan"].ToString());

                        listView1.Items.Add(lvi);
                    }
                }
            }
            finally
            {
                ConnCe.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                if (comboBox1.Text == "Yükleme")
                {
                    int selNdx = listView1.SelectedIndices[0];
                    YuklemeDetay YDetay = new YuklemeDetay(DetayTablo, Convert.ToInt32(listView1.Items[selNdx].Text));
                    YDetay.Show();
                }
                else
                {
                    int selNdx = listView1.SelectedIndices[0];
                    KayitlarDetay KDetay = new KayitlarDetay(DetayTablo, Convert.ToInt32(listView1.Items[selNdx].Text));
                    KDetay.Show();
                }
            }
            else
            {
                MessageBox.Show("Lütfen listelenecek satýrý seçin.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listView1.SelectedIndices.Count < 1)
            {
                MessageBox.Show("Rut seçimi yapýn");
                return;
            }

            DialogResult dr = MessageBox.Show("Dönüþ kaydý yapmak istediðinize emin misiniz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question,
			MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {

                int selNdx = listView1.SelectedIndices[0];
                int SecilenNo = Convert.ToInt32(listView1.Items[selNdx].Text);

                SqlCeConnection ConnCe = new SqlCeConnection("DataSource=ankara.sdf");
                ConnCe.Open();

                try
                {
                    String DonusSaat = DateTime.Now.ToShortTimeString();

                    string SQL1 = "UPDATE Sevkiyat SET DonusSaat = '" + DonusSaat + "' WHERE RecNo = " + SecilenNo;
                    SqlCeCommand cmd = new SqlCeCommand(SQL1, ConnCe);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Donus Kaydý Yapýldý !");
                }
                finally
                {
                    ConnCe.Close();
                }
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

                int selNdx = listView1.SelectedIndices[0];
                int SecilenNo = Convert.ToInt32(listView1.Items[selNdx].Text);

                SqlCeConnection ConnCe = new SqlCeConnection("DataSource=ankara.sdf");
                ConnCe.Open();

                string BaslikTabloSil = "";
                string DetayTabloSil = "";
                try
                {
                    if (comboBox1.Text == "Ýrsaliye")
                    {
                        BaslikTabloSil = "DELETE FROM Baslik WHERE Tur='Irsaliye' AND Siparis_no = " + SecilenNo;
                        DetayTabloSil = "DELETE FROM BaslikDetay WHERE Siparis_no = " + SecilenNo;
                    }
                    else if (comboBox1.Text == "Ýade")
                    {
                        BaslikTabloSil = "DELETE FROM Baslik WHERE Tur='Iade' AND Siparis_no = " + SecilenNo;
                        DetayTabloSil = "DELETE FROM BaslikDetay WHERE Siparis_no = " + SecilenNo;
                    }
                    else if (comboBox1.Text == "Transfer")
                    {
                        BaslikTabloSil = "DELETE FROM Baslik WHERE Tur='Transfer' AND Siparis_no = " + SecilenNo;
                        DetayTabloSil = "DELETE FROM BaslikDetay WHERE Siparis_no = " + SecilenNo;
                    }
                    else if (comboBox1.Text == "Sayim")
                    {
                        BaslikTabloSil = "DELETE FROM Baslik WHERE Tur='Sayim' AND Siparis_no = " + SecilenNo;
                        DetayTabloSil = "DELETE FROM BaslikDetay WHERE Siparis_no = " + SecilenNo;
                    }
                    else if (comboBox1.Text == "Yükleme")
                    {
                        BaslikTabloSil = "DELETE FROM Sevkiyat WHERE YuklemeNo = " + SecilenNo;
                        DetayTabloSil = "DELETE FROM Sevkiyat WHERE YuklemeNo = " + SecilenNo;
                    }


                    SqlCeCommand cmd = new SqlCeCommand(BaslikTabloSil, ConnCe);
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = DetayTabloSil;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Kayýt Silindi !");

                }
                finally
                {
                    ConnCe.Close();
                }

                if (comboBox1.Text == "Ýrsaliye")
                {
                    button3.Visible = false;
                    BaslikGetir("Baslik", "Irsaliye");
                    DetayTablo = "BaslikDetay";
                }
                else if (comboBox1.Text == "Ýade")
                {
                    button3.Visible = false;
                    BaslikGetir("Baslik", "Iade");
                    DetayTablo = "BaslikDetay";
                }
                else if (comboBox1.Text == "Transfer")
                {
                    button3.Visible = false;
                    BaslikGetir("Baslik", "Transfer");
                    DetayTablo = "BaslikDetay";
                }
                else if (comboBox1.Text == "Sayim")
                {
                    button3.Visible = false;
                    BaslikGetir("Baslik", "Sayim");
                    DetayTablo = "BaslikDetay";
                }
                else if (comboBox1.Text == "Yükleme")
                {
                    button3.Visible = true;
                    BaslikGetir("SevkBaslik", "");
                    DetayTablo = "SevkDetay";
                }
            }
        }
    }
}
