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

        public static void Update(Entities entities, string[] str)
        {
            switch (entities)
            {
                case Entities.Employee:

                    break;
                case Entities.Department:

                    break;
                case Entities.Document:

                    break;
                case Entities.User:

                    break;
                default:
                    break;
            }
        }

        public static void Insert(Entities entities, string[] str)
        {
            switch (entities)
            {
                case Entities.Employee:
                    cmd = new MySqlCommand("InsertEmployee", Connection.GetConnection());
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = Data.GetNewEmployeeId();
                    cmd.Parameters.Add("@fname", MySqlDbType.VarChar).Value = str[0];
                    cmd.Parameters.Add("@lname", MySqlDbType.VarChar).Value = str[1];
                    cmd.Parameters.Add("@addr", MySqlDbType.Text).Value = str[2];
                    cmd.Parameters.Add("@pos", MySqlDbType.VarChar).Value = str[3];
                    cmd.Parameters.Add("@mobile", MySqlDbType.VarChar).Value = str[4];
                    cmd.Parameters.Add("@homephone", MySqlDbType.VarChar).Value = str[5];
                    cmd.Parameters.Add("@nikv", MySqlDbType.VarChar).Value = str[6];
                    cmd.Parameters.Add("@dept", MySqlDbType.Int32).Value = str[7];
                    cmd.Parameters.Add("@jobtitle", MySqlDbType.VarChar).Value = str[8];
                    cmd.Parameters.Add("@jobdesc", MySqlDbType.VarChar).Value = str[9];
                    cmd.Parameters.Add("@pic", MySqlDbType.Text).Value = str[10];
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(cmd.ExecuteNonQuery() == 1)
                    {
                        Notification.Alert("Employee Data Recorded Succesfully!", Interface.PopNotification.AlertType.Success);
                    }
                    else
                    {
                        Notification.Alert("Error Occured", Interface.PopNotification.AlertType.Error);
                    }
                    break;
                case Entities.Department:
                    cmd = new MySqlCommand("InsertDepartment", Connection.GetConnection());
                    cmd.Parameters.Add("@", MySqlDbType.VarChar).Value = str[0];
                    cmd.Parameters.Add("@", MySqlDbType.Text).Value = str[1];
                    cmd.CommandType = CommandType.StoredProcedure;
                    if(cmd.ExecuteNonQuery() == 1)
                    {
                        Notification.Alert("Department Inserted succesfully!", Interface.PopNotification.AlertType.Success);
                    }
                    else
                    {
                        Notification.Alert("Unknown Error", Interface.PopNotification.AlertType.Error);
                    }
                    break;
                case Entities.Document:
                    break;
                case Entities.User:
                    break;
                default:
                    break;
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
                    if (str[0] == "0")
                    {
                        cmd = new MySqlCommand("GetAllDepartment", Connection.GetConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                        return dt;
                    }
                    else
                    {
                        cmd = new MySqlCommand("GetSpecificDepartment", Connection.GetConnection());
                        cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = str[0];
                        cmd.CommandType = CommandType.StoredProcedure;
                        dataAdapter = new MySqlDataAdapter(cmd);
                        dataAdapter.Fill(dt);
                        return dt;
                    }
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
