using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaAkademiAgency.Entities
{
	public class ProjectDetail
	{
		public int ProjectDetailId { get; set; }
		
        public string Description { get; set; }
		public int ProjectId { get; set; }
		public virtual Project Projects { get; set; }
        public string Title { get; set; }

    }
}