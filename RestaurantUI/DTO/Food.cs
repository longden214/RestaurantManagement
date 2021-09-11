using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI.DTO
{
    class Food
    {
        private int id;
        private string name;
        private int categoryId;
        private float price;

        public Food(int id, string name, int categoryId, float price)
        {
            this.id = id;
            this.name = name;
            this.categoryId = categoryId;
            this.price = price;
        }

        public Food(DataRow row)
        {
            this.id = (int) row["id"];
            this.name = row["name"].ToString();
            this.categoryId = (int)row["idCategory"];
            this.price = (float) Convert.ToDouble(row["price"].ToString());
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public float Price { get => price; set => price = value; }
    }
}
