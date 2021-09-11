using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI.DTO
{
    public class Bill
    {
        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;
        private int discount;

        
        public Bill(DataRow row)
        {
            Id = (int)row["id"];
            DateCheckIn = (DateTime?)row["dateCheckIn"];

            if (row["dateCheckOut"] != DBNull.Value)
            {
                DateCheckOut = (DateTime?)row["dateCheckOut"];
            }
            Status = (int)row["status"];
            if (row["discount"] != DBNull.Value)
            {
                Discount = (int)row["discount"];
            }
        }

        public Bill(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount = 0)
        {
            this.id = id;
            this.dateCheckIn = dateCheckIn;
            this.dateCheckOut = dateCheckOut;
            this.status = status;
            this.discount = discount;
        }

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
