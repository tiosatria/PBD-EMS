using EmployeeManagementSystem.Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Model
{
    public class Data
    {

        const string MasterPath = @"\\192.168.30.100\Dir\";
        public static Employee employee;
        public static List<Employee> employeesList;
        public static int EmployeeCount;
        public static Department department;
        public static List<Department> departmentsList;
        public static string LocalPath { get; set; }
        public static string DbPath { get; set; }

        public static void GetDepartmentList()
        {
            departmentsList = new List<Department>();
            
            DataTable dt = new DataTable();
            dt   = Query.Load(Query.Entities.Department, new string[1] { "0"});
            if(dt.Rows.Count >= 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    department = new Department();
                    department.DeptID = Convert.ToInt32(dt.Rows[i][0].ToString());
                    department.DeptName = dt.Rows[i][1].ToString();
                    department.DeptDesc = dt.Rows[i][2].ToString();
                    departmentsList.Add(department);
                }
            }
        }

        public static void GetDepartment(int i)
        {
            string[] o = new string[1] {i.ToString() };
            Query.Load(Query.Entities.Department, o);
        }

        public static void GetEmployee(int id)
        {
            employee = new Employee(id);

        }



        public static string GetImagePath()
        {
            string str = string.Empty;
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.PNG;*.JPG;*.PNG;*.JPEG) | *.PNG;*.JPG;*.PNG;*.JPEG";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                str = opf.FileName;
                LocalPath = str;
                DbPath = MasterPath + employee.idEmployee + employee.FirstName;
                MessageBox.Show(str);
            }
            return DbPath;
        }

        private static readonly Random random;

        public static int GetNewEmployeeId()
        {
             int i = Convert.ToInt32(DateTime.Now.ToString("yy")+DateTime.Now.ToString("dd")+random.Next(000, 999));
            MessageBox.Show(i.ToString());
            return i;
        }


        public static void GetEmployees()
        {
            DataTable dt = new DataTable();
            employeesList = new List<Employee>();
            dt = Query.Load(Query.Entities.Employee, new string[1] { "0" });
            if(dt.Rows.Count >= 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    employee = new Employee();
                    employee.idEmployee = Convert.ToInt32 (dt.Rows[i][0].ToString());
                    employee.FirstName = dt.Rows[i][1].ToString();
                    employee.LastName = dt.Rows[i][2].ToString();
                    employee.FullName = dt.Rows[i][3].ToString();
                    employee.ResAddress = dt.Rows[i][4].ToString();
                    employee.ResPostCode = dt.Rows[i][5].ToString();
                    employee.Mobile = dt.Rows[i][6].ToString();
                    employee.HomePhone = dt.Rows[i][7].ToString();
                    employee.Nik = dt.Rows[i][8].ToString();
                    employee.DepartmentId = Convert.ToInt32(dt.Rows[i][9].ToString());
                    employee.JobTitle = dt.Rows[i][10].ToString();
                    employee.Desc = dt.Rows[i][11].ToString();
                    employee.picLocation = dt.Rows[i][12].ToString();
                    employee.Department = dt.Rows[i][14].ToString();
                    employeesList.Add(employee);
                }
            }
            else
            {
                Notification.Alert("No Data", Interface.PopNotification.AlertType.Warning);
            }
            EmployeeCount = dt.Rows.Count;
        }
    }
}
