using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using EmployeeManagementSystem.Interface;
using System.Diagnostics.Eventing.Reader;
using Telerik.WinControls.VirtualKeyboard;
using System.Configuration;
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using Telerik.WinControls.UI;
using EmployeeManagementSystem.Properties;

namespace EmployeeManagementSystem.Controller
{
    public class UIController
    {
        #region Properties
        #region InterfaceComponent
        private static Login login = new Login();
        private static UpperPanel upperDefault = new UpperPanel();
        private static LeftPanel leftPanel = new LeftPanel();
        private static Dashboard dashboard = new Dashboard();
        private static DialogYesNo dialog = new DialogYesNo();
        private static Employee employee = new Employee();
        #endregion

        public enum Controls { LeftPanel, LeftPanelExpand, Login, UpperPanel, Dashboard, Exit, Employee }
        private static Controls _controls;
        public enum DockType { top, fill, left }
        private static DockType _dock;
        public enum UpperPanelEnum { def }
        private static UpperPanelEnum _up;
        static Form mainform = Application.OpenForms[0];
        private static UserControl ctrl;
        #endregion

        public UIController()
        {

        }
        #region Function
        //navigate
        public static void Navigate(Controls ctr)
        {
            UserControl control = null;
            _controls = ctr;
            switch (ctr)
            {
                case Controls.LeftPanel:
                    mainform.Controls.Add(leftPanel);
                    SetControl(leftPanel, DockType.left);
                    leftPanel.InitializeObject();
                    break;
                case Controls.LeftPanelExpand:

                    break;
                case Controls.Login:
                    mainform.Controls.Add(login);
                    SetControl(login, DockType.fill);
                    login.InitializeObject();
                    break;
                case Controls.UpperPanel:
                    mainform.Controls.Add(upperDefault);
                    SetControl(upperDefault, DockType.top);
                    break;
                case Controls.Dashboard:
                    mainform.Controls.Add(dashboard);
                    SetControl(dashboard, DockType.fill);
                    dashboard.InitializeObject();
                    break;
                case Controls.Exit:
                    mainform.Controls.Add(dialog);
                    SetControl(dialog, DockType.fill);
                    Confirmation.Title = "Exit Application";
                    Confirmation.Subtitle = "Are you sure you want to quit application?\nAny unsaved data will be lost!";
                    Confirmation.yesDisplay = "Yes, let me go";
                    Confirmation.noDisplay = "No, let me stay";
                    Confirmation.img = Resources.icons8_question_mark_480px;
                    dialog.InitializeObject();
                    dialog.BringToFront();
                    break;
                case Controls.Employee:
                    mainform.Controls.Add(employee);
                    SetControl(employee, DockType.fill);
                    employee.InitializeObject();
                    employee.BringToFront();
                    break;
            }
        }

        public static void SetControl(UserControl userControl, DockType dockType)
        {
            switch (dockType)
            {
                case DockType.top:
                    userControl.BringToFront();
                    userControl.Dock = DockStyle.Top;
                    break;
                case DockType.fill:
                    userControl.BringToFront();
                    userControl.Dock = DockStyle.Fill;
                    break;
                case DockType.left:
                    userControl.BringToFront();
                    userControl.Dock = DockStyle.Left;
                    break;
                default:
                    userControl.BringToFront();
                    userControl.Dock = DockStyle.Fill;
                    break;
            }
        }

        #endregion
    }
}
