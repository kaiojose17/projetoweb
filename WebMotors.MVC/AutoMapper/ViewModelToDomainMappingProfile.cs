using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMotors.Domain.Entities;
using WebMotors.MVC.ViewModels;

namespace WebMotors.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AnuncioWebMotors, AnuncioWebMotorsViewModel>();
        }
    }
}