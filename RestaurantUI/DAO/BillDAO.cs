using RestaurantUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI.DAO
{
    class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO() { }
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.Id;
            }

            return -1;
        }

        public void CheckOut(int id,int discount,float totalPrice)
        {
            string query = "UPDATE Bill set dateCheckOut = GetDate(), status = 1 , discount = " + discount + ", totalPrice = " + totalPrice + " where id = " + id;
            DataProvider.Instance.ExecuteQuery(query);
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] { id });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM dbo.Bill");
            }
            catch
            {
                return 1;
            }
        }

        public DataTable GetBillByDate(DateTime ckIn,DateTime ckOut)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDate @dateCheckIn , @dateCheckOut", new object[] { ckIn,ckOut });
        }

        public DataTable GetBillByDateAndPage(DateTime ckIn, DateTime ckOut,int numPage)
        {
            return DataProvider.Instance.ExecuteQuery("EXEC USP_GetListBillByDateAndPage @dateCheckIn , @dateCheckOut , @numPage", new object[] { ckIn, ckOut,numPage });
        }

        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)DataProvider.Instance.ExecuteScalar("exec USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }

        public List<Bill> GetListBill(int id)
        {
            List<Bill> list = new List<Bill>();
            string query = "SELECT * FROM dbo.Bill WHERE idTable = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Bill bill = new Bill(item);
                list.Add(bill);
            }

            return list;
        }

        public void DeleteBillByTable(int idBill)
        {
            DataProvider.Instance.ExecuteNonQuery("Delete Bill where idTable = " + idBill);
        }
    }
}
