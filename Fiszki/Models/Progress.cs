using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiszki.Repositories
{
    public class Progress
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WordId { get; set; }
        public string WordStatus { get; set; }
        public string DateEdit { get; set; }
    }
}
