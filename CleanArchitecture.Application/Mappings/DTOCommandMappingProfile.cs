using AutoMapper;
using CleanArchitecture.Application.DTOs;
using CleanArchitecture.Application.ProdcutsCQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappings
{
    public class DTOCommandMappingProfile : Profile
    {
        public DTOCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
