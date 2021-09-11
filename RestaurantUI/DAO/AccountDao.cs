using RestaurantUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI.DAO
{
    class AccountDao
    {
        private static AccountDao instance;

        public static AccountDao Instance {
            get
            {
                if(instance == null) instance = new AccountDao();
                return  instance;
            }
            private set => instance = value; 
        }

        private AccountDao() { }

        public string EncodePassword(string pass)
        {
           
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            return hasPass;
        }
        public bool Login(string name,string password)
        {

            string query = "EXEC USP_Login @username , @password";

            DataTable result = DataProvider.Instance.ExecuteQuery(query,new object[] {name, EncodePassword(password) });

            return result.Rows.Count > 0;
        }

        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from account where userName = '" + username + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }

        public bool UpdateAccount(string userName, string displayName, string pass, string newPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword", new object[] { userName, displayName, EncodePassword(pass), EncodePassword(newPass) });

            return result > 0;
        }

        public DataTable GetAccounts()
        {
            string query = "Select userName as N'Tên đăng nhập' , displayName as N'Tên hiển thị', type as N'Loại tài khoản' from Account";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public DataTable GetAccountType()
        {
            string query = "Select * from AccountType";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        public bool addNewAccount(string username, string displayName, int type)
        {
            int result = 0;
            try
            {
                result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_AddNewAccount @username , @displayName , @type", new object[] { username, displayName, type });
            }
            catch (Exception)
            {

            }
            return result > 0;
        }

        public bool UpdateAccount(string username, string displayName, int type)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("EXEC USP_UpdateAcc @username , @displayName , @type", new object[] { username, displayName, type });

            return result > 0;
        }

        public bool DeleteAccount(string username)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Delete Account where userName = N'" + username + "'");

            return result > 0;
        }

        public bool RessetAccountPassword(string username)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Update Account set passWord = N'20720532132149213101239102231223249249135100218' where userName = N'" + username + "'");

            return result > 0;
        }
        

    }
}
