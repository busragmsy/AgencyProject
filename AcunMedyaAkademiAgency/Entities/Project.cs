using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaAkademiAgency.Entities
{
	public class Project
	{
		public int ProjectId { get; set; }
		public string ImageUrl { get; set; }
		public string Title { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
		public List<ProjectDetail> ProjectDetails { get; set; }

    }
}