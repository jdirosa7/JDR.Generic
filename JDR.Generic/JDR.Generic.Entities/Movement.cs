using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Entities
{
    public class Movement : IModel
    {
        public int Id { get; set; }
        public AccountModel FromAccount { get; set; }
        public AccountModel ToAccount { get; set; }
        public double Balance { get; set; }
        public DateTime Date { get; set; }
    }
}
