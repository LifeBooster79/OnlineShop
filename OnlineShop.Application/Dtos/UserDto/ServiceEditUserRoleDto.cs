using Microsoft.AspNetCore.Identity;
using OnlineShop.Domain.Aggregates.UserManagementAggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.UserDto
{
    public class ServiceEditUserRoleDto
    {
        [Required]
        public string userId { get; set; }
        [Required]
        public List<string> roles { get; set; }
    }
}
