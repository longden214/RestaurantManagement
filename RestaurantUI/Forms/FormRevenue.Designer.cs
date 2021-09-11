
namespace RestaurantUI.Forms
{
    partial class FormRevenue
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRevenue = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvRevenue = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPageCurrent = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalPage = new System.Windows.Forms.Label();
            this.iconPrevPage = new FontAwesome.Sharp.IconButton();
            this.iconNextPage = new FontAwesome.Sharp.IconButton();
            this.btnReportBill = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnRevenue);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(942, 69);
            this.panel1.TabIndex = 0;
            // 
            // btnRevenue
            // 
            this.btnRevenue.Location = new System.Drawing.Point(748, 16);
            this.btnRevenue.Name = "btnRevenue";
            this.btnRevenue.Size = new System.Drawing.Size(124, 34);
            this.btnRevenue.TabIndex = 2;
            this.btnRevenue.Text = "Thống kê";
            this.btnRevenue.UseVisualStyleBackColor = true;
            this.btnRevenue.Click += new System.EventHandler(this.btnRevenue_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày kết thúc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ngày bất đầu";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(478, 25);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(176, 22);
            this.dtpEndDate.TabIndex = 0;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(160, 25);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(161, 22);
            this.dtpStartDate.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.btnReportBill);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.dgvRevenue);
            this.panel2.Location = new System.Drawing.Point(12, 101);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(942, 402);
            this.panel2.TabIndex = 1;
            // 
            // dgvRevenue
            // 
            this.dgvRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRevenue.Location = new System.Drawing.Point(3, 3);
            this.dgvRevenue.Name = "dgvRevenue";
            this.dgvRevenue.RowHeadersWidth = 51;
            this.dgvRevenue.RowTemplate.Height = 24;
            this.dgvRevenue.Size = new System.Drawing.Size(936, 318);
            this.dgvRevenue.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.iconNextPage);
            this.panel3.Controls.Add(this.iconPrevPage);
            this.panel3.Controls.Add(this.lblTotalPage);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.txtPageCurrent);
            this.panel3.Location = new System.Drawing.Point(331, 338);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(284, 47);
            this.panel3.TabIndex = 1;
            // 
            // txtPageCurrent
            // 
            this.txtPageCurrent.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPageCurrent.Location = new System.Drawing.Point(83, 13);
            this.txtPageCurrent.Name = "txtPageCurrent";
            this.txtPageCurrent.Size = new System.Drawing.Size(45, 23);
            this.txtPageCurrent.TabIndex = 0;
            this.txtPageCurrent.Text = "1";
            this.txtPageCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPageCurrent.TextChanged += new System.EventHandler(this.txtPageCurrent_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(145, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "of";
            // 
            // lblTotalPage
            // 
            this.lblTotalPage.AutoSize = true;
            this.lblTotalPage.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPage.Location = new System.Drawing.Point(174, 16);
            this.lblTotalPage.Name = "lblTotalPage";
            this.lblTotalPage.Size = new System.Drawing.Size(26, 17);
            this.lblTotalPage.TabIndex = 2;
            this.lblTotalPage.Text = "20";
            // 
            // iconPrevPage
            // 
            this.iconPrevPage.BackColor = System.Drawing.Color.White;
            this.iconPrevPage.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.iconPrevPage.IconColor = System.Drawing.Color.Black;
            this.iconPrevPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPrevPage.IconSize = 20;
            this.iconPrevPage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconPrevPage.Location = new System.Drawing.Point(21, 8);
            this.iconPrevPage.Name = "iconPrevPage";
            this.iconPrevPage.Size = new System.Drawing.Size(40, 33);
            this.iconPrevPage.TabIndex = 3;
            this.iconPrevPage.UseVisualStyleBackColor = false;
            this.iconPrevPage.Click += new System.EventHandler(this.iconPrevPage_Click);
            // 
            // iconNextPage
            // 
            this.iconNextPage.BackColor = System.Drawing.Color.White;
            this.iconNextPage.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.iconNextPage.IconColor = System.Drawing.Color.Black;
            this.iconNextPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconNextPage.IconSize = 20;
            this.iconNextPage.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.iconNextPage.Location = new System.Drawing.Point(217, 8);
            this.iconNextPage.Name = "iconNextPage";
            this.iconNextPage.Size = new System.Drawing.Size(40, 33);
            this.iconNextPage.TabIndex = 3;
            this.iconNextPage.UseVisualStyleBackColor = false;
            this.iconNextPage.Click += new System.EventHandler(this.iconNextPage_Click);
            // 
            // btnReportBill
            // 
            this.btnReportBill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnReportBill.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportBill.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReportBill.Location = new System.Drawing.Point(808, 340);
            this.btnReportBill.Name = "btnReportBill";
            this.btnReportBill.Size = new System.Drawing.Size(121, 39);
            this.btnReportBill.TabIndex = 2;
            this.btnReportBill.Text = "Report";
            this.btnReportBill.UseVisualStyleBackColor = false;
            this.btnReportBill.Click += new System.EventHandler(this.btnReportBill_Click);
            // 
            // FormRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 515);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormRevenue";
            this.Text = "FormRevenue";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRevenue)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRevenue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvRevenue;
        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton iconNextPage;
        private FontAwesome.Sharp.IconButton iconPrevPage;
        private System.Windows.Forms.Label lblTotalPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPageCurrent;
        private System.Windows.Forms.Button btnReportBill;
    }
}