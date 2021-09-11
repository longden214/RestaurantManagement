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
using RestaurantUI.DAO;

namespace RestaurantUI.Forms
{
    public partial class FormSetting : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount); }
        }
        public FormSetting(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        public void changeAccount(Account acc)
        {
            txtUserNameSetting.Text = loginAccount.UserName;
            txtNameSetting.Text = loginAccount.DisplayName;
        }

        void UpdateAccountInfo()
        {
            string displayName = txtNameSetting.Text;
            string password = txtPwSetting.Text;
            string newpass = txtPwNewSetting.Text;
            string reenterPass = txtNhapLai.Text;
            string userName = txtUserNameSetting.Text;

            if (!newpass.Equals(reenterPass))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu đúng với mật khẩu mới!");
            }
            else
            {
                if (AccountDao.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    
                }
                else
                {
                    MessageBox.Show("Vui lòng điền đúng mật khấu");
                }
            }
        }
        private void btnUpdateSetting_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
