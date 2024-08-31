using HR_Management.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Persistence
{
    public class HRManagementDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HRManagementDbContext(DbContextOptions<HRManagementDbContext> options) : base(options)
        {
            _httpContextAccessor = this.GetService<IHttpContextAccessor>();
        }

        public DbSet<Domain.LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Domain.LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Domain.LeaveType> LeaveTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HRManagementDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = _httpContextAccessor.HttpContext.User.Claims
                    .First(c => c.Type == ClaimTypes.NameIdentifier).Value;


                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User.Claims.
                        First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                }
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainEntity>())
            {
                entry.Entity.LastModifiedDate = DateTime.Now;
                entry.Entity.LastModifiedBy = _httpContextAccessor.HttpContext.User.Claims
                    .First(c => c.Type == ClaimTypes.NameIdentifier).Value;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = _httpContextAccessor.HttpContext.User.Claims
                        .First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                }
            }

            return base.SaveChanges();
        }
    }
}
