using zlobek.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;

namespace zlobek
{
    public class DbInitalizer
    {
        private readonly nurseryDbContext _dbcontext;

        public DbInitalizer(nurseryDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public void Seed()
        {
            if (_dbcontext.Database.CanConnect())
            {
                if (!_dbcontext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbcontext.Roles.AddRange(roles);
                    _dbcontext.SaveChanges();
                }
                if (!_dbcontext.Accounts.Any())
                {
                    var accounts = GetAccounts();
                    var passwordHasher = new PasswordHasher<Account>();

                    foreach (var account in accounts)
                    {
                        account.Password = passwordHasher.HashPassword(account, account.Password);
                    }

                    _dbcontext.Accounts.AddRange(accounts);
                    _dbcontext.SaveChanges();
                }
                if (!_dbcontext.Child.Any())
                {
                    var children = GetChildren();
                    _dbcontext.Child.AddRange(children);
                    _dbcontext.SaveChanges();
                }
                if (!_dbcontext.Teacher.Any())
                {
                    var teachers = GetTeachers();
                    _dbcontext.Teacher.AddRange(teachers);
                    _dbcontext.SaveChanges();
                }
                if (!_dbcontext.Menu.Any())
                {
                    var menus = GetMenus();
                    _dbcontext.Menu.AddRange(menus);
                    _dbcontext.SaveChanges();
                }
            }
        }
    

    private IEnumerable<Child> GetChildren()
    {
            var children = new List<Child>
    {
        new Child()
        {
            Name = "Jan",
            Surname = "Kowalski",
            MotherName = "Maria",
            MotherSurname = "Kowalska",
            FatherName = "Adam",
            FatherSurname = "Kowalski",
            ContactNumber = 123456789,
            City = "Warszawa",
            Street = "Krakowska",
            HouseNumber = "1",
            PostalCode = "00-001",
            BirthDate = "2016-02-14",
            Allergies = "nuts",
            OtherInformations = "sleep max 1 hour",
            GroupId=1,
            Groups = new Groups
            {
                Name = "Biedronki",
                 NOMembers=15
            }
               
        },
        new Child()
        {
            Name = "Marek",
            Surname = "Nowak",
            MotherName = "Anna",
            MotherSurname = "Nowak",
            FatherName = "Tomasz",
            FatherSurname = "Nowak",
            ContactNumber = 987654321,
            City = "Kraków",
            Street = "Wrocławska",
            HouseNumber = "2",
            PostalCode = "30-001",
            BirthDate = "2017-03-15",
            Allergies = "none",
            OtherInformations = "none",
             GroupId=2,
            Groups = new Groups
            {
                Name = "Żabki",
                 NOMembers=15
            }
        },
        new Child()
        {
            Name = "Zuzanna",
            Surname = "Wiśniewska",
            MotherName = "Ewa",
            MotherSurname = "Wiśniewska",
            FatherName = "Tomasz",
            FatherSurname = "Wiśniewski",
            ContactNumber = 135791113,
            City = "Gdańsk",
            Street = "Mariacka",
            HouseNumber = "3",
            PostalCode = "80-001",
            BirthDate = "2018-04-16",
            Allergies = "none",
            OtherInformations = "none",
             GroupId=3,
            Groups = new Groups
            {
                Name = "Motylki",
                NOMembers=15
            }
        }
    };

        return children;
    }
    private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "Parent"
                },
                new Role()
                {
                    Name = "Teacher"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };

            return roles;
        }
        private IEnumerable<Account> GetAccounts()
        {
            var accounts = new List<Account>
    {
        new Account()
        {
            Name = "Jan",
            Surname = "Kowalski",
            Password = "haslo123",
            Email = "jan.kowalski@email.com",
            PhoneNumber = 123456789,
            RoleId = 1,
            Role = _dbcontext.Roles.FirstOrDefault(r => r.Id == 1)
        },
        new Account()
        {
            Name = "Anna",
            Surname = "Nowak",
            Password = "haslo456",
            Email = "anna.nowak@email.com",
            PhoneNumber = 987654321,
            RoleId = 2,
            Role = _dbcontext.Roles.FirstOrDefault(r => r.Id == 2)
        },
        new Account()
        {
            Name = "Janusz",
            Surname = "Wiśniewski",
            Password = "haslo789",
            Email = "janusz.wisniewski@email.com",
            PhoneNumber = 135791113,
            RoleId = 3,
            Role = _dbcontext.Roles.FirstOrDefault(r => r.Id == 3)
        }
    };

            return accounts;
        }
        private IEnumerable<Teacher> GetTeachers()
        {
            var teachers = new List<Teacher>
    {
        new Teacher()
        {
            Name = "Adam",
            Surname = "Nowak",
            ContactNumber = 123456789,
            City = "Warszawa",
            Street = "Aleje Jerozolimskie",
            HouseNumber = "1",
            PostalCode = "00-001",
            BirthDate = "01-01-1980",
            OtherInformations = "Lorem ipsum dolor sit amet",
            GroupId = 1,
            Groups = _dbcontext.Groups.FirstOrDefault(g => g.GroupId == 1)
        },
        new Teacher()
        {
            Name = "Ewa",
            Surname = "Kowalska",
            ContactNumber = 987654321,
            City = "Kraków",
            Street = "ul. Floriańska",
            HouseNumber = "10",
            PostalCode = "31-021",
            BirthDate = "05-05-1990",
            OtherInformations = "Consectetur adipiscing elit",
            GroupId = 2,
            Groups = _dbcontext.Groups.FirstOrDefault(g => g.GroupId == 2)
        },
        new Teacher()
        {
            Name = "Jan",
            Surname = "Nowicki",
            ContactNumber = 246810121,
            City = "Gdańsk",
            Street = "ul. Długa",
            HouseNumber = "20",
            PostalCode = "80-831",
            BirthDate = "10-10-1975",
            OtherInformations = "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
            GroupId = 3,
            Groups = _dbcontext.Groups.FirstOrDefault(g => g.GroupId == 3)
        }
    };

            return teachers;
        }
        private IEnumerable<Menu> GetMenus()
        {
            var menus = new List<Menu>
    {
        new Menu()
        {
            DinnerDate = DateTime.Today.AddDays(1),
            DishType = "Spaghetti Bolognese",
            Allergens = "gluten, dairy"
        },
        new Menu()
        {
            DinnerDate = DateTime.Today.AddDays(2),
            DishType = "Roast Chicken",
            Allergens = "none"
        },
        new Menu()
        {
            DinnerDate = DateTime.Today.AddDays(3),
            DishType = "Beef Stew",
            Allergens = "celery"
        }
    };

            return menus;
        }

    }
}
