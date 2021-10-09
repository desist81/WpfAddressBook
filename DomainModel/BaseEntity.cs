using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DomainModel
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            
        }

        public T CreateDeepCopy<T>()
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                return (T)serializer.Deserialize(ms);
            }
        }
    }

}
