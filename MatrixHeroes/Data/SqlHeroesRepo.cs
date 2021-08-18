using MatrixHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixHeroes.Data
{
    public class SqlHeroesRepo : IHeroesRepo
    {
        private ApplicationDbContext _context;

        public SqlHeroesRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public Hero GetHero(int id)
        {
            return _context.Heroes.FirstOrDefault(h => h.Id == id); ;
        }

        public bool TrainHero(int id)
        {

            Hero hero = _context.Heroes.FirstOrDefault(h => h.Id == id);

            var randomNumber = new Random();
            var howManyTimesTrain = hero.HowManyTimesTrainedToday;
            if (howManyTimesTrain < 5)
            {
                hero.CurrentPower = hero.CurrentPower == 0 ? 1 : hero.CurrentPower * (Convert.ToDecimal(randomNumber.Next(11) / 100f + 1f));
                hero.HowManyTimesTrainedToday += 1;
                return true;
            }
            return false;
        }

        public IEnumerable<Hero> GetHeroes()
        {
            return _context.Heroes.ToList();
        }

        public IEnumerable<Hero> GetHeroesByTrainerId(string id)
        {
            if (id != null)
            {
                var heroesList = _context.Heroes.Where(hero => hero.TrainerID == id).ToList();
                heroesList = (List<Hero>)ResetHeroesPowers(heroesList);
                return heroesList;
            }
            return null;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        private IEnumerable<Hero> ResetHeroesPowers(IEnumerable<Hero> heroesList)
        {
            foreach (Hero hero in heroesList)
            {
                hero.HowManyTimesTrainedToday = ResetHeroPower(hero.HowManyTimesTrainedToday, hero.LastTimeTrain);
                hero.LastTimeTrain = DateTime.Today;
            }
            SaveChanges();
            return heroesList;
        }
        private int ResetHeroPower(int howManyTimesTrainedToday, DateTime lastTimeTrain)
        {
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);

            if (lastTimeTrain <= yesterday)
            {
                return 0;
            }
            return howManyTimesTrainedToday;
        }
    }
}
