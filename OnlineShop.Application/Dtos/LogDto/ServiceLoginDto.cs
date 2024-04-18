using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.LogDto
{
    public class ServiceLoginDto
    {
        public required string Username {  get; set; }

        public required string Password { get; set; }    

        public required Boolean RememberMe { get; set; }
    }
}
