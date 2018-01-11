using System;
using System.Runtime.Serialization;
using Applications.Web.Template;
using Domain.Domain;

namespace Applications.Web.Models.Response
{
    [DataContract]
    public class ValuesResponse : ModelToDomainProfile
    {

        public ValuesResponse() => CreateMap<Value, ValuesResponse>();


        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
