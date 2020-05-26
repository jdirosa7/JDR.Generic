using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Entities
{
    public class AccountModel : IModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public AccountTypeModel AccountType { get; set; }
        public double Balance { get; set; }
    }
}
