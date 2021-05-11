using System;
using System.ComponentModel.DataAnnotations;

namespace FizzBuzzLogin.Models
{
    public class FizzBuzz
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Błąd. Nie podano liczby.")]
        [Range(0, 1000, ErrorMessage = "Podana liczba musi zawierać się w przedziale od 0 do 1000.")]
        public int? Number { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
    }
}
