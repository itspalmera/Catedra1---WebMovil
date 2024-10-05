using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catedra1___WebMovil.Src.DTOs
{
using System;
    using System.ComponentModel.DataAnnotations;

    namespace Catedra1___WebMovil.Src.DTOs
{
    public class UpdateUserDto
    {
        public required string Rut { get; set; }
        
        [StringLength(100, MinimumLength = 3)]
        public required string Name { get; set; }
        
        public required string Mail { get; set; }

        [RegularExpression(@"masculino|femenino|otro|prefiero no decirlo")]       
        public required string Gender { get; set; }

        public DateOnly BirthDate { get; set; }
    }
}

}