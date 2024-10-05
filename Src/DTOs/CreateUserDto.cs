using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra1___WebMovil.Src.DTOs
{
    public class CreateUserDto
    {
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