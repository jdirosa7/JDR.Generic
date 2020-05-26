using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDR.Generic.Entities
{
    public class AccountTypeModel : IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
