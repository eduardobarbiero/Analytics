using System;
using System.Runtime.Serialization;
using Applications.Web.Template;
using Domain.Domain;

namespace Applications.Web.Models.Response
{
    [DataContract]
    public class ValueWorksResponse : ModelToDomainProfile
    {

        public ValueWorksResponse() => CreateMap<ValueWork, ValueWorksResponse>();

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        [DataMember]
        public ValuesResponse Value { get; set; }

        [DataMember]
        public long ValueId { get; set; }
       
    }
}
