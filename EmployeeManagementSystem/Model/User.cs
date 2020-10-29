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
        public string Password
        {
            get { return null; }
            set { _password = value; }
        }
        private Image _userimg;

        public Image UserImg
        {
            get { return _userimg; }
            set { _userimg = value; }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int DeptId { get; set; }
        public string Department { get; set; }
        #endregion
        public User()
        {
            GetUserData(Query.SelectedID);
        }

        #region Function
        public void GetUserData(int id)
        {
            DataTable dt = Query.Load(Query.Entities.User, new string[1] {id.ToString() });
            Uid = Convert.ToInt32(dt.Rows[0][0]);
            OwnerId = Convert.ToInt32(dt.Rows[0][1].ToString());
            Username = dt.Rows[0][2].ToString();
            Password = dt.Rows[0][3].ToString();
            FirstName = dt.Rows[0][4].ToString();
            LastName = dt.Rows[0][5].ToString();
            FullName = dt.Rows[0][6].ToString();
            try
            {
                UserImg = Image.FromFile(dt.Rows[0][7].ToString());

            }
            catch (Exception)
            {
                UserImg = Resources.icons8_male_user_52px;
            }
        }
        #endregion


    }
}
