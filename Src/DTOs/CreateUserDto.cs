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

        [RegularExpression(@"MASCULINO|FEMENINO|OTRO|PREFIERO NO DECIRLO")]       
        public required string Genero {get; set;}

        //TODO: DATE MENOR A ACTUAL
        public int Date {get; set;}
    }
}