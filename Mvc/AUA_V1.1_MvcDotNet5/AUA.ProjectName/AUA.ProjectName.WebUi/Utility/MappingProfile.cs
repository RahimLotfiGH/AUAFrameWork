using AutoMapper;
using System;
using System.Reflection;
using AUA.Mapping.Mapping;
using AUA.ProjectName.Models.BaseModel.BaseDto;

namespace AUA.ProjectName.WebUi.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var types = GetAllModelsType();

            new ConfigureStandardMappings().Load(this, types);

            new ConfigureCustomMappings().Load(this, types);
        }

        private static Type[] GetAllModelsType()
        {
            var assembly = Assembly.GetAssembly(typeof(BaseEntityDto));

            return assembly is null ?
                Array.Empty<Type>() :
                assembly.GetExportedTypes();
        }

    }
}
