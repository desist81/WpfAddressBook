using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmDataProviders.Entities
{
    public class RContactField : RealmObject
    {
        public Guid Id { get; set; } 
        
        [Required] 
        public string Content { get; set; }

        public byte FieldType { get; set; }

        public RContact Contact { get; set; }
    }
}
