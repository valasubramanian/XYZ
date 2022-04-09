
using System;
using System.Collections.Generic;
using System.Text;
using X.Domain.Models;
using System.Threading.Tasks;

namespace X.Domain.ServiceContracts
{
    public interface IExternalService
    {
        Task<List<ProductModel>> GetAllProducts();
        int UpdateProduct();
    }
}