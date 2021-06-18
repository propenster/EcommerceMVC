using AutoMapper;
using Facemask.Models;
using Facemask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facemask.AutomapperProfiles
{
    public class MyProfiles : Profile
    {

        public MyProfiles()
        {
            CreateMap<SignupViewModel, User>().ForMember(target => target.UserName, option => option.MapFrom(source => source.Email));
            CreateMap<Product, ProductDetailViewModel>();
        }
    }
}
