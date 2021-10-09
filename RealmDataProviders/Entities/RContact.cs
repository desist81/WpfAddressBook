using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDataProviders.Entities
{
   
    public class RContact : RealmObject
    {
        [PrimaryKey]
        public Guid Id { get; set; } 
        [Required] 
        public string FullName { get; set; }
        public string Nickname { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
       
        //[Backlink(nameof(RContactPhone.Contact))] 
        public IList<RContactPhone> PhoneNumbers { get; }

        //[Backlink(nameof(RContactEmail.Contact))]
        public IList<RContactEmail> Emails { get; }
    }
}
