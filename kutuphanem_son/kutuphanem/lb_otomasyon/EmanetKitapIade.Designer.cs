namespace lb_otomasyon
{
    partial class EmanetKitapIade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmanetKitapIade));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTcyegore = new System.Windows.Forms.TextBox();
            this.txtBarkodagore = new System.Windows.Forms.TextBox();
            this.btnTeslimAl = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(331, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "TC\'ye Göre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(568, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Barkod No\'ya Göre";
            // 
            // txtTcyegore
            // 
            this.txtTcyegore.Location = new System.Drawing.Point(401, 24);
            this.txtTcyegore.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTcyegore.MaxLength = 11;
            this.txtTcyegore.Name = "txtTcyegore";
            this.txtTcyegore.Size = new System.Drawing.Size(100, 23);
            this.txtTcyegore.TabIndex = 2;
            this.txtTcyegore.TextChanged += new System.EventHandler(this.txtTcyegore_TextChanged);
            this.txtTcyegore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTcyegore_KeyPress);
            // 
            // txtBarkodagore
            // 
            this.txtBarkodagore.Location = new System.Drawing.Point(681, 24);
            this.txtBarkodagore.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBarkodagore.Name = "txtBarkodagore";
            this.txtBarkodagore.Size = new System.Drawing.Size(100, 23);
            this.txtBarkodagore.TabIndex = 3;
            this.txtBarkodagore.TextChanged += new System.EventHandler(this.txtBarkodagore_TextChanged);
            this.txtBarkodagore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarkodagore_KeyPress);
            // 
            // btnTeslimAl
            // 
            this.btnTeslimAl.BackColor = System.Drawing.SystemColors.Control;
            this.btnTeslimAl.Image = ((System.Drawing.Image)(resources.GetObject("btnTeslimAl.Image")));
            this.btnTeslimAl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTeslimAl.Location = new System.Drawing.Point(586, 384);
            this.btnTeslimAl.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTeslimAl.Name = "btnTeslimAl";
            this.btnTeslimAl.Size = new System.Drawing.Size(98, 37);
            this.btnTeslimAl.TabIndex = 4;
            this.btnTeslimAl.Text = "      TESLİM AL";
            this.btnTeslimAl.UseVisualStyleBackColor = false;
            this.btnTeslimAl.Click += new System.EventHandler(this.btnTeslimAl_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.SystemColors.Control;
            this.btnIptal.Image = ((System.Drawing.Image)(resources.GetObject("btnIptal.Image")));
            this.btnIptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIptal.Location = new System.Drawing.Point(712, 384);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(77, 37);
            this.btnIptal.TabIndex = 42;
            this.btnIptal.Text = "     İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 66);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 72;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(776, 300);
            this.dataGridView1.TabIndex = 43;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // EmanetKitapIade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.BackgroundImage = global::lb_otomasyon.Properties.Resources.stock_photo_black_textured_surface_abstract_background;
            this.ClientSize = new System.Drawing.Size(817, 473);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTeslimAl);
            this.Controls.Add(this.txtBarkodagore);
            this.Controls.Add(this.txtTcyegore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "EmanetKitapIade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Emanet Kitap İade Sayfası";
            this.Load += new System.EventHandler(this.EmanetKitapIade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtTcyegore;
        private TextBox txtBarkodagore;
        private Button btnTeslimAl;
        private Button btnIptal;
        private DataGridView dataGridView1;
    }
}