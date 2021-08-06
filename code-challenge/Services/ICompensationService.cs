using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public interface ICompensationService
    {
        /// This method gets Compensation for an employee.
        List<Compensation> GetByEmployeeId(string id);

        /// This method will create, and save the newly created Compensation.
        Compensation Create(Compensation compensation);
    }
}
