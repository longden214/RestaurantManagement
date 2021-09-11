using RestaurantUI.DAO;
using RestaurantUI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantUI.Forms
{
    public partial class FormCategory : Form
    {
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();
        public FormCategory()
        {
            InitializeComponent();
            loadCategory();
            loadBinding();
            loadTable();
            loadBindingTable();
        }

        private void loadBindingTable()
        {
            txtIdTable.DataBindings.Add("Text", dgvTableCate.DataSource, "Id", true, DataSourceUpdateMode.Never);
            txtNameTable.DataBindings.Add("Text", dgvTableCate.DataSource, "Name", true, DataSourceUpdateMode.Never);
        }

        private void loadTable()
        {
            tableList.DataSource = TableDAO.Instance.TableList();
            dgvTableCate.DataSource = tableList;
        }

        void loadCategory()
        {
            categoryList.DataSource = CategoryDAO.Instance.GetListCategory();
            dgvCategory.DataSource = categoryList;
        }

        void loadBinding()
        {
            txtIDCategory.DataBindings.Add("Text", dgvCategory.DataSource, "Id",true,DataSourceUpdateMode.Never);
            txtNameCategory.DataBindings.Add("Text", dgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never);

        }

        List<Category> SearchCategories(string name)
        {
            List<Category> list = CategoryDAO.Instance.SearchCategoryByName(name);
            return list;
        }

        List<Table> SearchTables(string name)
        {
            List<Table> list = TableDAO.Instance.SearchTableFoodByName(name);
            return list;
        }

        private void btnAddNewCate_Click(object sender, EventArgs e)
        {
            string name = txtNameCategory.Text;
            if (CategoryDAO.Instance.InsertCategory(name))
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadCategory();
                if (insertCategory != null)
                    insertCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdateCate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDCategory.Text);
            string name = txtNameCategory.Text;
            if (CategoryDAO.Instance.UpdateCategory(id,name))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadCategory();
                if (updateCategory != null)
                    updateCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelCate_Click(object sender, EventArgs e)
        {
            categoryList.CancelEdit();
            loadCategory();
        }

        private void btnDeleteCate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDCategory.Text);
            if (CategoryDAO.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadCategory();
                if (deleteCategory != null)
                    deleteCategory(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private event EventHandler insertCategory;
        public event EventHandler InsertCategory
        {
            add { insertCategory += value; }
            remove { insertCategory -= value; }
        }

        private event EventHandler deleteCategory;
        public event EventHandler DeleteCategory
        {
            add { deleteCategory += value; }
            remove { deleteCategory -= value; }
        }

        private event EventHandler updateCategory;
        public event EventHandler UpdateCategory
        {
            add { updateCategory += value; }
            remove { updateCategory -= value; }
        }

        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            dgvCategory.DataSource = SearchCategories(txtSearchCategory.Text);
        }

        private void btnTableAdd_Click(object sender, EventArgs e)
        {
            string name = txtNameTable.Text;
            if (TableDAO.Instance.InsertTableFood(name))
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                if (insertTable != null)
                    insertTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTableUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdTable.Text);
            string name = txtNameTable.Text;
            if (TableDAO.Instance.UpdateTableFood(id, name))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                if (updateTable != null)
                    updateTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTableDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIdTable.Text);
            if (TableDAO.Instance.DeleteTableFood(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadTable();
                if (deleteTable != null)
                    deleteTable(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTableCancel_Click(object sender, EventArgs e)
        {
            tableList.CancelEdit();
            loadTable();
        }

        private void btnTableSearch_Click(object sender, EventArgs e)
        {
            dgvTableCate.DataSource = SearchTables(txtSearchTable.Text);
        }

        private event EventHandler insertTable;
        public event EventHandler InsertTable
        {
            add { insertTable += value; }
            remove { insertTable -= value; }
        }

        private event EventHandler deleteTable;
        public event EventHandler DeleteTable
        {
            add { deleteTable += value; }
            remove { deleteTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        private void txtIDCategory_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
