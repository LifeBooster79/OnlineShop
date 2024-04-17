using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.RoleDto
{
    public class ServiceCreateRoleDto
    {
     [Required]
     public string RoleName { get; set; }

    }
}
