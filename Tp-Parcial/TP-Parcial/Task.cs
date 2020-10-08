using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP_Parcial
{
    public class Task
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Expiration { get; set; }
        public int Estimate { get; set; }
        public string State { get; set; }
        public int ResourceId { get; set; }
        public Resource Liable { get; set; }


        public static void InsertTask(string title, DateTime expiration, int estimate, string state, Resource liable)
        {
            var ctx = new TareasDbContext();

            ctx.Tasks.Add(new Task
            {
                Title = title,
                Expiration = expiration,
                Estimate = estimate,
                State = state,
                ResourceId = liable.Id

            });

            ctx.SaveChanges();
        }


        public static List<Task> FetchTasks()
        {
            var ctx = new TareasDbContext();
            var lista = ctx.Tasks.ToList();
            Console.WriteLine("----FetchTasks---");
            foreach (var item in lista)
            {
                Console.WriteLine($"Titulo: {item.Title} - Expiracion: {item.Expiration} - Estado: {item.State}");

            }

            return lista;
        }


        public static Task FetchTask(int Id)
        {
            var ctx = new TareasDbContext();
            var task = ctx.Tasks.Where(i => i.Id == Id).FirstOrDefault();
            Console.WriteLine($"-----Fetch Task----- \nTitulo: {task.Title} - Expiracion: {task.Expiration} - Estado: {task.State}");
            return task;

        }

        public static void UpdateTaskId(int id, string title, DateTime expiration, int estimate, string state, Resource liable)
        {
            var ctx = new TareasDbContext();

            var task = ctx.Tasks.Where(i => i.Id == id).FirstOrDefault();
            if (task != null)
            {
                task.Title = title;
                task.Expiration = expiration;
                task.Estimate = estimate;
                task.State = state;
                task.ResourceId = liable.Id;
            }
            ctx.SaveChanges();

        }

        public static void Delete(int Id)
        {
            var ctx = new TareasDbContext();
            var task = ctx.Tasks.Where(i => i.Id == Id).FirstOrDefault();
            if (task != null)
            {
                ctx.Tasks.Remove(task);
            }

            ctx.SaveChanges();

        }

    }
}