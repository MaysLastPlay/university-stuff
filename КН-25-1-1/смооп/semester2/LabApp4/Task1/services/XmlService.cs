using System;
using System.IO;
using System.Xml.Serialization;
using Task1.services.work;

namespace Task1.services
{
    internal class XmlService
    {
        public void SerializeWorkers(string filePath, Worker[] workers)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Worker[]));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                serializer.Serialize(fileStream, workers);
            }
        }

        public Worker[] DeserializeWorkers(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Worker[]));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                return serializer.Deserialize(fileStream) as Worker[] ?? Array.Empty<Worker>();
            }
        }
    }
}