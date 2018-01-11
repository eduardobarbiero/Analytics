using System;
using System.Runtime.Serialization;
using AutoMapper;

namespace Applications.Web.Template
{
    [DataContract]
    public abstract class ModelToDomainProfile : Profile
    {
    }
}
