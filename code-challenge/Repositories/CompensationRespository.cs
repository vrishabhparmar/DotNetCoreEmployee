using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using challenge.Data;

namespace challenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public IEnumerable<Compensation> Get(string id)
        {
            return _employeeContext.Compensation.Include(e => e.employee)
                .Where(e => e.employee.EmployeeId == id).ToList();
        }

        public Compensation Add(Compensation comp)
        {
            Employee employee = _employeeContext.Employees.Include(e => e.DirectReports)
                .SingleOrDefault(e => e.EmployeeId == comp.employee.EmployeeId);

            _employeeContext.Compensation.Update(comp);


            return comp;
        }

        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
    }
}
