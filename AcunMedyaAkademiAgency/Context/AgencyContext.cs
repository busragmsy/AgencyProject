using AcunMedyaAkademiAgency.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AcunMedyaAkademiAgency.Context
{
	public class AgencyContext:DbContext
	{
		public DbSet<About> Abouts { get; set; }
		public DbSet<Category> Categories { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ProjectDetail> ProjectDetails { get; set; }

    }
}