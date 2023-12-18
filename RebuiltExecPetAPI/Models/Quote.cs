using RebuiltExecPetAPI.Enums;

namespace RebuiltExecPetAPI.Models
{
    public class Quote
    {
        public int QuoteId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string Instructions { get; set; }

        public TravelTypes TravelType { get; set; }
    }
}
