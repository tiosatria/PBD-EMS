using EmployeeManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using EmployeeManagementSystem.Interface;
using System.Linq;
using EmployeeManagementSystem;
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
        private static DialogYesNo control = new DialogYesNo();
        public Confirmation()
        {

        }
        private static Type _type;

        public static void Fire(Type type, string title, string subtitle, Image image, string yes, string no)
        {
            _type = type;
            control.Title = title;
            control.Subtitle = subtitle;
            control.ImageDialog = image;
            control.YesText = yes;
            control.NoText = no;
            control.InitializeObject();
        }

        public static void Yes()
        {
            switch (_type)
            {
                case Type.Exit:

                    break;
                case Type.DeleteEmployee:

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
                    break;
                case Type.DeleteEmployee:
                    break;
                default:
                    break;
            }
        }
    }
}
