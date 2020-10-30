using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EmployeeManagementSystem.Model;

namespace EmployeeManagementSystem.Controller
{
    public class Query
    {
        #region Variable
        public static int SelectedID;
        private static MySqlCommand cmd;
        private static DataTable table;
        public static User usr;
        private static MySqlDataAdapter dataAdapter;
        private static bool _authorized;
        public enum Department
        {
            Management,
            HumanResource,
            User
        }
        private Department _dept;

        public enum Entities
        {
            Employee, Department, Document, User
        }
        private static Entities _entities;
        public enum Operation
        {
            Login, Insert, Update, Delete, Load
        }
        private static Operation _operation;
        #endregion
        public Query()
        {
            
        }

        #region Properties

        #endregion

        #region Function
        public static void Auth(string username, string password)
        {
            _authorized = DoLogin(username, password);
            if(_authorized)
            {
                usr = new User();
                Notification.Alert($"You're logged in! {usr.FullName}", Interface.PopNotification.AlertType.Success); 
                UIController.Navigate(UIController.Controls.LeftPanel);
                UIController.Navigate(UIController.Controls.Dashboard);
            }
            else
            {
                Notification.Alert("We couldn't recognize you", Interface.PopNotification.AlertType.Error);
            }
        }

        public static DataTable Load(Entities entities, string [] str)
        {
            DataTable dt = new DataTable();
            switch (entities)
            {
                case Entities.Employee:
                    //retrieve all employee, put 0 will parse all result
                    if(str[0] == "0")
                    {
                        cmd = new MySqlCommand("GetAllEmployee", Connection.GetConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                        return dt;
                    }
                    else//retrieve selected employee, put employeeid
                    {
                        cmd = new MySqlCommand("GetEmployee", Connection.GetConnection());
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = str[0];
                        cmd.CommandType = CommandType.StoredProcedure;
                        dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                        return dt;
                    }
                    break;
                case Entities.Department:
                    return dt;
                    break;
                case Entities.Document:
                    return dt;
                    break;
                case Entities.User:
                    cmd = new MySqlCommand("GetUserData", Connection.GetConnection());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ownerid", MySqlDbType.Int32).Value = str[0];
                    dataAdapter = new MySqlDataAdapter(cmd);
                    dataAdapter.Fill(dt);
                    return dt;
                    break;
                default:
                    return dt;
                    break;
            }
        }

        private static bool DoLogin(string username, string password)
        {
            try
            {
                cmd = new MySqlCommand("Login", Connection.GetConnection());
                cmd.Parameters.Add("@usr", MySqlDbType.VarChar).Value = username;
                cmd.Parameters.Add("@pwd", MySqlDbType.VarChar).Value = password;
                cmd.CommandType = CommandType.StoredProcedure;
                dataAdapter = new MySqlDataAdapter(cmd);
                table = new DataTable();
                dataAdapter.Fill(table);
                if(table.Rows.Count > 0)
                {
                    SelectedID = Convert.ToInt32(table.Rows[0][0]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {

                return false;
            }
        }
        #endregion
    }
}
