﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Entities;
using Entities.Models;
using Repositoy;

namespace Repository
{
    public class MealOptionRepository : RepositoryBase<MealOption>, IMealOptionRepository
    {
        public MealOptionRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }
    }
}
