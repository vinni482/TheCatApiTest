using AutoMapper;
using Enums;
using TheCatApiTest.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheCatApiTest.Mappings
{
    public class WebMappingProfile : Profile
    {
        /// <summary>
        /// mapping between Web and Business layer objects
        /// </summary>
        public WebMappingProfile()
        {
            CreateMap<IRestResponse<List<Image>>, PagedModel<Image>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Data))
                .ForMember(dest => dest.TotalCount, opt => opt.MapFrom(src => WebMappingProfile.GetTotalCountFromHeaders(src)));
        }

        static object GetTotalCountFromHeaders(IRestResponse<List<Image>> response) 
        {
            var count = response.Headers.Where(h => h.Name.ToLower() == Headers.PaginationCount).Select(h => h.Value).FirstOrDefault();
            return count;
        }
    }
}
