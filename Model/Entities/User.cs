using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class User : CoreEntity
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int TempPassword { get; set; }
        public int UserType { get; set; }
    }
}
