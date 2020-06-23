using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiszki.Models
{
    public class UserAuthDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string DateAdd { get; set; }
    }
}
