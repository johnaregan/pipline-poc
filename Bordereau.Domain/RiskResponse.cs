using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Bordereau.Domain
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Submission
    {
        public string MessageID { get; set; }
        public DateTime MessageTimestamp { get; set; }
        public string FileID { get; set; }
        public string Filename { get; set; }
        public string MessageType { get; set; }
        public string XmitDate { get; set; }
        public string PolicyReference { get; set; }
        public string ContractReference { get; set; }
        public string Validity { get; set; }
    }

    public class Submissions
    {
        [XmlAttribute("Exceptions")]
        public string Exceptions { get; set; }

        [XmlAttribute("ValidFiles")]
        public string ValidFiles { get; set; }
        
        [XmlAttribute("TotalFilesProcessed")]
        public string TotalFilesProcessed { get; set; }
        
        [XmlElement("Submission")]
        public List<Submission> Submission { get; set; }
    }

    public class Response
    {
        public Submissions Submissions { get; set; }
    }

    public class Root
    {
       public Response Response { get; set; }
    }
}
