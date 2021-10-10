using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDataProviders.Entities
{
    public class RContactPhone: RealmObject
    {
        public Guid Id { get; set; } 

        [Required] 
        public string PhoneNumber { get; set; }

       //public RContact Contact { get; set; }

    }
}
