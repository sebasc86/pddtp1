using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP_Parcial
{
    public class Detail
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Time { get; set; }
        public int ResourceId { get; set; }
        public Resource Resource { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }


        public static void InsertDetail(DateTime date, int time, Resource resource, Task task)
        {
            var ctx = new TareasDbContext();

            ctx.Details.Add(new Detail
            {
                Date = date,
                Time = time,
                ResourceId = resource.Id,
                TaskId = task.Id
            });

            ctx.SaveChanges();
        }


        public static List<Detail> FetchDetails()
        {
            var ctx = new TareasDbContext();
            var lista = ctx.Details.ToList();
            Console.WriteLine("----Fetch DETAILS---");
            foreach (var item in lista)
            {
                Console.WriteLine($"Details Id: {item.Id} - Tiempo: {item.Date} - TaskId: {item.TaskId}");

            }

            return lista;
        }


        public static Detail FetchDetail(int Id)
        {
            var ctx = new TareasDbContext();
            var details = ctx.Details.Where(i => i.Id == Id).FirstOrDefault();
            Console.WriteLine($"----Fetch DETAIL-- -  \nDetails Id: {details.Id} - Tiempo: {details.Date} - TaskId: {details.TaskId}");
            return details;

        }

        public static void UpdateDetailsId(int id, DateTime date, int time, Resource resource, Task task)
        {
            var ctx = new TareasDbContext();

            var detail = ctx.Details.Where(i => i.Id == id).FirstOrDefault();
            if (detail != null)
            {
                detail.Date = date;
                detail.Time = time;
                detail.ResourceId = resource.Id;
                detail.TaskId = task.Id;
            }
            ctx.SaveChanges();

        }

        public static void Delete(int Id)
        {
            var ctx = new TareasDbContext();
            var detail = ctx.Details.Where(i => i.Id == Id).FirstOrDefault();
            if (detail != null)
            {
                ctx.Details.Remove(detail);
            }

            ctx.SaveChanges();

        }

    }



}
