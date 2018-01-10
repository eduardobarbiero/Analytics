using System;
using System.Runtime.Serialization;
using Application.Domain.Domain;
using Application.Web.Template;
using AutoMapper;

namespace Application.Web.Models.Response
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
