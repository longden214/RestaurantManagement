using RestaurantUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI.DAO
{
    class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CategoryDAO();
                return CategoryDAO.instance;
            }
            set => instance = value;
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "Select * from Category";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category cate = new Category(item);
                list.Add(cate);
            }
            return list;
        }

        public bool InsertCategory(string name)
        {
            int result = 0;
            try
            {
                string query = string.Format("INSERT dbo.Category( name ) VALUES (N'{0}')", name);
                result = DataProvider.Instance.ExecuteNonQuery(query);
            }
            catch (Exception)
            {
                
            }
            
            return result > 0;
        }

        public bool UpdateCategory(int id,string name)
        {
            string query = string.Format("Update Category set name = N'{0}' where id = {1}", name,id);

            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }

        public bool DeleteCategory(int id)
        {
            var food = FoodDAO.Instance.GetListFood(id);
            foreach (var item in food)
            {
                BillInfoDAO.Instance.DeleteFoodBillInfo(item.Id);
            }

            FoodDAO.Instance.DeleteCategoryByFood(id);
            int result = DataProvider.Instance.ExecuteNonQuery("Delete Category where id = " + id);

            return result > 0;
        }

        public List<Category> SearchCategoryByName(string name)
        {
            List<Category> list = new List<Category>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_searchCategory @name", new object[] { name });

            foreach (DataRow item in data.Rows)
            {
                Category cate = new Category(item);
                list.Add(cate);
            }

            return list;
        }
    }
}
