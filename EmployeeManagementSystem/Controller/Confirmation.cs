using EmployeeManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem.Controller
{

    public class Confirmation
    {
        public static string Title;
        public static string Subtitle;
        public static Image img;
        public static string yesDisplay;
        public static string noDisplay;

        public enum Type { Exit, DeleteEmployee }

        public Confirmation()
        {

        }

        private static Type _type;

        public static void SetDialog(UIController.Controls controls)
        {
            switch (controls)
            {
                case UIController.Controls.LeftPanel:
                    
                    break;
                case UIController.Controls.LeftPanelExpand:
                    
                    break;
                case UIController.Controls.Login:
                    
                    break;
                case UIController.Controls.UpperPanel:
                    
                    break;
                case UIController.Controls.Dashboard:

                    break;
                case UIController.Controls.Exit:
                    Title = "Exit Application";
                    Subtitle = "Are you sure you want to quit application?\nAny unsaved data will be lost!";
                    yesDisplay = "Yes, let me go";
                    noDisplay = "No, let me stay";
                    img = Resources.icons8_question_mark_480px;
                    _type = Type.Exit;
                    break;
                case UIController.Controls.Employee:
                    break;
                case UIController.Controls.DeleteEmp:
                    Title = "Delete Employee Data";
                    Subtitle = "You're attempting to delete this Employee Data!, are you sure you want to continue?";
                    yesDisplay = "Yes, let me delete it!";
                    noDisplay = "No, it was a mistake!";
                    img = Resources.icons8_question_mark_480px;
                    _type = Type.DeleteEmployee;
                    break;
                default:
                    break;
            }

        }

        public static void Yes()
        {
            switch (_type)
            {
                case Type.Exit:
                    Application.Exit();
                    break;
                case Type.DeleteEmployee:
                    MessageBox.Show("Deleted");
                    UIController.SendToBack(UIController.Controls.Exit);
                    break;
                default:
                    break;
            }
        }
        public static void No()
        {
            switch (_type)
            {
                case Type.Exit:
                    UIController.SendToBack(UIController.Controls.Exit);
                    break;
                case Type.DeleteEmployee:
                    UIController.SendToBack(UIController.Controls.Exit);
                    break;
                default:
                    break;
            }
        }
    }



}
