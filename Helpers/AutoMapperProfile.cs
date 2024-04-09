namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Datvs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest
        CreateMap<CreateRequest, Datv>();

        // UpdateRequest
        CreateMap<UpdateRequest, Datv>()
            .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
    }
}