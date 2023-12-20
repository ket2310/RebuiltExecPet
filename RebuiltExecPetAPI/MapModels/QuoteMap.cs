using RebuiltExecPetAPI.Enums;
using RebuiltExecPetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RebuiltExecPetAPI.MapModels
{
    public class QuoteMap
    {
     

        public PetOwner petOwner { get; set; }

        public TravelTypes TravelType { get; set; }
    }
}
