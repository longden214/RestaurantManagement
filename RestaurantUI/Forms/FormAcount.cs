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
    public partial class FormAcount : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value;}
        }

        BindingSource AccountList = new BindingSource();
        public FormAcount(Account account)
        {
            InitializeComponent();

            loginAccount = account;
            loadAccount();
            LoadAccountBinding();
            loadAccountType();
        }

        void loadAccount()
        {
            AccountList.DataSource = AccountDao.Instance.GetAccounts();
            dgvAccounts.DataSource = AccountList;
        }

        void LoadAccountBinding()
        {
            txtTenTK.DataBindings.Add("Text", dgvAccounts.DataSource, "Tên đăng nhập",true,DataSourceUpdateMode.Never);
            txtTenHT.DataBindings.Add("Text", dgvAccounts.DataSource, "Tên hiển thị", true, DataSourceUpdateMode.Never);
            cbbAccountType.DataBindings.Add(new Binding("SelectedValue", dgvAccounts.DataSource, "Loại tài khoản", true, DataSourceUpdateMode.Never));

        }

        void loadAccountType()
        {
            cbbAccountType.DataSource = AccountDao.Instance.GetAccountType();
            cbbAccountType.DisplayMember = "name";
            cbbAccountType.ValueMember = "id";
        }

        private void btnAccountAdd_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text;
            int Type = Convert.ToInt32(cbbAccountType.SelectedValue);
            string displayname = txtTenHT.Text;
            if (AccountDao.Instance.addNewAccount(username, displayname, Type))
            {
                MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadAccount();
            }
            else
            {
                MessageBox.Show("Thêm mới thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccountUpdate_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text;
            int Type = Convert.ToInt32(cbbAccountType.SelectedValue);
            string displayname = txtTenHT.Text;
            if (AccountDao.Instance.UpdateAccount(username, displayname, Type))
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadAccount();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccountDelete_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text;

            if (loginAccount.UserName.Equals(username))
            {
                MessageBox.Show("Tài khoản đang đăng nhập!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (AccountDao.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadAccount();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAccountCancel_Click(object sender, EventArgs e)
        {
            AccountList.CancelEdit();
        }

        private void btnAccountResset_Click(object sender, EventArgs e)
        {
            string username = txtTenTK.Text;

            if (AccountDao.Instance.RessetAccountPassword(username))
            {
                MessageBox.Show("Resset thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadAccount();
            }
            else
            {
                MessageBox.Show("Resset thất bại!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
