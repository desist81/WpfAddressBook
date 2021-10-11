using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DomainModel
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {

        }

        public T CreateDeepCopy<T>(Type[] knownTypes = null)
        {
            using (var ms = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType(), knownTypes);
                serializer.Serialize(ms, this);
                ms.Seek(0, SeekOrigin.Begin);
                return (T)serializer.Deserialize(ms);
            }
        }
    }

}
