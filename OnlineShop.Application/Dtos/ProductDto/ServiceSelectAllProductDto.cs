using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Dtos.ProductDto
{
    public class ServiceSelectAllProductDto
    {
        public List<ServiceSelectProductDto> serviceSelectProductDtoList;

        public ServiceSelectAllProductDto()
        {
            serviceSelectProductDtoList = new List<ServiceSelectProductDto>();
        }
    }
}
