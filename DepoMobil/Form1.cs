#region Using directives

using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;

#endregion

namespace DepoMobil
{
    /// <summary>
    /// Summary description for form.
    /// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private Button button6;
        private Button btnKayit;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Button button1;
        ConfigurationForm cf = new ConfigurationForm();
        private Button button7;
        Config config = new Config();
        DB db;

        public Form1()
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
            this.button6 = new System.Windows.Forms.Button();
            this.btnKayit = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.SystemColors.Highlight;
            this.button6.ForeColor = System.Drawing.SystemColors.Window;
            this.button6.Location = new System.Drawing.Point(43, 252);
            this.button6.Size = new System.Drawing.Size(155, 35);
            this.button6.Text = "Kapat";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnKayit
            // 
            this.btnKayit.Location = new System.Drawing.Point(123, 115);
            this.btnKayit.Size = new System.Drawing.Size(115, 50);
            this.btnKayit.Text = "Kayýtlar";
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(43, 202);
            this.button5.Size = new System.Drawing.Size(155, 35);
            this.button5.Text = "Veri Ýletiþimi";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(123, 59);
            this.button4.Size = new System.Drawing.Size(115, 50);
            this.button4.Text = "Sayým";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(2, 59);
            this.button3.Size = new System.Drawing.Size(115, 50);
            this.button3.Text = "Depo Transfer";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 3);
            this.button2.Size = new System.Drawing.Size(115, 50);
            this.button2.Text = "Ýade Alýþ";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(2, 3);
            this.button1.Size = new System.Drawing.Size(115, 50);
            this.button1.Text = "Ýrsaliyeli Alýþ";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(2, 115);
            this.button7.Size = new System.Drawing.Size(115, 50);
            this.button7.Text = "Yüklemeler";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnKayit);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Text = "Depo Uygulamasý";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);

        }

        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Application.Run(new Form1());
         }

        private void button1_Click(object sender, EventArgs e)
        {
            BaslikKaydet BasKaydet = new BaslikKaydet("Baslik","Irsaliye");
            BasKaydet.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Aktarma Aktar = new Aktarma();
            Aktar.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!config.IsConfigured)
            {
                this.Hide();
                cf.ShowDialog();
                this.Show();
            }
            else
            {
                config.SetProertyes();
            }
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            config.CeConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BaslikKaydet BasKaydet = new BaslikKaydet("Baslik", "Iade");
            BasKaydet.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BaslikKaydet BasKaydet = new BaslikKaydet("Baslik", "Transfer");
            BasKaydet.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BaslikKaydet BasKaydet = new BaslikKaydet("Baslik", "Sayim");
            BasKaydet.Show();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Kayitlar kayit = new Kayitlar();
            kayit.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Yukleme yukle = new Yukleme();
            yukle.Show();
        }
    }
}

