using System.ComponentModel.DataAnnotations;

namespace MidtermAPI_NiravSaxena.Models
{
    public class NSProduct
    {

        public int Id { get; set; }

        [Required]
        [Length(1,25)]
        public string Name { get; set; }

        
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
