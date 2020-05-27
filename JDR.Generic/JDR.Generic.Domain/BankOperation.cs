using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Domain
{
    public class BankOperation
    {
        public Account SourceAccount { get; set; }
        public Account TargetAccount { get; set; }
        public decimal Value { get; set; }
        public MovementType MovementType { get; set; }
    }
}
