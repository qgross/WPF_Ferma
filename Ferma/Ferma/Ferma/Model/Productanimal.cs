using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.Model
{
    public class Productanimal
    {
        public string Specialization { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Number { get; set; }
        public string Milk { get; set; }
        public string Weight { get; set; }
        public string Price { get; set; }

        public Productanimal ParameterProduct { get; set; }
        public Productanimal ParameterAnimal { get; set; }

    }
}
