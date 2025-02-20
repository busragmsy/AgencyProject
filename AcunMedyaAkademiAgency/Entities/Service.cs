using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaAkademiAgency.Entities
{
	public class Service
	{
		public int ServiceId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
    }
}