using EmployeeManagementSystem.Controller;
using EmployeeManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem.Model
{
    public class User
    {
        #region Variable

        #endregion

        #region Properties
        public int Uid { get; set; }
        public int OwnerId { get; set; }
        public string Username { get; set; }
        private string _password;
        public string SecretQuestion { get; set; }
        public string SecretAnswer { get; set; }
        public string Password
        {
            get { return null; }
            set { _password = value; }
        }
        private string _UserPicLocation;

        public string UserPicLocation
        {
            get { return _UserPicLocation; }
            set { _UserPicLocation = value; userPic = GetImage(value); }
        }

        public Image userPic { get; set; }
        public static User CurrentUser = null;
        public static Employee Employee = null;

        #endregion
        public User()
        {

        }

        #region Function
        private Image GetImage(string loc)
        {
            try
            {
                using (Image image = Image.FromFile(loc))
                {
                    Bitmap bitmap = new Bitmap(image);
                    image.Dispose();
                    return bitmap;
                }
            }
            catch (Exception)
            {
                Image image = Resources.icons8_male_user_52px;
                return image;
            }
        }
        
        public static bool Auth(string username, string password)
        {
            try
            {
                Int64 id;
                DataTable dt = Query.GetDataTable("Login", new string[2] { "@_usr", "@_pass" }, new MySql.Data.MySqlClient.MySqlDbType[2] { MySql.Data.MySqlClient.MySqlDbType.VarChar, MySql.Data.MySqlClient.MySqlDbType.VarChar }, new string[2] { username, password });
                if (dt.Rows.Count >= 1)
                {
                    try
                    {
                        id = Convert.ToInt64(dt.Rows[0][1].ToString());
                        CurrentUser = new User();
                        Employee = Employee.InitiateEmployee(id);
                        CurrentUser.Username = username;
                        return true;
                    }
                    catch (Exception)
                    {
                        id = 0;
                        return false;
                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Notification.Alert("Something is wrong!" + "Error details: " + ex.Message, Interface.PopUp.AlertType.Error);
                return false;
            }
        }
        //public static bool Insert()
        //{

        //}
        //public static bool Get()
        //{


        //}
        //public static bool GetList()
        //{

        //}
        #endregion


    }
}
