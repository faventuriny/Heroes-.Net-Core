using MatrixHeroes.Models;
using System;
using System.Collections.Generic;

namespace MatrixHeroes.Data
{
    public interface IHeroesRepo
    {
        bool SaveChanges();
        IEnumerable<Hero> GetHeroes();
        IEnumerable<Hero> GetHeroesByTrainerId(string id);
        Hero GetHero(int id);
        bool TrainHero(int id);
    }
}
