using Fiszki.Controllers;
using Fiszki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiszki.Repositories
{
    public class StatisticRepository
    {
        public static StatisticDTO GetStatistic(int id)
        {
            using (var dbContext = new FiszkiContext())
            {
                var userProgress = dbContext.ProgressTable.Where(item => item.UserId == id);

                var GETallWords = dbContext.WordsTable.Count();
                var GETwiem = userProgress.Where(item => item.WordStatus == "W" && item.UserId == id).Count();
                var GETmniej = userProgress.Where(item => item.WordStatus == "M" && item.UserId == id).Count();
                var GETnie = userProgress.Where(item => item.WordStatus == "N" && item.UserId == id).Count();
                var GETallProgress = userProgress.Where(item => item.UserId == id).Count();
                var GETtoday = userProgress.Where(item => item.DateEdit.Contains(DateTime.Now.ToString("yyyy-MM-dd"))).Count();
                var GETp_1 = userProgress.Where(item => item.DateEdit.Contains(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"))).Count();
                var GETp_2 = userProgress.Where(item => item.DateEdit.Contains(DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd"))).Count();
                var GETp_3 = userProgress.Where(item => item.DateEdit.Contains(DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"))).Count();
                var GETp_4 = userProgress.Where(item => item.DateEdit.Contains(DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd"))).Count();
                var GETp_5 = userProgress.Where(item => item.DateEdit.Contains(DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd"))).Count();
                var GETp_6 = userProgress.Where(item => item.DateEdit.Contains(DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd"))).Count();
                var GETp_7 = userProgress.Where(item => item.DateEdit.Contains(DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"))).Count();

                StatisticDTO result = new StatisticDTO
                {
                    allWords = GETallWords,
                    wiem = GETwiem,
                    mniej = GETmniej,
                    nie = GETnie,
                    allProgress = GETallProgress,
                    today = GETtoday,
                    p_1 = GETp_1, 
                    p_2 = GETp_2, 
                    p_3 = GETp_3, 
                    p_4 = GETp_4,
                    p_5 = GETp_5, 
                    p_6 = GETp_6, 
                    p_7 = GETp_7
                };

                return result;
            }
        }
    }
}
