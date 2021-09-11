
namespace RestaurantUI.Forms
{
    partial class FormCategory
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
            this.tabCategory = new System.Windows.Forms.TabControl();
            this.tabCate = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCategory = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCancelCate = new System.Windows.Forms.Button();
            this.btnDeleteCate = new System.Windows.Forms.Button();
            this.btnUpdateCate = new System.Windows.Forms.Button();
            this.btnAddNewCate = new System.Windows.Forms.Button();
            this.txtNameCategory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearchCategory = new System.Windows.Forms.Button();
            this.txtSearchCategory = new System.Windows.Forms.TextBox();
            this.tabTable = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvTableCate = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnTableCancel = new System.Windows.Forms.Button();
            this.btnTableDelete = new System.Windows.Forms.Button();
            this.btnTableUpdate = new System.Windows.Forms.Button();
            this.btnTableAdd = new System.Windows.Forms.Button();
            this.txtNameTable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIdTable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnTableSearch = new System.Windows.Forms.Button();
            this.txtSearchTable = new System.Windows.Forms.TextBox();
            this.tabCategory.SuspendLayout();
            this.tabCate.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabTable.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableCate)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCategory
            // 
            this.tabCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabCategory.Controls.Add(this.tabCate);
            this.tabCategory.Controls.Add(this.tabTable);
            this.tabCategory.Location = new System.Drawing.Point(12, 12);
            this.tabCategory.Name = "tabCategory";
            this.tabCategory.SelectedIndex = 0;
            this.tabCategory.Size = new System.Drawing.Size(923, 554);
            this.tabCategory.TabIndex = 0;
            // 
            // tabCate
            // 
            this.tabCate.Controls.Add(this.panel2);
            this.tabCate.Controls.Add(this.panel3);
            this.tabCate.Controls.Add(this.panel1);
            this.tabCate.Location = new System.Drawing.Point(4, 25);
            this.tabCate.Name = "tabCate";
            this.tabCate.Padding = new System.Windows.Forms.Padding(3);
            this.tabCate.Size = new System.Drawing.Size(915, 525);
            this.tabCate.TabIndex = 0;
            this.tabCate.Text = "Danh mục";
            this.tabCate.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dgvCategory);
            this.panel2.Location = new System.Drawing.Point(3, 70);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(518, 449);
            this.panel2.TabIndex = 6;
            // 
            // dgvCategory
            // 
            this.dgvCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCategory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategory.Location = new System.Drawing.Point(3, 3);
            this.dgvCategory.Name = "dgvCategory";
            this.dgvCategory.RowHeadersWidth = 51;
            this.dgvCategory.RowTemplate.Height = 24;
            this.dgvCategory.Size = new System.Drawing.Size(512, 443);
            this.dgvCategory.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.btnCancelCate);
            this.panel3.Controls.Add(this.btnDeleteCate);
            this.panel3.Controls.Add(this.btnUpdateCate);
            this.panel3.Controls.Add(this.btnAddNewCate);
            this.panel3.Controls.Add(this.txtNameCategory);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtIDCategory);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(527, 73);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(382, 443);
            this.panel3.TabIndex = 5;
            // 
            // btnCancelCate
            // 
            this.btnCancelCate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelCate.Location = new System.Drawing.Point(204, 264);
            this.btnCancelCate.Name = "btnCancelCate";
            this.btnCancelCate.Size = new System.Drawing.Size(157, 43);
            this.btnCancelCate.TabIndex = 2;
            this.btnCancelCate.Text = "Bỏ qua";
            this.btnCancelCate.UseVisualStyleBackColor = true;
            this.btnCancelCate.Click += new System.EventHandler(this.btnCancelCate_Click);
            // 
            // btnDeleteCate
            // 
            this.btnDeleteCate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteCate.Location = new System.Drawing.Point(17, 264);
            this.btnDeleteCate.Name = "btnDeleteCate";
            this.btnDeleteCate.Size = new System.Drawing.Size(157, 43);
            this.btnDeleteCate.TabIndex = 2;
            this.btnDeleteCate.Text = "Xóa";
            this.btnDeleteCate.UseVisualStyleBackColor = true;
            this.btnDeleteCate.Click += new System.EventHandler(this.btnDeleteCate_Click);
            // 
            // btnUpdateCate
            // 
            this.btnUpdateCate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateCate.Location = new System.Drawing.Point(204, 199);
            this.btnUpdateCate.Name = "btnUpdateCate";
            this.btnUpdateCate.Size = new System.Drawing.Size(157, 43);
            this.btnUpdateCate.TabIndex = 2;
            this.btnUpdateCate.Text = "Cập nhật";
            this.btnUpdateCate.UseVisualStyleBackColor = true;
            this.btnUpdateCate.Click += new System.EventHandler(this.btnUpdateCate_Click);
            // 
            // btnAddNewCate
            // 
            this.btnAddNewCate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewCate.Location = new System.Drawing.Point(17, 199);
            this.btnAddNewCate.Name = "btnAddNewCate";
            this.btnAddNewCate.Size = new System.Drawing.Size(157, 43);
            this.btnAddNewCate.TabIndex = 2;
            this.btnAddNewCate.Text = "Tạo mới";
            this.btnAddNewCate.UseVisualStyleBackColor = true;
            this.btnAddNewCate.Click += new System.EventHandler(this.btnAddNewCate_Click);
            // 
            // txtNameCategory
            // 
            this.txtNameCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameCategory.Location = new System.Drawing.Point(17, 119);
            this.txtNameCategory.Name = "txtNameCategory";
            this.txtNameCategory.Size = new System.Drawing.Size(346, 36);
            this.txtNameCategory.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên danh mục";
            // 
            // txtIDCategory
            // 
            this.txtIDCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCategory.Location = new System.Drawing.Point(17, 42);
            this.txtIDCategory.Name = "txtIDCategory";
            this.txtIDCategory.ReadOnly = true;
            this.txtIDCategory.Size = new System.Drawing.Size(346, 36);
            this.txtIDCategory.TabIndex = 1;
            this.txtIDCategory.TextChanged += new System.EventHandler(this.txtIDCategory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnSearchCategory);
            this.panel1.Controls.Add(this.txtSearchCategory);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 61);
            this.panel1.TabIndex = 3;
            // 
            // btnSearchCategory
            // 
            this.btnSearchCategory.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCategory.Location = new System.Drawing.Point(364, 13);
            this.btnSearchCategory.Name = "btnSearchCategory";
            this.btnSearchCategory.Size = new System.Drawing.Size(116, 35);
            this.btnSearchCategory.TabIndex = 1;
            this.btnSearchCategory.Text = "Search";
            this.btnSearchCategory.UseVisualStyleBackColor = true;
            this.btnSearchCategory.Click += new System.EventHandler(this.btnSearchCategory_Click);
            // 
            // txtSearchCategory
            // 
            this.txtSearchCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCategory.Location = new System.Drawing.Point(16, 13);
            this.txtSearchCategory.Name = "txtSearchCategory";
            this.txtSearchCategory.Size = new System.Drawing.Size(310, 36);
            this.txtSearchCategory.TabIndex = 0;
            // 
            // tabTable
            // 
            this.tabTable.Controls.Add(this.panel4);
            this.tabTable.Controls.Add(this.panel5);
            this.tabTable.Controls.Add(this.panel6);
            this.tabTable.Location = new System.Drawing.Point(4, 25);
            this.tabTable.Name = "tabTable";
            this.tabTable.Padding = new System.Windows.Forms.Padding(3);
            this.tabTable.Size = new System.Drawing.Size(915, 525);
            this.tabTable.TabIndex = 1;
            this.tabTable.Text = "Bàn ăn";
            this.tabTable.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.dgvTableCate);
            this.panel4.Location = new System.Drawing.Point(3, 71);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(518, 449);
            this.panel4.TabIndex = 9;
            // 
            // dgvTableCate
            // 
            this.dgvTableCate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTableCate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTableCate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTableCate.Location = new System.Drawing.Point(3, 3);
            this.dgvTableCate.Name = "dgvTableCate";
            this.dgvTableCate.RowHeadersWidth = 51;
            this.dgvTableCate.RowTemplate.Height = 24;
            this.dgvTableCate.Size = new System.Drawing.Size(512, 443);
            this.dgvTableCate.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnTableCancel);
            this.panel5.Controls.Add(this.btnTableDelete);
            this.panel5.Controls.Add(this.btnTableUpdate);
            this.panel5.Controls.Add(this.btnTableAdd);
            this.panel5.Controls.Add(this.txtNameTable);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtIdTable);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(527, 74);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(382, 443);
            this.panel5.TabIndex = 8;
            // 
            // btnTableCancel
            // 
            this.btnTableCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableCancel.Location = new System.Drawing.Point(206, 291);
            this.btnTableCancel.Name = "btnTableCancel";
            this.btnTableCancel.Size = new System.Drawing.Size(157, 43);
            this.btnTableCancel.TabIndex = 2;
            this.btnTableCancel.Text = "Bỏ qua";
            this.btnTableCancel.UseVisualStyleBackColor = true;
            this.btnTableCancel.Click += new System.EventHandler(this.btnTableCancel_Click);
            // 
            // btnTableDelete
            // 
            this.btnTableDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableDelete.Location = new System.Drawing.Point(19, 291);
            this.btnTableDelete.Name = "btnTableDelete";
            this.btnTableDelete.Size = new System.Drawing.Size(157, 43);
            this.btnTableDelete.TabIndex = 2;
            this.btnTableDelete.Text = "Xóa";
            this.btnTableDelete.UseVisualStyleBackColor = true;
            this.btnTableDelete.Click += new System.EventHandler(this.btnTableDelete_Click);
            // 
            // btnTableUpdate
            // 
            this.btnTableUpdate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableUpdate.Location = new System.Drawing.Point(206, 226);
            this.btnTableUpdate.Name = "btnTableUpdate";
            this.btnTableUpdate.Size = new System.Drawing.Size(157, 43);
            this.btnTableUpdate.TabIndex = 2;
            this.btnTableUpdate.Text = "Cập nhật";
            this.btnTableUpdate.UseVisualStyleBackColor = true;
            this.btnTableUpdate.Click += new System.EventHandler(this.btnTableUpdate_Click);
            // 
            // btnTableAdd
            // 
            this.btnTableAdd.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableAdd.Location = new System.Drawing.Point(19, 226);
            this.btnTableAdd.Name = "btnTableAdd";
            this.btnTableAdd.Size = new System.Drawing.Size(157, 43);
            this.btnTableAdd.TabIndex = 2;
            this.btnTableAdd.Text = "Tạo mới";
            this.btnTableAdd.UseVisualStyleBackColor = true;
            this.btnTableAdd.Click += new System.EventHandler(this.btnTableAdd_Click);
            // 
            // txtNameTable
            // 
            this.txtNameTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNameTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNameTable.Location = new System.Drawing.Point(17, 119);
            this.txtNameTable.Name = "txtNameTable";
            this.txtNameTable.Size = new System.Drawing.Size(346, 36);
            this.txtNameTable.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tên bàn";
            // 
            // txtIdTable
            // 
            this.txtIdTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdTable.Location = new System.Drawing.Point(17, 42);
            this.txtIdTable.Name = "txtIdTable";
            this.txtIdTable.ReadOnly = true;
            this.txtIdTable.Size = new System.Drawing.Size(346, 36);
            this.txtIdTable.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.btnTableSearch);
            this.panel6.Controls.Add(this.txtSearchTable);
            this.panel6.Location = new System.Drawing.Point(3, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(909, 61);
            this.panel6.TabIndex = 7;
            // 
            // btnTableSearch
            // 
            this.btnTableSearch.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableSearch.Location = new System.Drawing.Point(364, 13);
            this.btnTableSearch.Name = "btnTableSearch";
            this.btnTableSearch.Size = new System.Drawing.Size(116, 35);
            this.btnTableSearch.TabIndex = 1;
            this.btnTableSearch.Text = "Search";
            this.btnTableSearch.UseVisualStyleBackColor = true;
            this.btnTableSearch.Click += new System.EventHandler(this.btnTableSearch_Click);
            // 
            // txtSearchTable
            // 
            this.txtSearchTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchTable.Location = new System.Drawing.Point(16, 13);
            this.txtSearchTable.Name = "txtSearchTable";
            this.txtSearchTable.Size = new System.Drawing.Size(310, 36);
            this.txtSearchTable.TabIndex = 0;
            // 
            // FormCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 578);
            this.Controls.Add(this.tabCategory);
            this.Name = "FormCategory";
            this.Text = "FormCategory";
            this.tabCategory.ResumeLayout(false);
            this.tabCate.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategory)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabTable.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTableCate)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabCategory;
        private System.Windows.Forms.TabPage tabCate;
        private System.Windows.Forms.TabPage tabTable;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnCancelCate;
        private System.Windows.Forms.Button btnDeleteCate;
        private System.Windows.Forms.Button btnUpdateCate;
        private System.Windows.Forms.Button btnAddNewCate;
        private System.Windows.Forms.TextBox txtNameCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDCategory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSearchCategory;
        private System.Windows.Forms.TextBox txtSearchCategory;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvCategory;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgvTableCate;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnTableCancel;
        private System.Windows.Forms.Button btnTableDelete;
        private System.Windows.Forms.Button btnTableUpdate;
        private System.Windows.Forms.Button btnTableAdd;
        private System.Windows.Forms.TextBox txtNameTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIdTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnTableSearch;
        private System.Windows.Forms.TextBox txtSearchTable;
    }
}