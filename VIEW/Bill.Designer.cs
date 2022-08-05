namespace FastFoodManagement.VIEW
{
    partial class Bill
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bill));
            this.dgvShowBill = new System.Windows.Forms.DataGridView();
            this.lbtitle = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbMaHD = new System.Windows.Forms.Label();
            this.lbBan = new System.Windows.Forms.Label();
            this.lbNgay = new System.Windows.Forms.Label();
            this.lbBanHang = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvShowBill
            // 
            this.dgvShowBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShowBill.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvShowBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShowBill.Enabled = false;
            this.dgvShowBill.Location = new System.Drawing.Point(12, 245);
            this.dgvShowBill.Name = "dgvShowBill";
            this.dgvShowBill.ReadOnly = true;
            this.dgvShowBill.RowHeadersVisible = false;
            this.dgvShowBill.RowHeadersWidth = 51;
            this.dgvShowBill.RowTemplate.Height = 24;
            this.dgvShowBill.RowTemplate.ReadOnly = true;
            this.dgvShowBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShowBill.Size = new System.Drawing.Size(540, 360);
            this.dgvShowBill.TabIndex = 0;
            // 
            // lbtitle
            // 
            this.lbtitle.AutoSize = true;
            this.lbtitle.Font = new System.Drawing.Font("Gill Sans Ultra Bold", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtitle.ForeColor = System.Drawing.Color.Crimson;
            this.lbtitle.Location = new System.Drawing.Point(150, 11);
            this.lbtitle.Name = "lbtitle";
            this.lbtitle.Size = new System.Drawing.Size(376, 51);
            this.lbtitle.TabIndex = 1;
            this.lbtitle.Text = "Fast Food Store";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.ForeColor = System.Drawing.Color.Crimson;
            this.labelTotal.Location = new System.Drawing.Point(261, 622);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(110, 38);
            this.labelTotal.TabIndex = 2;
            this.labelTotal.Text = "Total: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(127, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 38);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hóa đơn thanh toán";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Crimson;
            this.label2.Location = new System.Drawing.Point(166, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "52 Nguyễn Lương Bằng, Liên Chiểu, Đà Nẵng";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(256, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tel: 0236 3842 308";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 102);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // lbMaHD
            // 
            this.lbMaHD.AutoSize = true;
            this.lbMaHD.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaHD.ForeColor = System.Drawing.Color.Crimson;
            this.lbMaHD.Location = new System.Drawing.Point(12, 183);
            this.lbMaHD.Name = "lbMaHD";
            this.lbMaHD.Size = new System.Drawing.Size(101, 20);
            this.lbMaHD.TabIndex = 16;
            this.lbMaHD.Text = "Mã hóa đơn: ";
            // 
            // lbBan
            // 
            this.lbBan.AutoSize = true;
            this.lbBan.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBan.ForeColor = System.Drawing.Color.Crimson;
            this.lbBan.Location = new System.Drawing.Point(229, 183);
            this.lbBan.Name = "lbBan";
            this.lbBan.Size = new System.Drawing.Size(44, 20);
            this.lbBan.TabIndex = 17;
            this.lbBan.Text = "Bàn: ";
            // 
            // lbNgay
            // 
            this.lbNgay.AutoSize = true;
            this.lbNgay.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgay.ForeColor = System.Drawing.Color.Crimson;
            this.lbNgay.Location = new System.Drawing.Point(12, 212);
            this.lbNgay.Name = "lbNgay";
            this.lbNgay.Size = new System.Drawing.Size(127, 20);
            this.lbNgay.TabIndex = 18;
            this.lbNgay.Text = "Ngày thực hiện: ";
            // 
            // lbBanHang
            // 
            this.lbBanHang.AutoSize = true;
            this.lbBanHang.Font = new System.Drawing.Font("Cambria", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBanHang.ForeColor = System.Drawing.Color.Crimson;
            this.lbBanHang.Location = new System.Drawing.Point(374, 183);
            this.lbBanHang.Name = "lbBanHang";
            this.lbBanHang.Size = new System.Drawing.Size(82, 20);
            this.lbBanHang.TabIndex = 19;
            this.lbBanHang.Text = "Bán hàng: ";
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(564, 682);
            this.Controls.Add(this.lbBanHang);
            this.Controls.Add(this.lbNgay);
            this.Controls.Add(this.lbBan);
            this.Controls.Add(this.lbMaHD);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.lbtitle);
            this.Controls.Add(this.dgvShowBill);
            this.Name = "Bill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill";
            ((System.ComponentModel.ISupportInitialize)(this.dgvShowBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShowBill;
        private System.Windows.Forms.Label lbtitle;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbMaHD;
        private System.Windows.Forms.Label lbBan;
        private System.Windows.Forms.Label lbNgay;
        private System.Windows.Forms.Label lbBanHang;
        private System.Windows.Forms.PrintDialog printDialog1;
    }
}