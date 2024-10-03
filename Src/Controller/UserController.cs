using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catedra1___WebMovil.Src.DTOs;
using Catedra1___WebMovil.Src.Interface;



namespace Catedra1___WebMovil.Src.Controller
{
[ApiController]
[Route("api/product")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController( IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        [HttpPost("")]
        public async Task<IResult> CreateUser(CreateUserDto createUserDto)
        {
            // Verificar si el código del producto ya existe
            bool exists = await _userRepository.ExistsByCode(createUserDto.Rut);

            // Si existe, devolver un error
            if (exists)
            { return TypedResults.Conflict("El código del producto ya existe");
            } else {
                return TypedResults.Ok("Usuario creado correctamente");
            }
        }

    }
}