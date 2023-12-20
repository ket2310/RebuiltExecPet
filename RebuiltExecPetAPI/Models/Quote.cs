using RebuiltExecPetAPI.Enums;

namespace RebuiltExecPetAPI.Models
{
    public class Quote
    {
        public int QuoteId { get; set; }

        public int petOwnerId { get; set; }

        public PetOwner petOwner { get; set; }

        public TravelTypes TravelType { get; set; }
    }
}
