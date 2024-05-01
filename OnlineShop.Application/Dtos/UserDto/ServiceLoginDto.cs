using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.UserDto
{
    public class ServiceLoginDto
    {
        public required string userName {  get; set; }

        public required string password { get; set; }
    }
}
