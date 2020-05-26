﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Domain
{
    public class BankOperation
    {
        public IAccount SourceAccount { get; set; }
        public IAccount TargetAccount { get; set; }
        public double Value { get; set; }
    }
}