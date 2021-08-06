using challenge.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface ICompensationRepository
    {
        /// This method will return a collection of all the Compensations present for an employee.
        IEnumerable<Compensation> Get(string id);

        /// This method will create a new Compensation for an employee.
        Compensation Add(Compensation compensation);

        /// This methods will be used to save all the changes made to the context, asynchronously.
        Task SaveAsync();
    }
}