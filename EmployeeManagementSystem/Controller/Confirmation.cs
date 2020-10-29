using EmployeeManagementSystem.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controller
{

    public class Confirmation
    {
        public static string Title;
        public static string Subtitle;
        public static Image img;
        public static string yesDisplay;
        public static string noDisplay;

        public enum Type { Exit }

        public Confirmation()
        {

        }

        private static Type _type;

        public static void Yes(Type typ)
        {
            _type = typ;
            switch (typ)
            {
                case Type.Exit:
                    break;
                default:
                    break;
            }
        }
        public static void No(Type typ)
        {
            _type = typ;
            switch (typ)
            {
                case Type.Exit:
                
                    break;
                default:
                    break;
            }
        }
    }



}
