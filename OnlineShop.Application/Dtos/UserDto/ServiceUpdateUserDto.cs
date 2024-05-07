using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.UserDto
{
    public class ServiceUpdateUserDto
    {
        public required string Id { get; set; }
        public  required string userName { get; set; }
        //Email
        public required string email { get; set; }
        //PhoneNumber
        public required string phone { get; set; }
    }
}
