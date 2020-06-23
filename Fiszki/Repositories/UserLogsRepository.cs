using Fiszki.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiszki.Repositories
{
    public class UserLogsRepository
    {
        public static List<UserLogs> GetUserLogsList(int idUser)
        {
            using (var dbContext = new FiszkiContext())
            {
                return dbContext.UsersLogs.Where(p => p.UserId == idUser).ToList();
            }
        }



        public static void AddUserLogsList(int id, string LoginEvent)
        {
            using (var dbContext = new FiszkiContext())
            {

                dbContext.UsersLogs.Add(new Repositories.UserLogs
                {
                    UserId = id,
                    LoginDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    LoginStatus = "Nieprawidłowe hasło"
                });
                dbContext.SaveChanges();

            }
        }


    }
}
