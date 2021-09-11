using RestaurantUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI.DAO
{
    class MenuFoodDAO
    {
        private static MenuFoodDAO instance;

        public static MenuFoodDAO Instance {
            get
            {
                if (instance == null)
                    instance = new MenuFoodDAO();
                return MenuFoodDAO.instance;
            }
            set => instance = value; 
        }

        private MenuFoodDAO() { }

        public List<MenuFood> getMenuFood(int id)
        {
            List<MenuFood> listMenu = new List<MenuFood>();

            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC GetListMenuByTable @idTable",new object[] {id});

            foreach (DataRow item in data.Rows)
            {
                MenuFood menu = new MenuFood(item);
                listMenu.Add(menu);
            }

            return listMenu;
        }
    }
}
