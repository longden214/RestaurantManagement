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
    public partial class FormFood : Form
    {
        BindingSource foodList = new BindingSource();
        public FormFood()
        {
            InitializeComponent();
            LoadFood();
            LoadFoodBinding();
            LoadCategoryFood();
        }

        void LoadFoodBinding()
        {

            txtIDFood.DataBindings.Add(new Binding("Text",dgvFoods.DataSource,"Id",true,DataSourceUpdateMode.Never));
            txtNameFood.DataBindings.Add(new Binding("Text", dgvFoods.DataSource, "Name", true, DataSourceUpdateMode.Never));
            nmPriceFood.DataBindings.Add(new Binding("Value", dgvFoods.DataSource, "Price", true, DataSourceUpdateMode.Never));
            cbbCateFood.DataBindings.Add(new Binding("SelectedValue", dgvFoods.DataSource, "CategoryId", true,DataSourceUpdateMode.Never));

        }

        void LoadFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetFoods();
            dgvFoods.DataSource = foodList;
        }

        void LoadCategoryFood()
        {
            cbbCateFood.DataSource = CategoryDAO.Instance.GetListCategory();
            cbbCateFood.DisplayMember = "name";
            cbbCateFood.ValueMember = "id";
        }

        List<Food> SearchFoods(string name)
        {
            List<Food> data = FoodDAO.Instance.SearchFoodByName(name);

            return data;
        }

        private void btnAddNewFood_Click(object sender, EventArgs e)
        {
            string name = txtNameFood.Text;
            int idCategory = Convert.ToInt32(cbbCateFood.SelectedValue);
            float price = (float) Convert.ToDouble(nmPriceFood.Value.ToString());
            if (FoodDAO.Instance.addNewFood(name,idCategory,price))
            {
                MessageBox.Show("Thêm mới thành công!","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelFood_Click(object sender, EventArgs e)
        {
            LoadFood();
            foodList.CancelEdit();
        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDFood.Text);
            string name = txtNameFood.Text;
            int idCategory = Convert.ToInt32(cbbCateFood.SelectedValue);
            float price = (float)Convert.ToDouble(nmPriceFood.Value.ToString());
            if (FoodDAO.Instance.UpdateFood(id,name, idCategory, price))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtIDFood.Text);
            
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            dgvFoods.DataSource = SearchFoods(txtSearchFood.Text);
        }
    }
}
