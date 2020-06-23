using Fiszki.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiszki.Repositories
{
    public class ProgressRepository
    {

        public static List<Progress> GetProgress(int userId) 
        {
            using (var dbContext = new FiszkiContext()) 
            {
                return dbContext.ProgressTable.Where(p => p.UserId == userId).ToList();
            }
        }


        public static List<Progress> GetProgressId(int userId, int id) 
        {
            using (var dbContext = new FiszkiContext())
            {
                return dbContext.ProgressTable.Where(p => p.UserId == userId && p.WordId == id ).ToList();
            }
        }


        public static void AddProgress(Progress progresUpdate, int userId)
        {
            using (var dbContext = new FiszkiContext())
            {
                var userProgres = dbContext.ProgressTable.FirstOrDefault(x => x.UserId == userId && x.WordId == progresUpdate.WordId);
                if (userProgres != null)
                {
                    userProgres.WordStatus = progresUpdate.WordStatus;
                }
                else
                {
                    var newProgress = new Progress
                    {
                        UserId = userId,
                        WordId = progresUpdate.WordId,
                        WordStatus = progresUpdate.WordStatus,
                        DateEdit = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

                    };
                    dbContext.ProgressTable.Add(newProgress);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
