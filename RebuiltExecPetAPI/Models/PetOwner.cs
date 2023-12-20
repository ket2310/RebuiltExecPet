using System.ComponentModel.DataAnnotations;

namespace RebuiltExecPetAPI.Models
{
    public class PetOwner
    {
        [Key]
        public int PetOwnerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string Instructions { get; set; }
        //public Quote quote { get; set; }

    }
}
