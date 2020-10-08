using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace TP_Parcial
{
    
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            //< ------------- USUARIOS --------------> 

            var User = new User("Diego", "Armando", "1986");
            User.InsertUser(User);
            User.FetchUsers();

            var user1 = User.FetchUser(1);
            User.UpdateUserId(3, "Martin", "Palermo");
            User.UpdateUserPassword(3, "1234");
            User.Delete(5);

            Console.WriteLine();
            //< ------------- RECURSOS --------------> 

            Resource.InsertResource("tarea2", user1);
            Resource.FetchResources();
            var resource1 = Resource.FetchResource(1);
            Resource.UpdateResourceId(2, "Tarea Modificada", 1);
            Resource.Delete(3);

            ////< ------------- TAREAS --------------> 

            Task.InsertTask("Tarea2", DateTime.Now, 4, "Open", resource1);
            Task.FetchTasks();
            var task1 = Task.FetchTask(1);
            Task.UpdateTaskId(1, "Titulo Updateado", DateTime.Now, 2, "Closed", resource1);
            Task.Delete(2);


            ////< ------------- DETALLES --------------> 

            Detail.InsertDetail(DateTime.Now, 3, resource1, task1);
            Detail.FetchDetails();
            Detail.FetchDetail(1);
            Detail.UpdateDetailsId(1, DateTime.Now, 7, resource1, task1);
            Detail.Delete(3);
        }
    }


    
}
