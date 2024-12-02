﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ShareHubMIU.Application.Common.Interface;
using ShareHubMIU.Domain.Entities;
using ShareHubMIU.Infrastructure.Data;

namespace ShareHubMIU.Infrastructure.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {

        private readonly ApplicationDbContext _db;

        public ApplicationUserRepository(ApplicationDbContext db) 
            : base(db) 
        {
            _db = db;
        }

        public void Update(ApplicationUser entity)
        {
            _db.ApplicationUsers.Update(entity);
        }
    }
}