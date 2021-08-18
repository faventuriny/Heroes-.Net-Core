using AutoMapper;
using MatrixHeroes.Models;
using MatrixHeroes.Models.Dtos;

namespace MatrixHeroes.Profiles
{
    public class HeroesProfile : Profile
    {
        public HeroesProfile()
        {
            CreateMap<Hero, HeroDto>();
            CreateMap<HeroDto, Hero>();
        }
    }
}
