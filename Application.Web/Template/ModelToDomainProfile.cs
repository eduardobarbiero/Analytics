using System;
using System.Runtime.Serialization;
using AutoMapper;

namespace Application.Web.Template
{
    [DataContract]
    public abstract class ModelToDomainProfile : Profile
    {
    }
}
