﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Domain
{
    public class SavingAccount : IAccount
    {        
        public int AccountNumber { get; set; }
        public float Balance { get; set; }
    }
}