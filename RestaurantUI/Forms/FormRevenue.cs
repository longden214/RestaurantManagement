using RestaurantUI.DAO;
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
    public partial class FormRevenue : Form
    {
        public FormRevenue()
        {
            InitializeComponent();
            loadDateTimePickerBill();
            loadBill(dtpStartDate.Value, dtpEndDate.Value, Convert.ToInt32(txtPageCurrent.Text));
            loadTotalPage();
        }

        void loadTotalPage()
        {
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpStartDate.Value, dtpEndDate.Value);
            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            lblTotalPage.Text = lastPage.ToString();
        }
        void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpStartDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpEndDate.Value = dtpStartDate.Value.AddMonths(1).AddDays(-1);
        }
        void loadBill(DateTime checkIn,DateTime checkOut,int numPage)
        {
            dgvRevenue.DataSource = BillDAO.Instance.GetBillByDateAndPage(checkIn, checkOut,numPage); ;
        }
        private void btnRevenue_Click(object sender, EventArgs e)
        {
            loadBill(dtpStartDate.Value,dtpEndDate.Value,Convert.ToInt32(txtPageCurrent.Text));
            loadTotalPage();
            txtPageCurrent.Text = "1";
        }

        private void iconPrevPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPageCurrent.Text);

            if (page > 1)
                page--;

            txtPageCurrent.Text = page.ToString();
        }

        private void iconNextPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPageCurrent.Text);
            int sumRecord = BillDAO.Instance.GetNumBillListByDate(dtpStartDate.Value, dtpEndDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;

            if (page < lastPage)
                page++;

            txtPageCurrent.Text = page.ToString();
        }

        private void txtPageCurrent_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void txtPageCurrent_TextChanged(object sender, EventArgs e)
        {
            dgvRevenue.DataSource = BillDAO.Instance.GetBillByDateAndPage(dtpStartDate.Value, dtpEndDate.Value, Convert.ToInt32(txtPageCurrent.Text));

        }

        private void btnReportBill_Click(object sender, EventArgs e)
        {
            if (insertFormReport != null)
                insertFormReport(this, new CheckDateChangedEventArgs(dtpStartDate.Value, dtpEndDate.Value));
        }

        private event EventHandler<CheckDateChangedEventArgs> insertFormReport;
        public event EventHandler<CheckDateChangedEventArgs> InsertFormReport
        {
            add { insertFormReport += value; }
            remove { insertFormReport -= value; }
        }
    }

    public class CheckDateChangedEventArgs : EventArgs
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public CheckDateChangedEventArgs(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
