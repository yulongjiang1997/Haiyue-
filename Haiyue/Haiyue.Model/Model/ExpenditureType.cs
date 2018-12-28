using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Model
{
    public class ExpenditureType:BaseModel
    {
        public string Name { get; set; }

        public ICollection<Expenditure> Expenditures { get; set; }
    }
}
