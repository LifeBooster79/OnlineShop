using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.UserDto
{
    public class ServiceSelectUsersDto
    {
        public List<SelectUserDto>? selectUsers { get; set; }
    }

    public class SelectUserDto
    {
        public string? Id { get; set; }

        public string? userName { get; set; }

        public string? email { get; set; }

        public string? phone { get; set; }

        public IEnumerable<string>? roles { get; set; }

    }
}
