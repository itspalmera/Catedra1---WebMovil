using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Catedra1___WebMovil.Src.DTOs;
using Catedra1___WebMovil.Src.Interface;
using Catedra1___WebMovil.Src.Models;
using Catedra1___WebMovil.Src.DTOs.Catedra1___WebMovil.Src.DTOs;

namespace Catedra1___WebMovil.Src.Controller
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //POST
        [HttpPost("")]
        public async Task<IActionResult> CreateUser(CreateUserDto createUserDto)
        {
            // Verificar si el RUT ya existe
            bool exists = await _userRepository.ExistsByCode(createUserDto.Rut);

            if (exists)
            {
                return Conflict(new { message = "El RUT ya está registrado" });
            }

            // Validar que la fecha de nacimiento sea menor a la fecha actual
            if (createUserDto.BirthDate >= DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest(new { message = "La fecha de nacimiento debe ser menor a la fecha actual" });
            }

            // Crear un nuevo usuario
            var newUser = new User
            {
                Rut = createUserDto.Rut,
                Name = createUserDto.Name,
                Mail = createUserDto.Mail,
                Gender = createUserDto.Gender,
                BirthDate = createUserDto.BirthDate
            };

            // Guardar el usuario en la base de datos
            await _userRepository.AddUserAsync(newUser);

            // Retornar el nuevo usuario creado con el código 201 Created
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.Id }, newUser);
        }

        //GET por id especifica
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        //GET usuarios
        [HttpGet("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] string? sort = null, [FromQuery] string? gender = null)
        {
            // Validar los parámetros
            if (!string.IsNullOrEmpty(sort) && sort != "asc" && sort != "desc")
            {
                return BadRequest(new { message = "El valor de 'sort' debe ser 'asc' o 'desc'" });
            }

            if (!string.IsNullOrEmpty(gender) && gender != "masculino" && gender != "femenino" && gender != "otro" && gender != "prefiero no decirlo")
            {
                return BadRequest(new { message = "El valor de 'gender' debe ser válido" });
            }

            // Obtener la lista de usuarios con filtros y ordenación
            var users = await _userRepository.GetAllUsersAsync(sort, gender);

            return Ok(users);
        }

        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            await _userRepository.DeleteUserAsync(user);

            return Ok(new { message = "Usuario eliminado correctamente" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            // Buscar el usuario por ID
            var user = await _userRepository.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            // Verificar si el RUT ya existe en otro usuario
            if (await _userRepository.ExistsByCode(updateUserDto.Rut) && user.Rut != updateUserDto.Rut)
            {
                return Conflict(new { message = "El RUT ya está registrado para otro usuario" });
            }

            // Validar que la fecha de nacimiento sea menor a la actual
            if (updateUserDto.BirthDate >= DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest(new { message = "La fecha de nacimiento debe ser menor a la fecha actual" });
            }

            // Actualizar los campos del usuario
            user.Rut = updateUserDto.Rut;
            user.Name = updateUserDto.Name;
            user.Mail = updateUserDto.Mail;
            user.Gender = updateUserDto.Gender;
            user.BirthDate = updateUserDto.BirthDate;

            // Guardar los cambios
            await _userRepository.UpdateUserAsync(user);

            return Ok(new { message = "Usuario actualizado correctamente" });
        }



    }
}
