﻿using Villa_Web.Models.Dto;

namespace Villa_Web.Services.IServices
{
    public interface IVillaService
    {
        // Generic methods to perform the crud operations for villa
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateDTO dto);
        Task<T> UpdateAsync<T>(VillaUpdateDTO dto);
        Task<T> DeleteAsync<T>(int id);
    }
}
