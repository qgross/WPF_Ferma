using Ferma.Helper;
using Ferma.Model;
using Ferma.View;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Ferma.ViewModel
{
    public class BaseViewModel : ObservableObject
    {
        #region Command

        public DelegateCommand CommandClose => new DelegateCommand(() => CanClose());
        public DelegateCommand CommandLeftFirst => new DelegateCommand(CloseWin);

        #endregion

        #region BD

        public Database<Client> Clients { get; set; } = new Database<Client>("Client");

        public Database<String> Logs { get; set; } = new Database<String>("Logs");

        #endregion
       
        #region Property
        public Action CloseAction { get; set; }
        #endregion

        #region Command implementation
        private void CanClose()
        {
            var a = MessageBox.Show("Вы действительно хотите закрыть программу?", "", MessageBoxButton.YesNo);
            if (a == MessageBoxResult.Yes)
            {
                App.Current.Shutdown();
            }

        }

        private void CloseWin()
        {
            new First().Show();
            CloseAction();
        }

        protected bool ValidationText(string value)
        {

            Regex validation = new Regex(@"^[а-яА-ЯёЁa-zA-Z]+$");
            if (validation.IsMatch(value)) return false;
            return true;
        }

        protected bool ValidationPassword(string value)
        {

            Regex validation = new Regex(@"[0-9a-zA-Z!@#$%^&*]{6,}");
            if (validation.IsMatch(value)) return false;
            return true;
        }
        #endregion
    }


}
