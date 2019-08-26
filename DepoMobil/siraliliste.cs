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
    /// Summary description for siraliliste.
    /// </summary>
    public class siraliliste : System.Windows.Forms.Form
    {
        private ColumnHeader columnHeader2;
        private Button button1;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        string tabload;
        Int64 irsaliyeno;

        public siraliliste(string tabload, Int64 irsaliyeno)
        {
            this.tabload = tabload;
            this.irsaliyeno = irsaliyeno;

            InitializeComponent();
            siralilistegetir();
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
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Miktar Top.";
            this.columnHeader2.Width = 60;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 275);
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.Text = "Kapat";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.columnHeader1);
            this.listView1.Columns.Add(this.columnHeader2);
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Size = new System.Drawing.Size(240, 272);
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Sicil Adý";
            this.columnHeader1.Width = 177;
            // 
            // siraliliste
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Text = "siraliliste";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

        }

        #endregion

         private void siralilistegetir()
        {

            SqlCeConnection cconn = new SqlCeConnection("datasource=ankara.sdf");

            cconn.Open();

            string sql = " select sicil_adi,Miktar from " + tabload + "detay where siparis_no = " + irsaliyeno + " order by sicil_Adi";

            SqlCeCommand cmd = new SqlCeCommand(sql, cconn);

            SqlCeDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                ListViewItem lvi = new ListViewItem();
                lvi.Text = dr["sicil_adi"].ToString();
                lvi.SubItems.Add(dr["Miktar"].ToString());

                listView1.Items.Add(lvi);

            }

            cconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
