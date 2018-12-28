using System;
using System.Collections.Generic;
using System.Text;

namespace Haiyue.Model.Dto.Expenditures
{
    public class SelectExpenditureDto:SelectBaseDto
    {
        public int? ExpenditureTypeId { get; set; }
    }
}
