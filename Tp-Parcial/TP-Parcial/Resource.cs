using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP_Parcial
{
    public class Resource
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public User user { get; set; }

        public static void InsertResource(string name, User user)
        {
            var ctx = new TareasDbContext();

            ctx.Resources.Add(new Resource 
            { 
                Name = name,
                UserId = user.Id

             });;

            ctx.SaveChanges();

                        
        }


        public static List<Resource> FetchResources()
        {
            var ctx = new TareasDbContext();
            var lista = ctx.Resources.ToList();
            foreach (var item in lista)
            {
                Console.WriteLine($"Nombre: {item.Name} - UserId: {item.UserId}");

            }
            return lista;
        }


        public static Resource FetchResource(int Id)
        {
            var ctx = new TareasDbContext();
            var resource = ctx.Resources.Where(i => i.Id == Id).FirstOrDefault();
            Console.WriteLine($"Nombre: {resource.Name} - UserId: {resource.UserId}");
            return resource;

        }

        public static void UpdateResourceId(int Id, string Name, int UserId)
        {
            var ctx = new TareasDbContext();

            var resource = ctx.Resources.Where(i => i.Id == Id).FirstOrDefault();
            if (resource != null)
            {
                resource.Name = Name;
                resource.UserId = UserId;
            }
            ctx.SaveChanges();

        }


        public static void Delete(int Id)
        {
            var ctx = new TareasDbContext();
            var resource = ctx.Resources.Where(i => i.Id == Id).FirstOrDefault();
            if (resource != null)
            {
                ctx.Resources.Remove(resource);
            }

            ctx.SaveChanges();

        }
    }
}
