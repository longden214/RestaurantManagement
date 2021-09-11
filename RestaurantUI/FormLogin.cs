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

namespace RestaurantUI
{
    public partial class FormLogin : Form
    {

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Login(txtNameLogin.Text, txtPasswordLogin.Text))
            {
                Account loginAccount = AccountDao.Instance.GetAccountByUserName(txtNameLogin.Text);
                Form1 frm = new Form1(loginAccount);
                frm.Height = 705;
                frm.Width = 1180;
                this.Hide();
                frm.ShowDialog();
                //this.Show();
            }
            else
            {
                MessageBox.Show("Thông tin tài khoản không chính xác!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool Login(string name, string password)
        {
            return AccountDao.Instance.Login(name, password);
        }
    }
}
