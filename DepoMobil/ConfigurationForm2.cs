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
    /// Summary description for ConfigurationForm.
    /// </summary>
    public class ConfigurationForm : System.Windows.Forms.Form
    {
        private ComboBox comboBox1;
        private Label label6;
        private Label label12;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox OnlineIptextBox;
        private Label label13;
        private Label label14;
        private Label uyari;
        private Button SaveButton;
        private TextBox plasiyerKodutextBox;
        private TextBox DbSifre;
        private TextBox dbUserNametextBox;
        private TextBox ServertextBox;
        private TextBox DatbaseTextBox;
        private Label label11;
        Config config = new Config();

        public ConfigurationForm()
        {
            InitializeComponent();
            if (config.IsConfigured)
                Filltextboxs();
            else
               MessageBox.Show("Henüz kofigürasyon yapýlamaýþ! \r\nBu iþlemi yapmadan programý kullanamazssýnýz");
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.OnlineIptextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.uyari = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.plasiyerKodutextBox = new System.Windows.Forms.TextBox();
            this.DbSifre = new System.Windows.Forms.TextBox();
            this.dbUserNametextBox = new System.Windows.Forms.TextBox();
            this.ServertextBox = new System.Windows.Forms.TextBox();
            this.DatbaseTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            // 
            // comboBox1
            // 
            this.comboBox1.Items.Add("Kablo");
            this.comboBox1.Items.Add("Gprs");
            this.comboBox1.Items.Add("Wireless");
            this.comboBox1.Location = new System.Drawing.Point(104, 194);
            this.comboBox1.Size = new System.Drawing.Size(100, 22);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(96, 196);
            this.label6.Size = new System.Drawing.Size(8, 20);
            this.label6.Text = ":";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(16, 196);
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.Text = "Baðlantý Türü";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(96, 148);
            this.label10.Size = new System.Drawing.Size(8, 20);
            this.label10.Text = ":";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(96, 124);
            this.label9.Size = new System.Drawing.Size(8, 20);
            this.label9.Text = ":";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(96, 76);
            this.label8.Size = new System.Drawing.Size(8, 20);
            this.label8.Text = ":";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(96, 52);
            this.label7.Size = new System.Drawing.Size(8, 20);
            this.label7.Text = ":";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 172);
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.Text = "Plasiyer Kodu";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 148);
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.Text = "Db Þifre";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 124);
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.Text = "Db Kullanýcý";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 76);
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.Text = "Server";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 52);
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.Text = "Database";
            // 
            // OnlineIptextBox
            // 
            this.OnlineIptextBox.Location = new System.Drawing.Point(104, 100);
            this.OnlineIptextBox.Size = new System.Drawing.Size(100, 21);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(96, 100);
            this.label13.Size = new System.Drawing.Size(8, 20);
            this.label13.Text = ":";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 100);
            this.label14.Size = new System.Drawing.Size(80, 20);
            this.label14.Text = "Online IP";
            // 
            // uyari
            // 
            this.uyari.ForeColor = System.Drawing.Color.Red;
            this.uyari.Location = new System.Drawing.Point(8, 12);
            this.uyari.Size = new System.Drawing.Size(224, 32);
            this.uyari.Text = "Konfigürasyon tamamlanmadan programý kullanamazssýnýz";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(132, 236);
            this.SaveButton.Size = new System.Drawing.Size(72, 20);
            this.SaveButton.Text = "Kaydet";
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // plasiyerKodutextBox
            // 
            this.plasiyerKodutextBox.Location = new System.Drawing.Point(104, 172);
            this.plasiyerKodutextBox.Size = new System.Drawing.Size(100, 21);
            // 
            // DbSifre
            // 
            this.DbSifre.Location = new System.Drawing.Point(104, 148);
            this.DbSifre.Size = new System.Drawing.Size(100, 21);
            // 
            // dbUserNametextBox
            // 
            this.dbUserNametextBox.Location = new System.Drawing.Point(104, 124);
            this.dbUserNametextBox.Size = new System.Drawing.Size(100, 21);
            // 
            // ServertextBox
            // 
            this.ServertextBox.Location = new System.Drawing.Point(104, 76);
            this.ServertextBox.Size = new System.Drawing.Size(100, 21);
            // 
            // DatbaseTextBox
            // 
            this.DatbaseTextBox.Location = new System.Drawing.Point(104, 52);
            this.DatbaseTextBox.Size = new System.Drawing.Size(100, 21);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(96, 172);
            this.label11.Size = new System.Drawing.Size(8, 20);
            this.label11.Text = ":";
            // 
            // ConfigurationForm
            // 
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OnlineIptextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.uyari);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.plasiyerKodutextBox);
            this.Controls.Add(this.DbSifre);
            this.Controls.Add(this.dbUserNametextBox);
            this.Controls.Add(this.ServertextBox);
            this.Controls.Add(this.DatbaseTextBox);
            this.Controls.Add(this.label11);
            this.Text = "ConfigurationForm";

        }

        #endregion

        

        void Filltextboxs()
        {
            config.SetProertyes();
            DatbaseTextBox.Text = config.DataBase;
            ServertextBox.Text = config.Server;
            dbUserNametextBox.Text = config.Uid;
            DbSifre.Text = config.Pwd;
            plasiyerKodutextBox.Text = config.PlasiyerKodu;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ServertextBox.Text.Trim() == string.Empty ||
                DatbaseTextBox.Text.Trim() == string.Empty ||
                dbUserNametextBox.Text.Trim() == string.Empty ||
                DbSifre.Text.Trim() == string.Empty ||
                plasiyerKodutextBox.Text.Trim() == string.Empty ||
                OnlineIptextBox.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Ayarlar boþ býrakýlamaz!");
            }
            else
            {
                config.CreateConfigFile(DatbaseTextBox.Text.Trim(),
                    ServertextBox.Text.Trim(), dbUserNametextBox.Text.Trim(),
                    DbSifre.Text.Trim(), plasiyerKodutextBox.Text.Trim(),
                    OnlineIptextBox.Text, comboBox1.Text);
                config.SetProertyes();
                MessageBox.Show("Ýþlem Tamam");
            }
        }
    }
}
