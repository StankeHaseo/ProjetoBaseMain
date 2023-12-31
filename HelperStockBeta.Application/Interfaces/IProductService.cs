﻿using System.Threading.Tasks;
using HelperStockBeta.Application.DTOs;

namespace HelperStockBeta.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProduct();
        Task<ProductDTO> GetById(int? id);
        Task Add(ProductDTO productDTO);
        Task Update(ProductDTO productDTO);
        Task Remove(int? id);
    }
}
