using Ferma.Helper;
using Ferma.Model;
using Ferma.View;
using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Ferma.ViewModel
{

    public class RegistrationVeiwModel : BaseViewModel
    {
            
        #region Command

        public DelegateCommand CommandEntry => new DelegateCommand(Save, ValidationReg);
        public DelegateCommand CommandEntryNoReg => new DelegateCommand(EntryNoReg);

        #endregion

        #region Property

        private string _surname;
        public string Surname
        {
            get => _surname; set
            {
                _surname = value;
                RaisePropertyChangedEvent(nameof(Surname));
            }
        }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Login { get; set; }
        public string GenderClient { get; set; }
        public string Access { get; set; } = "клиент";

        #endregion

        #region Command implementation

        private void EntryNoReg()
        {
            new Entry().Show();
            CloseAction();
        }

        private bool ValidationReg(object x)

        {
            var a = (PasswordBox)x;
            if ((Surname == null) || (Name == null) || (Middlename == null) || (a.Password == "")  || (Login == null) || (GenderClient == null))
            {
                return false;
            }
            else if (ValidationText(Surname) || ValidationText(Name) || ValidationText(Middlename) || ValidationPassword(a.Password)) return false;
            return true;
        }
        
        private void LogAddNewClient()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Пользователь {Surname} {Name} {Middlename}  зарегистрировался");

        }
      
        private void Save(object x)
        {
            var a = (PasswordBox)x;

          
                {
                    var client = new Client();

                    client.Password = a.Password;
                    client.Name = Name;
                    client.Middlename = Middlename;
                    client.Surname = Surname;
                    client.Login = Login;
                    client.GenderClient = GenderClient;
                    client.Access = Access;

                    Client ThisClientReg = Clients.VirtualDatabase.Where(Elements => Elements.Login == Login).FirstOrDefault();
                    
                if (ThisClientReg != null)
                {
                    MessageBox.Show("Пользователь с данным логином уже зарегистрирован");
                }
                  else  Clients.Add(client);


                new Entry().Show();
                    LogAddNewClient();
                    CloseAction();

                }
           

            

        }
        #endregion
    }
}
