
using MatrixHeroes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace MatrixHeroes.Data
{
    public class ApplicationDbContext : IdentityDbContext<Trainer>
    {
        public DbSet<Hero> Heroes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedTrainer(builder);
            this.SeedHeroes(builder);
        }

        private void SeedTrainer(ModelBuilder builder)
        {
            //create trainer
            Trainer trainer = new Trainer()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Israel",
                Email = "israel@gmail.com",
                EmailConfirmed = true
            };

            //create password
            PasswordHasher<Trainer> passwordHasher = new PasswordHasher<Trainer>();
            trainer.PasswordHash = passwordHasher.HashPassword(trainer, "Isra123!");
            
            //seed user
            builder.Entity<Trainer>().HasData(trainer);
        }

        private void SeedHeroes(ModelBuilder builder)
        {
            builder.Entity<Hero>().HasData(
                new Hero {
                    Id = 1,
                    Name = "Storm",
                    DateStarted = new DateTime(2019, 5, 21),
                    SuitColor = "Black",
                    StartingPower = 12.40M,
                    CurrentPower = 40.6M,
                    HowManyTimesTrainedToday = 0,
                    TrainerID = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Ability = "Expert tactician and thief Psionic ability to manipulate weather patterns over vast area Control atmospheric pressure Temperature modification Ecological empathy Flight Lightning manipulation Immunity to lightning Limited immunity to extreme cold and heat Aerial adaptation",
                    LastTimeTrain = new DateTime(2021, 8, 17),
                });

            builder.Entity<Hero>().HasData(
                new Hero
                {
                    Id = 2,
                    Name = "Super Man",
                    DateStarted = new DateTime(2015, 6, 19),
                    SuitColor = "Blue and Red",
                    StartingPower = 20.61M,
                    CurrentPower = 184.67M,
                    HowManyTimesTrainedToday = 0,
                    TrainerID = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Ability = "Possesses the powers of flight, superhuman strength, x-ray vision, heat vision, cold breath, super-speed, enhanced hearing, and nigh-invulnerability",
                    LastTimeTrain = new DateTime(2021, 8, 17),
                });

            builder.Entity<Hero>().HasData(
                new Hero
                {
                    Id = 3,
                    Name = "Wolverine",
                    DateStarted = new DateTime(2016, 6, 8),
                    SuitColor = "Yellow and Blue",
                    StartingPower = 15.23M,
                    CurrentPower = 185.33M,
                    HowManyTimesTrainedToday = 0,
                    TrainerID = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Ability = "Superhuman strength and reflexes, enhanced senses and tracking abilities, and a special healing power that also slows his aging",
                    LastTimeTrain = new DateTime(2021, 8, 17),
                });

            builder.Entity<Hero>().HasData(
                new Hero
                {
                    Id = 4,
                    Name = "Super Girl",
                    DateStarted = new DateTime(2020, 8, 8),
                    SuitColor = "Blue and Red",
                    StartingPower = 7.00M,
                    CurrentPower = 7.56M,
                    HowManyTimesTrainedToday = 0,
                    TrainerID = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Ability = "Super strength and super speed. She can also fly, manifest wings of fire, and project fire vision.",
                    LastTimeTrain = new DateTime(2021, 8, 17),
                });

            builder.Entity<Hero>().HasData(
                new Hero
                {
                    Id = 5,
                    Name = "Captain America",
                    DateStarted = new DateTime(2014, 7, 5),
                    SuitColor = "Blue, Red and White",
                    StartingPower = 100.18M,
                    CurrentPower = 201.5M,
                    HowManyTimesTrainedToday = 0,
                    TrainerID = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Ability = "Superhuman Agility, Stamina, Durability, Reflexes and Strength",
                    LastTimeTrain = new DateTime(2021, 8, 17),
                });

            builder.Entity<Hero>().HasData(
                new Hero
                {
                    Id = 6,
                    Name = "Deadpool",
                    DateStarted = new DateTime(2020, 5, 17),
                    SuitColor = "Red and Black",
                    StartingPower = 8.45M,
                    CurrentPower = 19.60M,
                    HowManyTimesTrainedToday = 0,
                    TrainerID = "b74ddd14-6340-4840-95c2-db12554843e5",
                    Ability = "Regeneration Extended longevity Skilled marksman, swordsman, and hand-to-hand combatant Using devices granting teleportation and holographic disguise Superhuman strength, durability, and agility",
                    LastTimeTrain = new DateTime(2021, 8, 17),
                });
        }

    }
}
