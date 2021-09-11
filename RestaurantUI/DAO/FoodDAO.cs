using RestaurantUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI.DAO
{
    class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new FoodDAO();
                return FoodDAO.instance;
            }
            set => instance = value;
        }

        private FoodDAO() { }

        public List<Food> GetListFood(int id)
        {
            List<Food> list = new List<Food>();
            string query = "Select * from Food where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public List<Food> GetFoods()
        {
            List<Food> list = new List<Food>();
            string query = "Select * from Food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public bool addNewFood(string name,int idcategory,float price)
        {
            int result = 0;
            try
            {
                result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_AddNewFood @name , @idCategory , @price",new object[] { name,idcategory,price });
            }
            catch (Exception)
            {

            }
            return result > 0;
        }

        public bool UpdateFood(int id,string name, int idcategory, float price)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateFood @id , @name , @idCategory , @price", new object[] { id, name, idcategory, price });

            return result > 0;
        }

        public bool DeleteFood(int id)
        {
            BillInfoDAO.Instance.DeleteFoodBillInfo(id);
            int result = DataProvider.Instance.ExecuteNonQuery("Delete Food where id = " + id);

            return result > 0;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> list = new List<Food>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_searchFood @name",new object[] { name});

            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }

            return list;
        }

        public void DeleteCategoryByFood(int idcate)
        {
            DataProvider.Instance.ExecuteNonQuery("Delete Food where idCategory = " + idcate);
        }
    }
}
