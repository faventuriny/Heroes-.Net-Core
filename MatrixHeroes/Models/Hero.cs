using System;
using System.ComponentModel.DataAnnotations;

namespace MatrixHeroes.Models
{
    public class Hero
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateStarted { get; set; }
        [Required]
        public string SuitColor { get; set; }
        [Required]
        public string Ability { get; set; }
        [Required]
        public decimal StartingPower { get; set; }
        public decimal CurrentPower { get; set; }
        public int HowManyTimesTrainedToday { get; set; }
        public DateTime LastTimeTrain { get; set; }

        public string TrainerID { get; set; }
    }
}
