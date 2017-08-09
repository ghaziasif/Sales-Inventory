using System;
using System.Text;
using System.Collections.Generic;


namespace sales {
    
    public class Bill {
        public Bill() { }
        public virtual int BillId { get; set; }
        public virtual int? BillAmount { get; set; }
        public virtual DateTime BillDate { get; set; }
        public virtual int? BillAmoountPaid { get; set; }
        public virtual string BillType { get; set; }
    }
}
