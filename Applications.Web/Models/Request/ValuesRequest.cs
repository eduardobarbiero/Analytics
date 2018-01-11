using System;
using System.Runtime.Serialization;
using Applications.Web.Template;
using Domain.Domain;

namespace Applications.Web.Models.Response
{
    [DataContract]
    public class ValuesRequest : ModelToDomainProfile
    {

        public ValuesRequest() => CreateMap<ValuesRequest, Value>();


        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
