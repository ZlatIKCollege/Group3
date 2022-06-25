using System;
using System.Collections.Generic;

#nullable disable

namespace Барбершоп
{
    public partial class ProvisionOfService
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Service { get; set; }
        public decimal Price { get; set; }
        public int Barber { get; set; }
        public int Client { get; set; }

        public virtual Barber BarberNavigation { get; set; }
        public virtual Client ClientNavigation { get; set; }
        public virtual Service ServiceNavigation { get; set; }
    }
}
