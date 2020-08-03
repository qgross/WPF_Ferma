using Ferma.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.Model
{
    public class Client : ObservableObject
    {
        private string _access;

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Middlename { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string GenderClient { get; set; }

        public string Access
        {
            get => _access; set
            {
                _access = value;
                RaisePropertyChangedEvent(nameof(Access));
            }
              
        }

        public Client MainClient { get; set; }

        public Client ParameterClient { get; set; }

        public string LoginEntryView { get; set; }

    }

}
