using System.ComponentModel.DataAnnotations;

namespace Planning.API.ModelValidation
{
    public class GetOrdersModelValidation
    {
        [Required(ErrorMessage = "Il campo 'groups' è obbligatorio.")]
        public List<int> groups { get; set; }

        public DateTime? date { get; set; }

        public bool? sent { get; set; }

    }
}
