using AutoMapper;

namespace TaskManagmentSystem.Common.Mappings
{
    public interface IHaveCustomMapping
    {
        void ConfigureMapping(Profile mapper);
    }
}
