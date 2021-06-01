using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Happy_Cats_Test.Models
{
    public class Cats
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Введите имя котика")]
        public string Name_Cat { get; set; }

        [Required(ErrorMessage = "Введите историю котика")]
        public string History { get; set; }

        [Required(ErrorMessage = "Введите описание котика")]
        public string Description_Cat { get; set; }
        public string Email_User { get; set; }

    }
}
