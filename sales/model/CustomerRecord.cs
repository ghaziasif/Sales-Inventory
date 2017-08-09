using System;
using System.Text;
using System.Collections.Generic;


namespace sales {
    
    public class CustomerRecord {
        public virtual int CustRecordId { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
