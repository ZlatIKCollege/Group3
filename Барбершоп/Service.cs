using System;
using System.Collections.Generic;

#nullable disable

namespace Барбершоп
{
    public partial class Service
    {
        public Service()
        {
            ProvisionOfServices = new HashSet<ProvisionOfService>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public int? Material { get; set; }

        public virtual Storage MaterialNavigation { get; set; }
        public virtual ICollection<ProvisionOfService> ProvisionOfServices { get; set; }
    }
}
