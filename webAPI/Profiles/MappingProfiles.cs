using AutoMapper;
using System.Diagnostics;
using System.Security.Cryptography;
using webAPI.Entity;
using webAPI.Entity.Request;
using webAPI.Models;

namespace webAPI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<JobModel, Job>();
            CreateMap<Job, JobModel>();
            CreateMap<JobCreateRequest, Job>();
            CreateMap<JobUpdateRequest, Job>();
        }
    }
}
