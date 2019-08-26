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
    /// Summary description for KayitlarDetay.
    /// </summary>
    public class KayitlarDetay : System.Windows.Forms.Form
    {
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader1;
        private ListView listView1;
        int KayitDetayNo;
        private Button Kapat;
        string DetayTabloAd;

        public KayitlarDetay(string DetayTabloAd, int KayitDetayNo)
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
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Kapat = new System.Windows.Forms.Button();
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
            this.columnHeader4.Text = "Barkod";
            this.columnHeader4.Width = 60;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sicil Adý";
            this.columnHeader1.Width = 155;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Size = new System.Drawing.Size(234, 262);
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Kapat
            // 
            this.Kapat.Location = new System.Drawing.Point(165, 271);
            this.Kapat.Size = new System.Drawing.Size(72, 20);
            this.Kapat.Text = "Kapat";
            this.Kapat.Click += new System.EventHandler(this.Kapat_Click);
            // 
            // KayitlarDetay
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.Kapat);
            this.Controls.Add(this.listView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Text = "KayitlarDetay";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.KayitlarDetay_Load);

        }

        #endregion

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetayGetir()
        {
            SqlCeConnection ConnCe = new SqlCeConnection("DataSource=ankara.sdf");
            ConnCe.Open();

            string Sql = "";

            if (DetayTabloAd == "SevkDetay")
                Sql = "SELECT * FROM " + DetayTabloAd + " WHERE BaslikNo=" + KayitDetayNo;
            else
                Sql = "SELECT * FROM " + DetayTabloAd + " WHERE siparis_no=" + KayitDetayNo;
            SqlCeCommand cmdDetay = new SqlCeCommand(Sql, ConnCe);

            SqlCeDataReader drDetay;

            try
            {
                drDetay = cmdDetay.ExecuteReader();
                while (drDetay.Read())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = drDetay["sicil_adi"].ToString();
                    lvi.SubItems.Add(drDetay["Miktar"].ToString());
                    lvi.SubItems.Add(drDetay["birim"].ToString());
                    lvi.SubItems.Add(drDetay["kolimiktar"].ToString());

                    listView1.Items.Add(lvi);
                }
                
            }
            finally
            {
                ConnCe.Close();
            }
        }

        private void KayitlarDetay_Load(object sender, EventArgs e)
        {
            DetayGetir();
        }

        private void Kapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
