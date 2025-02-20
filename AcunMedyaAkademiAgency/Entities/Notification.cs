using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcunMedyaAkademiAgency.Entities
{
	public class Notification
	{
        public int NotificationId { get; set; }
        public string NameSurname { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}