using System;
using System.Text;
using System.Collections.Generic;


namespace sales {
    
    public class Customer {
        public Customer() { }
        public virtual int CustomerId { get; set; }
        public virtual string CustomerName { get; set; }
        public virtual int? CustomerBalance { get; set; }
        public virtual string CustomerAddress { get; set; }
        public virtual string CustomerPhoneNumber { get; set; }
    }
}
