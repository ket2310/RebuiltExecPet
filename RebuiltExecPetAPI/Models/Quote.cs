using RebuiltExecPetAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace RebuiltExecPetAPI.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }

        public int petOwnerId { get; set; }

        public PetOwner petOwner { get; set; }

        public TravelTypes TravelType { get; set; }
    }
}
