using Fiszki.Controllers;
using Fiszki.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiszki.Repositories
{
    public class WordsRepository
    {
        // === Dla poniższych metod ===
        public static List<WordDTO> WordsWithUserProgress(int id)
        {
            using (var dbContext = new FiszkiContext())
            {
                List<Words> words = dbContext.WordsTable.ToList();
                List<Progress> progress = dbContext.ProgressTable.Where(item => item.UserId == id).ToList();

                List<WordDTO> WordsWithProgress = (from w in words
                                                   join p in progress
                                                   on w.Id equals p.WordId
                                                   into subProgress
                                                   from userProgress in subProgress.DefaultIfEmpty()
                                                   select new WordDTO { Id = w.Id, Wordpl = w.Wordpl, Worden = w.Worden, WordCategory = w.WordCategory, WordStatus = userProgress?.WordStatus ?? null, DateEdit = userProgress?.DateEdit ?? null }).ToList();
                return WordsWithProgress;
            }
        }


        // === Baza słów + tabela z postępem ===
        public static List<WordDTO> GetWordsList(int userId)
        {
            return WordsWithUserProgress(userId);
        }

        // === Słowo z ID + postęp ===
        public static WordDTO GetWordId(int userId, int wordID)
        {
            return WordsWithUserProgress(userId).Where(item => item.Id == wordID).FirstOrDefault();
        }


        public static WordDTO GetRandomWord(int id)
        {
                List <WordDTO> WordsWithProgress = WordsWithUserProgress(id);

                List<WordDTO> unknownWords = WordsWithProgress.Where(item => item.WordStatus != "W").ToList();
                int unknownWordsCount = unknownWords.Count;

                if (unknownWordsCount == 0)
                {
                    return null;
                }

                Random randNum = new Random();
                int randIndex = randNum.Next(0, unknownWordsCount);

                var result = unknownWords[randIndex];
                return result;
        }

        public static void DeleteWord(int id)
        {
            using (var dbContext = new FiszkiContext()) 
            {
                var item = dbContext.WordsTable.FirstOrDefault(x => x.Id == id);
                dbContext.WordsTable.Remove(item);
                dbContext.SaveChanges();
            }
        }

        public static void AddWord(Words value)
        {
            using (var dbContext = new FiszkiContext())
            {
                var newWord = new Words
                {
                    Wordpl = value.Wordpl,
                    Worden = value.Worden,
                    WordCategory = value.WordCategory

                };
                dbContext.WordsTable.Add(newWord);
                dbContext.SaveChanges();

                int id = newWord.Id;

            }
        }

        public static void EditWord(int id, Words value)
        {
            using (var dbContext = new FiszkiContext())
            {
                var Word = dbContext.WordsTable.FirstOrDefault(x => x.Id == id);

                Word.Wordpl = value.Wordpl;
                Word.Worden = value.Worden;
                Word.WordCategory = value.WordCategory;

                dbContext.SaveChanges();
            }
        }


    }
}
