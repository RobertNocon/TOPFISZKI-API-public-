using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiszki.Models
{
    public class WordDTO
    {
        public int Id { get; set; }
        public string Wordpl { get; set; }
        public string Worden { get; set; }
        public string WordCategory { get; set; }
        public string WordStatus { get; set; }
        public string DateEdit { get; set; }
    }
}
