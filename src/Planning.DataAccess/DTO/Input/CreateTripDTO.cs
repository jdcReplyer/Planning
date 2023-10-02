using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Planning.DataAccess.DTO.Input
{
    public class CreateTripDTO
    {
        [Required(ErrorMessage = "Il campo 'equipment' è obbligatorio."),
         RegularExpression("^(M|S)$", ErrorMessage = "Il campo 'equipment' può assumere come valore solo 'S' o 'M'")]
        public string Equipment { get; set; }

        public List<long> Orders { get; set; }
        public string Description { get; set; }
    }
}
