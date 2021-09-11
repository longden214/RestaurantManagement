using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using RestaurantUI.DAO;
using RestaurantUI.DTO;
using RestaurantUI.Forms;

namespace RestaurantUI
{

    public partial class Form1 : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; changeAccount(loginAccount.Type); }
        }

        public Form1() { }
        public Form1(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;

            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            LoadTable();
            loadCategory();
            loadComboboxTable(cbbTableDashboard);
        }

        #region Method
        void changeAccount(int type)
        {
            btnAccount.Enabled = type == 1;
        }
        void loadComboboxTable(ComboBox cbb)
        {
            cbb.DataSource = TableDAO.Instance.TableList();
            cbb.DisplayMember = "Name";
        }
        void LoadTable()
        {
            flpTableFood.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.TableList();

            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += Btn_Click;
                btn.Tag = item;

                if (item.Status == "Trống")
                {
                    btn.BackColor = Color.LightPink;
                }
                else
                {
                    btn.BackColor = Color.LightGreen;
                }

                flpTableFood.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lstvDashboardFood.Items.Clear();

            List<MenuFood> lstMenu = MenuFoodDAO.Instance.getMenuFood(id);
            float total = 0;
            foreach (MenuFood item in lstMenu)
            {
                ListViewItem lstItem = new ListViewItem(item.FoodName.ToString());
                lstItem.SubItems.Add(item.Count.ToString());
                lstItem.SubItems.Add(item.Price.ToString());
                lstItem.SubItems.Add(item.TotalPrice.ToString());

                total += item.TotalPrice;

                lstvDashboardFood.Items.Add(lstItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
            Thread.CurrentThread.CurrentCulture = culture;

            txtTotalDashboard.Text = total.ToString("c");
        }

        #endregion

        #region Event
        void loadCategory()
        {
            List<Category> list = CategoryDAO.Instance.GetListCategory();
            cbbDashboardCate.DataSource = list;
            cbbDashboardCate.DisplayMember = "name";
        }

        void loadProductByCategory(int id)
        {
            List<Food> list = FoodDAO.Instance.GetListFood(id);
            cbbDashboardFood.DataSource = list;
            cbbDashboardFood.DisplayMember = "name";
        }

        private void Btn_Click(object sender, EventArgs e)
        {

            int idTable = ((sender as Button).Tag as Table).Id;
            lstvDashboardFood.Tag = (sender as Button).Tag;
            ShowBill(idTable);
        }
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(73, 150, 67);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(85, 164, 78);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            lblTitleChildForm.Text = currentBtn.Text;
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormSetting(LoginAccount));
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.TachometerAlt;
            iconCurrentChildForm.IconColor = Color.Gainsboro;
            lblTitleChildForm.Text = "Dashboard";
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
            FormCategory frmCategory = new FormCategory();
            frmCategory.InsertCategory += FrmCategory_InsertCategory;
            frmCategory.UpdateCategory += FrmCategory_UpdateCategory;
            frmCategory.DeleteCategory += FrmCategory_DeleteCategory;

            frmCategory.InsertTable += FrmCategory_InsertTable;
            frmCategory.UpdateTable += FrmCategory_UpdateTable;
            frmCategory.DeleteTable += FrmCategory_DeleteTable;
            OpenChildForm(frmCategory);
        }

        private void FrmCategory_DeleteTable(object sender, EventArgs e)
        {
            loadComboboxTable(cbbTableDashboard);
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
            LoadTable();
        }

        private void FrmCategory_UpdateTable(object sender, EventArgs e)
        {
            loadComboboxTable(cbbTableDashboard);
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
            LoadTable();
        }

        private void FrmCategory_InsertTable(object sender, EventArgs e)
        {
            loadComboboxTable(cbbTableDashboard);
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
            LoadTable();
        }

        private void FrmCategory_DeleteCategory(object sender, EventArgs e)
        {
            loadCategory();
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
        }

        private void FrmCategory_UpdateCategory(object sender, EventArgs e)
        {
            loadCategory();
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
        }

        private void FrmCategory_InsertCategory(object sender, EventArgs e)
        {
            loadCategory();
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            FormFood frmFood = new FormFood();
            frmFood.InsertFood += FrmFood_InsertFood;
            frmFood.DeleteFood += FrmFood_DeleteFood;
            frmFood.UpdateFood += FrmFood_UpdateFood;
            OpenChildForm(frmFood);
        }

        private void FrmFood_UpdateFood(object sender, EventArgs e)
        {
            loadProductByCategory((cbbDashboardCate.SelectedItem as Category).Id);
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
        }

        private void FrmFood_DeleteFood(object sender, EventArgs e)
        {
            loadProductByCategory((cbbDashboardCate.SelectedItem as Category).Id);
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
            LoadTable();
        }

        private void FrmFood_InsertFood(object sender, EventArgs e)
        {
            loadProductByCategory((cbbDashboardCate.SelectedItem as Category).Id);
            if (lstvDashboardFood.Tag != null)
                ShowBill((lstvDashboardFood.Tag as Table).Id);
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
            OpenChildForm(new FormAcount(loginAccount));
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            FormRevenue formRevenue = new FormRevenue();
            formRevenue.InsertFormReport += FormRevenue_InsertFormReport;
            OpenChildForm(formRevenue);
        }

        private void FormRevenue_InsertFormReport(object sender, CheckDateChangedEventArgs e)
        {
            OpenChildForm(new FormReport(e.StartDate, e.EndDate));
        }

        private void btnSetting_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
            OpenChildForm(new FormSetting(LoginAccount));
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }


        private void cbbDashboardCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cbb = sender as ComboBox;
            if (cbb.SelectedIndex == null)
            {
                return;
            }
            Category cate = cbb.SelectedItem as Category;
            id = cate.Id;

            loadProductByCategory(id);
        }

        private void btnAddDashboardFood_Click(object sender, EventArgs e)
        {
            Table tb = lstvDashboardFood.Tag as Table;

            if (tb == null)
            {
                MessageBox.Show("Vui lòng chọn bàn!");
                return;
            }

            int idFood = (cbbDashboardFood.SelectedItem as Food).Id;
            int count = (int)nmSLDashboard.Value;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(tb.Id);
            if (idBill == -1)
            {
                BillDAO.Instance.InsertBill(tb.Id);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIDBill(), idFood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }

            ShowBill(tb.Id);
            LoadTable();
        }



        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lstvDashboardFood.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.Id);
            int discount = (int)nmDiscountDashboard.Value;
            double totalPrice = Convert.ToDouble(txtTotalDashboard.Text.Split(',')[0]);
            double finalTotalPrice = totalPrice - (totalPrice / 100) * discount;

            if (idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc thanh toán hóa đơn cho bàn {0}\n Tổng tiền phải thanh toán  = {1} ", table.Name, finalTotalPrice), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalTotalPrice);
                    ShowBill(table.Id);
                    LoadTable();
                }
            }
        }

        private void btnCBDashboard_Click(object sender, EventArgs e)
        {
            int id1 = (lstvDashboardFood.Tag as Table).Id;

            int id2 = (cbbTableDashboard.SelectedItem as Table).Id;
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (lstvDashboardFood.Tag as Table).Name, (cbbTableDashboard.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
        }

        #endregion
    }
}
