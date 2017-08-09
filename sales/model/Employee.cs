using System;
using System.Text;
using System.Collections.Generic;


namespace sales {
    
    public class Employee {
        public Employee() { }
        public virtual int EmpId { get; set; }
        public virtual string EmpName { get; set; }
        public virtual string EmpAddress { get; set; }
        public virtual string EmpDesignation { get; set; }
        public virtual string EmpPhone { get; set; }
    }
}
