using Ferma.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.Model
{
    public class OrderProductanimal : ObservableObject
    {
        private string _status;

        public string OrderSpecialization { get; set; }
        public string OrderBreed { get; set; }
        public string OrderGender { get; set; }
        public string OrderNumber { get; set; }
        public string OrderPrice { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMiddlename { get; set; }
        public string CustomerLogin { get; set; }
       
        public string Status
        {
            get => _status; set
            {
                _status = value;
                RaisePropertyChangedEvent(nameof(Status));
            }
        }

        public OrderProductanimal ParameterOrder { get; set; }
        
    }

}
