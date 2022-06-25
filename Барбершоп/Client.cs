using System;
using System.Collections.Generic;

#nullable disable

namespace Барбершоп
{
    public partial class Client
    {
        public Client()
        {
            ProvisionOfServices = new HashSet<ProvisionOfService>();
        }

        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<ProvisionOfService> ProvisionOfServices { get; set; }
    }
}
