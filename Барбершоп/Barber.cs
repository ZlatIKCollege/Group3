using System;
using System.Collections.Generic;

#nullable disable

namespace Барбершоп
{
    public partial class Barber
    {
        public Barber()
        {
            ProvisionOfServices = new HashSet<ProvisionOfService>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimyc { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<ProvisionOfService> ProvisionOfServices { get; set; }
    }
}
