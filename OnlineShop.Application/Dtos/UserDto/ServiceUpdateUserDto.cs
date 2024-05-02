using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.UserDto
{
    public class ServiceUpdateUserDto
    {
        public string Id { get; set; }
        public  string UserName { get; set; }
        public  string Password { get; set; }
        //Email
        public  string Email { get; set; }
        //PhoneNumber
        public  string PhoneNumber { get; set; }
    }
}
