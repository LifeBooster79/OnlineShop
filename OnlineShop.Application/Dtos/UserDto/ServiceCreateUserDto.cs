using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.UserDto
{
    public class ServiceCreateUserDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
        //Email
        public required string Email { get; set; }
        //PhoneNumber
        public required string PhoneNumber { get; set; }
    }
}
