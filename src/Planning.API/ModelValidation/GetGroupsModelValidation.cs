using System.ComponentModel.DataAnnotations;

namespace Planning.API.ModelValidation
{
    public class GetGroupsModelValidation
    {
        [Required(ErrorMessage = "Il campo 'bft' è obbligatorio."), 
         RegularExpression("^(inbound_returns|inbound_production)$", ErrorMessage = "Il campo 'bft' può assumere come valore solo 'inbound_returns' o 'inbound_production'")]
        public string Bft { get; set; }

        [Required(ErrorMessage = "Il campo 'department' è obbligatorio."),
         RegularExpression("^(national|international)$", ErrorMessage = "Il campo 'department' può assumere come valore solo 'national' o 'international'")]
        public string Department { get; set; }

    }
}
