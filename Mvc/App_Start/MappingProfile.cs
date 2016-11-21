using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using AutoMapper;
using BaseEpoch.Data.POCO.Base;
using BaseEpoch.Dtos;
using ProductDto = BaseEpoch.Data.POCO.Base.Product;

namespace Mvc.App_Start
{
    public class MappingProfile:Profile
    {

        public MappingProfile()
        {
           // Mapper.CreateMap<Product, ProductDto>();
           // Mapper.CreateMap<ProductDto, Product>();
            //CreateMap<Product, ProductDto>()
            //    .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}