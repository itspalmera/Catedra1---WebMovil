using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catedra1___WebMovil.Src.Models;

namespace Catedra1___WebMovil.Src.Data
{
    public class Seeder
    {

        public static void Initializable(DataContext context){
            
            if (!context.Users.Any()){

                context.Users.AddRange(
                    //1
                    new User{
                        Rut = "121231230",
                        Name = "Pamela",
                        Mail = "pamela@gmail.com",
                        Gender = "femenino",
                        BirthDate = new DateOnly(2004,4,22)
                    },
                    //2
                    new User{
                        Rut = "111111111",
                        Name = "Francis",
                        Mail = "francis@gmail.com",
                        Gender = "femenino",
                        BirthDate = new DateOnly(1990,2,10)
                    },
                    //3
                    new User{
                        Rut = "101001003",
                        Name = "Alberto",
                        Mail = "alberto@gmail.com",
                        Gender = "masculino",
                        BirthDate = new DateOnly(1890,7,26)
                    },
                    //4
                    new User{
                        Rut = "222222222",
                        Name = "Malinda",
                        Mail = "malinda@gmail.com",
                        Gender = "femenino",
                        BirthDate = new DateOnly(2002,7,15)
                    },
                    //5
                    new User{
                    
                        Rut = "303003003",
                        Name = "Jorge",
                        Mail = "jorge@gmail.com",
                        Gender = "masculino",
                        BirthDate = new DateOnly(2010,1,11)
                    },
                    //6
                    new User{
                        Rut = "404004004",
                        Name = "Alejandro",
                        Mail = "alejandro@gmail.com",
                        Gender = "masculino",
                        BirthDate = new DateOnly(2000,5,10)

                    },
                    //7
                    new User{
                        Rut = "505005005",
                        Name = "Antonia",
                        Mail = "antonia@gmail.com",
                        Gender = "femenino",
                        BirthDate = new DateOnly(2005,5,10)

                    },
                    //8
                    new User{
                        Rut = "606006006",
                        Name = "Bernarda",
                        Mail = "bernarda@gmail.com",
                        Gender = "femenino",
                        BirthDate = new DateOnly(1920,2,18)

                    },
                    //9
                    new User{
                        Rut = "198309604",
                        Name = "Teo Navarro Fernandez",
                        Mail = "tomasorozco@canellas.com",
                        Gender = "masculino",
                        BirthDate = new DateOnly(2005,7,20)
                    },
                    //10
                    new User{
                        Rut = "771002003",
                        Name = "Anais Sanchez",
                        Mail = "anaissanchez@canellas.com",
                        Gender = "femenino",
                        BirthDate = new DateOnly(2001,4,20)
                    }

                );

                context.SaveChanges();

            }

        }

    }

}