using EmployeeManagementSystem.Controller;
using EmployeeManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem.Model
{


    public class Employee
    {
        public Employee()
        {

        }
        #region Properties
        public Int64 idEmployee
        {
            get;
            set;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string ResAddress { get; set; }
        public string ResPostCode { get; set; }
        public string Mobile { get; set; }
        public string HomePhone { get; set; }
        public string Nik { get; set; }
        public string Department { get; set; }
        public int DepartmentId { get; set; }
        public string JobTitle { get; set; }
        public string Desc { get; set; }
        public string Role { get; set; }
        public string picLocation { get; set; }
        public Employee CurrentEmployee = null;
        #endregion

        #region Function
        public static Employee InitiateEmployee(Int64 id)
        {
            Model.Employee e = new Employee();
            DataTable dt = Query.GetDataTable("GetEmployee", new string[1] { "@_IDEmployee" }, new MySql.Data.MySqlClient.MySqlDbType[1] { MySql.Data.MySqlClient.MySqlDbType.Int64 }, new string[1] { id.ToString() });
            DataRowCollection dr = dt.Rows;
            if (dt.Rows.Count >= 1)
            {
                e.idEmployee = id;
                e.FirstName = dr[0][1].ToString();
                e.LastName = dr[0][2].ToString();
                e.FullName = e.FirstName + " " + e.LastName;
                e.ResAddress = dr[0][3].ToString();
                e.ResPostCode = dr[0][4].ToString();
                e.Mobile = dr[0][5].ToString();
                e.HomePhone = dr[0][6].ToString();
                e.Nik = dr[0][7].ToString();
                e.DepartmentId = Convert.ToInt32(dr[0][8].ToString());
                e.Role = dr[0][9].ToString();
                e.JobTitle = dr[0][10].ToString();
                e.Desc = dr[0][11].ToString(); 
                e.picLocation = dr[0][12].ToString();
                e.Department = dr[0][14].ToString();
            }
            return e;
        }
        //public static Employee Get()
        //{

        //}
        //public static List<Employee> GetEmployees()
        //{

        //}
        //public static bool Insert()
        //{

        //}
        //public static bool Delete()
        //{

        //}
        #endregion

    }




}
