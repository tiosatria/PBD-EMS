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
        public Employee(int id)
        {
            GetEmployeeData(id);
        }

        #region Properties
        public int idEmployee
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
        public string picLocation { get; set; }
        

        #endregion

        #region Function
        private void GetEmployeeData(int id)
        {
            DataTable dt = new DataTable();
            dt = Query.Load(Query.Entities.Employee, new string[1] { id.ToString() });
        }

        public void SaveEmployeeData()
        {
            string[] str = new string[11];
            str[0] = FirstName;
            str[1] = LastName;
            str[2] = ResAddress;
            str[3] = ResPostCode;
            str[4] = Mobile;
            str[5] = HomePhone;
            str[6] = Nik;
            str[7] = DepartmentId.ToString();
            str[8] = JobTitle;
            str[9] = Desc;
            str[10] = picLocation;
            Query.Insert(Query.Entities.Employee, str);
        }

        public static void UpdateEmployeeData()
        {

        }
        

        #endregion

    }




}
