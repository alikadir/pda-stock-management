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
    /// Summary description for StokKontrol.
    /// </summary>
    public class StokKontrol : System.Windows.Forms.Form
    {
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button button1;
        private ColumnHeader columnHeader4;
        private ComboBox comboBox1;
        private Label label1;
        SqlCeConnection CeConn = new SqlCeConnection("DataSource=ankara.sdf");

        public StokKontrol()
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Columns.Add(this.columnHeader3);
            this.listView1.Columns.Add(this.columnHeader4);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.Size = new System.Drawing.Size(234, 260);
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sicil Adý";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Stok";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sayým";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Fark";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 40;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(165, 269);
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.Text = "Kapat";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(54, 267);
            this.comboBox1.Size = new System.Drawing.Size(69, 22);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 269);
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.Text = "Depo";
            // 
            // StokKontrol
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Text = "StokKontrol";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.StokKontrol_Load);

        }

        #endregion

        private void Listele()
        {
            CeConn.Open();

            string sql = "SELECT D.sicil_kodu, DS.Miktar,S.sicil_adi, " +
                      "SUM(CASE WHEN D.birim = S.BIRIM1A THEN (S.BIRIM1C * D.Miktar) " +
                      "ELSE D.Miktar END) AS SayimMiktar, " +
                      "DS.Miktar - SUM(CASE WHEN D.birim = S.BIRIM1A THEN (S.BIRIM1C * D.Miktar) " +
                      "ELSE D.Miktar END) As Fark " +
                      "FROM stok S INNER JOIN BaslikDetay D " +
                      "ON S.GRUP_KODU = D.grup_kodu AND " +
                      "S.SICIL_KODU = D.sicil_kodu INNER JOIN DEPO_StokDurum DS " +
                      "ON D.grup_kodu = DS.Grup_Kodu AND D.sicil_kodu = DS.Sicil_Kodu " +
                      "WHERE DS.Depo = '" + comboBox1.Text +"'"+
                      " GROUP BY D.grup_kodu, D.sicil_kodu, DS.Miktar,S.sicil_adi ORDER BY S.sicil_adi";
            SqlCeCommand cmd = new SqlCeCommand(sql, CeConn);

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
                    lvi.SubItems.Add(dr["SayimMiktar"].ToString());
                    lvi.SubItems.Add(dr["Fark"].ToString());

                    listView1.Items.Add(lvi);
                }
            }
            finally
            {
                CeConn.Close();
            }
        }

        private void DepoDoldur()
        { 
            CeConn.Open();

            string sql = "SELECT DISTINCT Depo FROM DEPO_StokDurum";
            SqlCeCommand cmd = new SqlCeCommand(sql, CeConn);

            try
            {
                SqlCeDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboBox1.Items.Add(dr["Depo"].ToString());
                }
            }
            finally
            {
                CeConn.Close();
            }

            comboBox1.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StokKontrol_Load(object sender, EventArgs e)
        {
            DepoDoldur();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }
     }
}
