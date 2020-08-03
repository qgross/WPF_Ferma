using Ferma.Model;
using System;
using System.Globalization;
using System.Linq;

namespace Ferma.ViewModel
{
    public class AccessWinViewModel : BaseViewModel
    {
        #region BD
        public Database<Productanimal> Products { get; set; } = new Database<Productanimal>("Productanimal");
        public Database<OrderProductanimal> OrderProducts { get; set; } = new Database<OrderProductanimal>("OrderProductanimal");
        #endregion

        #region Property
        public Client MainClient { get; set; }
        #endregion

        #region Constructors
        public void MainPage()
        {

            MainClient = Clients.VirtualDatabase.Where(Elements => Elements.Login == EntryViewModel.LoginEntry).First();

            var mainclient = new Client();
            mainclient.Name = MainClient.Name;
            mainclient.Surname = MainClient.Surname;
            mainclient.Middlename = MainClient.Middlename;
            mainclient.GenderClient = MainClient.GenderClient;
            mainclient.Login = MainClient.Login;
            LogAddEntryClient();
        }
        #endregion

        #region   Command implementation
        protected void LogAddDeleteOrder()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Клиент {MainClient.Surname} {MainClient.Name} {MainClient.Middlename}  удалил свой заказ");

        }

        protected void LogAddOrder()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Клиент {MainClient.Surname} {MainClient.Name} {MainClient.Middlename}  добавил новый заказ");
        }

        protected void LogAddInfAnimal()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Сотрудник {MainClient.Surname} {MainClient.Name} {MainClient.Middlename}  добавил информацию о новом животном");

        }

        protected void LogAddDeleteInfAnimal()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Сотрудник {MainClient.Surname} {MainClient.Name} {MainClient.Middlename}  удалил информацию о новом животном");

        }

        protected void LogAddApproveOrder()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Сотрудник {MainClient.Surname} {MainClient.Name} {MainClient.Middlename}  одобрил заказ");

        }
        protected void LogAddRejectOrder()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Сотрудник {MainClient.Surname} {MainClient.Name} {MainClient.Middlename}  отклонил заказ");

        }

        protected void LogAddEntryClient()
        {
            Logs.Add($"{DateTime.Now.ToString(new CultureInfo("ru-RU"))} Пользователь {MainClient.Surname} {MainClient.Name} {MainClient.Middlename} аутентифицировался ");

        }
        #endregion


    }
}
