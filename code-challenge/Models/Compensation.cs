using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Compensation
    {
        public int CompensationId { get; set; }

        public Employee employee { get; set; }

        public int salary { get; set; }

        private DateTime effdate { get; set; }

        private string pattern = "MM-dd-yyyy";

       
        public string effectiveDate
        {
            get
            {
                return effdate.ToString(pattern);
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    effdate = DateTime.ParseExact(value, pattern, null);
                }
            }
        }

    }
}
