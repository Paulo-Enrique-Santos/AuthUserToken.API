﻿using Microsoft.EntityFrameworkCore;

namespace AuthUserToken.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
