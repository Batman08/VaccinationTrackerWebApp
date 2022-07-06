﻿using Microsoft.EntityFrameworkCore;
using VaccinationTrackerWebApp.Data.Models;

namespace VaccinationTrackerWebApp.Data
{
    public class VaccinationTrackerContext: DbContext
    {
        public VaccinationTrackerContext(DbContextOptions options) : base(options) { }
        public DbSet<LoginData> LoginData{ get; set; }
        public DbSet<VaccinationCentreData> VaccinationCentreData { get; set; }
        public DbSet<VaccinationTypeData> VaccinationTypeData { get; set; }
    }
}
