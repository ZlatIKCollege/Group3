using System;
using System.Collections.Generic;

#nullable disable

namespace Барбершоп
{
    public partial class Storage
    {
        public Storage()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string Material { get; set; }
        public int? Count { get; set; }
        public string Postav { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
