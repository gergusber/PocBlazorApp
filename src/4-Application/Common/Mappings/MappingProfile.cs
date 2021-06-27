using AutoMapper;
using CRUDPOC.Domain.models;
using CRUDPOC.Shared.Dto;

namespace CRUDPOC.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
            CreateMap<Developer, DeveloperDto>().ReverseMap();
            CreateMap<Film, FilmDto>().ReverseMap();
        }

        //private void ApplyMappingsFromAssembly(Assembly assembly)
        //{
        //    var types = assembly.GetExportedTypes()
        //        .Where(t => t.GetInterfaces().Any(i =>
        //            i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
        //        .ToList();

        //    foreach (var type in types)
        //    {
        //        var instance = Activator.CreateInstance(type);
        //        var methodInfo = type.GetMethod("Mapping");
        //        methodInfo?.Invoke(instance, new object[] { this });
        //    }
        //}
    }
}