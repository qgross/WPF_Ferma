using Ferma.Helper;
using Ferma.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace Ferma.ViewModel
{
    public class ClientWinViewModel : AccessWinViewModel
    {
        #region Constructors

        public ClientWinViewModel()
        {
            MainPage();
        }
        #endregion

        #region Property

        public string OrderSpecialization { get; set; }
        public string OrderBreed { get; set; }
        public string OrderGender { get; set; }
        public string OrderNumber { get; set; }
        public string OrderPrice { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMiddlename { get; set; }
        public string CustomerLogin { get; set; }
        public string Status { get; set; }

        public Productanimal ParameterProduct { get; set; }
        public OrderProductanimal ParameterOrder { get; set; }

        #endregion

        #region Command
        public ObservableCollection<OrderProductanimal> OrderFillter => new ObservableCollection<OrderProductanimal>(OrderProducts.VirtualDatabase.Where(Elements => Elements.CustomerLogin == MainClient.Login));

        public DelegateCommand MakeOrder => new DelegateCommand(MakeOrderCommand, () => ParameterProduct != null );
        public DelegateCommand DeleteOrder => new DelegateCommand(DeleteOrderCommand, () => ParameterOrder != null);
        #endregion

        #region Command implementation
        private void DeleteOrderCommand()
        {
            OrderProducts.Remove(ParameterOrder);
            RaisePropertyChangedEvent(nameof(OrderFillter));
            LogAddDeleteOrder();
        }
        
        private void MakeOrderCommand()
        {
            var orderanimal = new OrderProductanimal();
            orderanimal.OrderSpecialization = ParameterProduct.Specialization;
            orderanimal.OrderBreed = ParameterProduct.Breed;
            orderanimal.OrderGender = ParameterProduct.Gender;
            orderanimal.OrderNumber = ParameterProduct.Number;
            orderanimal.OrderPrice = ParameterProduct.Price;
            orderanimal.CustomerSurname = MainClient.Surname;
            orderanimal.CustomerName = MainClient.Name;
            orderanimal.CustomerMiddlename = MainClient.Middlename;
            orderanimal.CustomerLogin = MainClient.Login;

            orderanimal.Status = null;

            OrderProducts.Add(orderanimal);
            LogAddOrder();
            RaisePropertyChangedEvent(nameof(OrderFillter));
        }
        #endregion

    }
}
