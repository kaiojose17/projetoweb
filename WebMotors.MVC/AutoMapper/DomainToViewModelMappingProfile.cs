using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMotors.Domain.Entities;
using WebMotors.MVC.ViewModels;

namespace WebMotors.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AnuncioWebMotorsViewModel, AnuncioWebMotors>();
        }
    }
}