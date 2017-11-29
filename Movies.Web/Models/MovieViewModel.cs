using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Web.Models
{
    public class MovieViewModel
    {
        //public Guid Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [MinLength(5, ErrorMessage = "Tytuł musi zawierać minimum 5 znaków.")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Podaj czas trwania.")]
        //walidator dla wiekszego od 0
        [Range(1,double.MaxValue, ErrorMessage = "Nieprawidłowy zakres.")]
        [Display(Name = "Czas trwania w minutach")]
        [DataType(DataType.Currency)]
        public double DurationInMinutes { get; set; }
    }
}
