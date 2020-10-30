using EmployeeManagementSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controller
{
    public class Notification
    {
        public Notification()
        {

        }
        public static void Alert(string msg, PopNotification.AlertType type)
        {
            var f = new PopNotification();
            f.setAlert(msg, type);
        }
    }
}
