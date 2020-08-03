using Ferma.Helper;
using Ferma.Model;
using System;
using System.Globalization;
using System.Windows;

namespace Ferma.ViewModel
{
    public class AdminWinViewModel : AccessWinViewModel
    {
        #region Constructors
        public AdminWinViewModel()
        {
            MainPage();
        }
        #endregion

        #region Command

        public DelegateCommand IncreaseAccess => new DelegateCommand(IncreaseAccessCommand, () => ParameterClients != null);
        public DelegateCommand LowerAccess => new DelegateCommand(LowerAccessCommand, () => ParameterClients != null);
        public DelegateCommand ClearLog => new DelegateCommand(ClearLogCommand);


        #endregion

        #region Property
        public Client ParameterClients { get; set; }
        #endregion

        #region  Command implementation

        private void ClearLogCommand()
        {
            Logs.Clear();
            LogAddClearLog();
        }

        private void  IncreaseAccessCommand()
        {
            if (ParameterClients.Access == "клиент")
            {
               ParameterClients.Access = "сотрудник";
               Clients.Replace();
                LogAddIncreaseAccess();
            }
            else
            {
                MessageBox.Show("Невозможно повысить доступ");
            }
                 
        }

        private void LowerAccessCommand()
        {
            if (ParameterClients.Access == "сотрудник")
            {
                ParameterClients.Access = "клиент";
                Clients.Replace();
                LogAddLowerAccess();
            }
            else
            {
                MessageBox.Show("Невозможно понизить доступ");
            }
        }

        private void LogAddIncreaseAccess()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Администратор {MainClient.Surname} {MainClient.Name} {MainClient.Middlename} повысил доступ пользователя с логином {ParameterClients.Login}");
        }

        private void LogAddLowerAccess()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Администратор {MainClient.Surname} {MainClient.Name} {MainClient.Middlename} разжаловал пользователя с логином  {ParameterClients.Login}");
        }

        private void LogAddClearLog()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Администратор {MainClient.Surname} {MainClient.Name} {MainClient.Middlename} очистил логи");
        }
        #endregion




    }


}

