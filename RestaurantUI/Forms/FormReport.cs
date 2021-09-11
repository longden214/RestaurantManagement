
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantUI.Forms
{
    public partial class FormReport : Form
    {
        private DateTime StartDate;
        private DateTime EndDate;
        public FormReport(DateTime _StartDate, DateTime _EndDate)
        {
            InitializeComponent();
            StartDate = _StartDate;
            EndDate = _EndDate;
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = Properties.Settings.Default.RestaurantManagementConnectionString1;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "USP_GetListBillByDateForReport";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = conn;

            cmd.Parameters.Add(new SqlParameter("@checkIn", StartDate.Date));
            cmd.Parameters.Add(new SqlParameter("@checkOut", EndDate.Date));

            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);

            reportBills.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportBills.ZoomMode = ZoomMode.Percent;
            reportBills.ZoomPercent = 100;

            reportBills.LocalReport.ReportEmbeddedResource = "RestaurantUI.ReportBill.rdlc";

            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];

                reportBills.LocalReport.DataSources.Clear();
                reportBills.LocalReport.DataSources.Add(rds);
                reportBills.RefreshReport();
            }
        }
    }
}
