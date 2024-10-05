using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Catedra1___WebMovil.Src.Models
{
    public class User
    {
        [Key]
        public int Id {get; set;}
        public required string Rut {get; set;}


        [StringLength(100, MinimumLength = 3)]
        public required string Name {get; set;}

        //TODO: MAIL VALIDO
        public required string Mail {get; set;}

        [RegularExpression(@"masculino|femenino|otro|prefiero no decirlo")]       
        public required string Gender {get; set;}

        //TODO: DATE MENOR A ACTUAL
        public DateOnly BirthDate {get; set;}

    }
}