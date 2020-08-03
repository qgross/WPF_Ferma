using Ferma.Helper;
using Ferma.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace Ferma.ViewModel
{
    public class EmployeeWinViewModel : AccessWinViewModel
    {

        #region Constructors
        public EmployeeWinViewModel()
        {
            MainPage();
        }
        #endregion

        #region Command



        public DelegateCommand InfAnimal => new DelegateCommand(GetInfAnimal, ValidationInfAnimal);

        public DelegateCommand ApproveOrder => new DelegateCommand(ApproveOrderCommand, () => ParameterOrder != null);

        public DelegateCommand RejectOrder => new DelegateCommand(RejectOrderCommand, () => ParameterOrder != null);

        public DelegateCommand DeleteAnimal => new DelegateCommand(DeleteAnimalCommand, () => ParameterAnimal != null);



        #endregion

        #region Property
        private Visibility _visibility;
        private string _specialization;
        private string _gender;
        private DateTime? _dOB;
        private string _breed;
        private string _number;
        private string _milk;
        private string _weight;
        private string _price;

        public Visibility Visibility
        {
            get => _visibility; set
            {
                _visibility = value;
                RaisePropertyChangedEvent(nameof(Visibility));
            }
        }

        public string Specialization
        {
            get => _specialization; set
            {
                _specialization = value;
                RaisePropertyChangedEvent(nameof(Specialization));
                RaisePropertyChangedEvent(nameof(Visibility));
                ChangeVisibility();
            }
        }

        public string Breed
        {
            get => _breed;
            set
            {
                _breed = value;
                RaisePropertyChangedEvent(nameof(Breed));


            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                RaisePropertyChangedEvent(nameof(Gender));
                RaisePropertyChangedEvent(nameof(Visibility));
                RaisePropertyChangedEvent(nameof(Price));
                ChangeVisibility();
                ChangePrice();
            }
        }    
        public DateTime?  DOB
        {
            get => _dOB;
            set
            {
                _dOB = value;
                RaisePropertyChangedEvent(nameof(DOB));
               
            }
        }
        public string Number
        {
            get => _number;
            set
            {
                _number = value;
                RaisePropertyChangedEvent(nameof(Number));
               
            }
        }
        public string Milk
        {
            get => _milk;
            set
            {
                _milk = value;
                RaisePropertyChangedEvent(nameof(Milk));
                RaisePropertyChangedEvent(nameof(Price));
                ChangePrice();
            }
        }
        public string Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                RaisePropertyChangedEvent(nameof(Weight));
                RaisePropertyChangedEvent(nameof(Price));
                ChangePrice();
            }
        }
        public string Price
        {
            get => _price;
            private set
            {
                _price = value;
                RaisePropertyChangedEvent(nameof(Price));

            }
        }

        public OrderProductanimal ParameterOrder { get; set; }
        public Productanimal ParameterAnimal { get; set; }

        #endregion

        #region Command implementation

        private void ChangeVisibility()
        {
            if ((Specialization == "Молочная" || Specialization == "Мясомолочная") && Gender == "Взрослая коза") { Visibility = Visibility.Visible; }
            else Visibility = Visibility.Collapsed;
        }

        private void ChangePrice()
        {
            if (Gender == "Взрослая коза" && int.TryParse(Milk, out var milk) && milk >= 500 && int.TryParse(Weight, out var weight) && weight >= 60) Price = "5000";
            else if ((Gender == "Взрослый козел-производитель" || Gender == "Взрослый козел на откорме") && (int.Parse(Weight) == 80 || int.Parse(Weight) > 80)) Price = "4000";
            else Price = "3000";
        }


        private void DeleteAnimalCommand()
        {
            Products.Remove(ParameterAnimal);
            LogAddDeleteInfAnimal();
        }

        private void ApproveOrderCommand()
        {
            if (ParameterOrder.Status == null || ParameterOrder.Status == "заказ отклонен")
            {
                ParameterOrder.Status = "заказ одобрен";
                OrderProducts.Replace();
                LogAddApproveOrder();
            }
            else
            {
                MessageBox.Show("Заказ уже одобрен");
            }


        }

        private void RejectOrderCommand()
        {
            if (ParameterOrder.Status == null || ParameterOrder.Status == "заказ одобрен")
            {
                ParameterOrder.Status = "заказ отклонен";
                OrderProducts.Replace();
                LogAddRejectOrder();
            }
            else
            {
                MessageBox.Show("Заказ уже отклонен");
            }
        }

        private void GetInfAnimal()
        {
            var animalproduct = new Productanimal();

            animalproduct.Specialization = Specialization;
            animalproduct.Breed = Breed;
            animalproduct.Gender = Gender;
            animalproduct.DOB = (DateTime)DOB;
            animalproduct.Number = Number;
            animalproduct.Milk = Milk;
            animalproduct.Weight = Weight;
            animalproduct.Price = Price;

            Products.Add(animalproduct);
            LogAddInfAnimal();

            Gender = null;
            Specialization = null;
            Breed = null;
            DOB = null;
            Number = null;
            Milk = null;
            Weight = null;
            Price = null;
        }

        private bool ValidationInfAnimal()
        {

            if (Visibility == Visibility.Collapsed)
            {
                if (((Specialization == null)) || (Breed == null) || (Gender == null) || (DOB == null) || (Number == null) || (Weight == null) || (Price == null))
                {
                    return false;
                }
                else if (ValidationDigits(Number) || ValidationDigits(Weight) || ValidationDigits(Price)) return false;
                return true;
            }
            else
            {
                if (((Specialization == null)) || (Breed == null) || (Gender == null) || (DOB == null) || (Number == null) || (Weight == null) || (Milk == null) || (Price == null))
                {
                    return false;
                }
                else if (ValidationDigits(Number) || ValidationDigits(Weight) || ValidationDigits(Price) || ValidationDigits(Milk)) return false;
                return true;
            }


        }

        private bool ValidationDigits(string value)
        {
            Regex validation = new Regex(@"^\d+$");
            if (validation.IsMatch(value)) return false;
            return true;
        }
        #endregion
    }
}


   


