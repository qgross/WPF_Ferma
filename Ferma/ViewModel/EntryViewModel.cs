using Ferma.Helper;
using Ferma.Model;
using Ferma.View;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ferma.ViewModel
{
    public class EntryViewModel : BaseViewModel
    {
        #region Command

        public DelegateCommand CommandEntryWin => new DelegateCommand(Come, VatidationEntry);
        public DelegateCommand CommandRegistration => new DelegateCommand(OpenRegistration);

        #endregion

        #region Property
        public string LoginEntryView { get; set; }
        public static string LoginEntry { get; set; }
        #endregion

        #region  Command implementation

        private void OpenRegistration()
        {
            new Registration().Show();
            CloseAction();
        }

        private bool VatidationEntry(object x)
       {
            var a = (PasswordBox)x;
            if (LoginEntryView == null || a.Password == "") return false;
            else if (ValidationPassword(a.Password)) return false;
            return true;
      }
               
        private void Come(object x)
        {
            var a = (PasswordBox)x;

          LoginEntry = LoginEntryView;
            LoginEntryView = null;

            Client ThisClient = Clients.VirtualDatabase.Where(Elements => Elements.Login == LoginEntry && Elements.Password == a.Password).FirstOrDefault();

            if (ThisClient != null)
            {
                if (ThisClient.Access == "админ")
                {
                    new AdminWin().Show();
                   

                }
                else if (ThisClient.Access == "сотрудник")
                {
                    new EmployeeWin().Show();
                   
                }
                else if (ThisClient.Access == "клиент")
                {
                    new ClientWin().Show();
                   
                }
              
                CloseAction();
            }
            else
            {
                MessageBox.Show("Логин или пароль введены неверно");
            }

        }

        #endregion

    }
}





