using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class User : BaseModel
    {
        public string surname { get; set; }

        public string firstname { get; set; }

        public string middlename { get; set; }

        public DateTime birthday { get; set; }

        public string gender { get; set; }

        public bool have_childrens { get; set; }
    }
}
