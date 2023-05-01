﻿using Villa_Web.Models.Dto;

namespace Villa_Web.Services.IServices
{
    public interface IVillaNumberService
    {
        // Generic methods to perform the crud operations for villa
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaNumberCreateDTO dto);
        Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
