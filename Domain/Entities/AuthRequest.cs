using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AuthRequest
    {
        public string? User { get; set; }
        public string? Pass { get; set; }
    }
}
