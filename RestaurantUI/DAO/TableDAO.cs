using RestaurantUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance {
            get {
                if (instance == null)
                    instance = new TableDAO();
                return TableDAO.instance;
            }
            set => instance = value; 
        }

        private TableDAO() { }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        public void SwitchTable(int tbl1, int tbl2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTabel @idTable1 , @idTabel2", new object[] { tbl1, tbl2 });
        }
        public List<Table> TableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("exec USP_GetTable");
            foreach (DataRow item in data.Rows)
            {
                Table tb = new Table(item);
                tableList.Add(tb);
            }

            return tableList;
        }

        public bool InsertTableFood(string name)
        {
            int result = 0;
            try
            {
                string query = string.Format("INSERT dbo.TableFood( name ) VALUES (N'{0}')", name);
                result = DataProvider.Instance.ExecuteNonQuery(query);
            }
            catch (Exception)
            {

            }

            return result > 0;
        }

        public bool UpdateTableFood(int id, string name)
        {
            string query = string.Format("Update TableFood set name = N'{0}' where id = {1}", name, id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteTableFood(int id)
        {
            var bill = BillDAO.Instance.GetListBill(id);
            foreach (var item in bill)
            {
                BillInfoDAO.Instance.DeleteBillBillInfo(item.Id);
            }

            BillDAO.Instance.DeleteBillByTable(id);
            int result = DataProvider.Instance.ExecuteNonQuery("Delete TableFood where id = " + id);

            return result > 0;
        }

        public List<Table> SearchTableFoodByName(string name)
        {
            List<Table> list = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_searchTable @name", new object[] { name });

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }

            return list;
        }
    }
}
