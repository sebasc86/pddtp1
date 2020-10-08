using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP_Parcial
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }

      
        public User(string name, string lastName, string password)
        {
            Name = name;
            LastName = lastName;
            Password = password;
        }

        public static void InsertUser(User User)
        {
            var ctx = new TareasDbContext();

            ctx.Set<User>().Add(User);

            ctx.SaveChanges();
        }

        public static List<User> FetchUsers()
        {
            var ctx = new TareasDbContext();
            var lista = ctx.Users.ToList();
            foreach (var item in lista)
            {
                Console.WriteLine($"---- FETCH USERS LIST ---- \nNombre: {item.Name} - Apellido: {item.LastName}");

            }
            return lista;
        }


        public static User FetchUser(int Id)
        {
            var ctx = new TareasDbContext();
            var user = ctx.Users.Where(i => i.Id == Id).FirstOrDefault<User>();
            Console.WriteLine($"---- FETCH USER ---- \nNombre: {user.Name} - Apellido: {user.LastName}");
            return user;

        }

        public static void UpdateUserId(int Id, string Name, string LastName)
        {
            var ctx = new TareasDbContext();

            var user = ctx.Users.Where(i => i.Id == Id).FirstOrDefault();
            if (user != null)
            {
                user.Name = Name;
                user.LastName = LastName;
            }
            ctx.SaveChanges();

        }

        public static void UpdateUserPassword(int Id, string Password)
        {
            var ctx = new TareasDbContext();

            var user = ctx.Users.Where(i => i.Id == Id).FirstOrDefault();
            if (user != null)
            {
                user.Password = Password;

            }
            ctx.SaveChanges();

        }

        public static void Delete(int Id)
        {
            var ctx = new TareasDbContext();
            var user = ctx.Users.Where(i => i.Id == Id).FirstOrDefault();
            if (user != null)
            {
                ctx.Users.Remove(user);
                Console.WriteLine($"Se removio el usuario con exito");
                ctx.SaveChanges();
            } else
            {
                Console.WriteLine($"Usuario Inexistente. ");
            }

           

        }

    }
}
