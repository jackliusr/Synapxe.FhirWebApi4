// -------------------------------------------------------------------------------------------------
// Copyright (c) Integrated Health Information Systems Pte Ltd. All rights reserved.
// -------------------------------------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace Synapxe.FhirWebApi4.Data
{
    public class FhirModelDbContext : DbContext
    {
        public FhirModelDbContext(DbContextOptions<FhirModelDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppointmentModel> Appointments => Set<AppointmentModel>();

        public DbSet<EducationModel> Education => Set<EducationModel>();

        //public DbSet<InventoryModel> Inventory => Set<InventoryModel>();

        public DbSet<InventoryEntity> Inventory => Set<InventoryEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseFhirConventions(this);
        }
    }
}
