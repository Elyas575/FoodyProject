﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Contracts
{
   public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync(int restaurantId, bool trackChanges);
        Task <Category> GetCategoryAsync(int restaurantId, int categoryId, bool trackChanges);
        void CreateCategory(int restaurantId, Category category);
        void DeleteCategory(Category category);
    }
}