using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        /// Constructor for the CompensationService.
        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        /// This method gets all the Compensations for an employee by it's ID.
        public List<Compensation> GetByEmployeeId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new NullReferenceException("Employee id is null.");
            }

            return _compensationRepository.Get(id).ToList();
        }

        /// This method creates and saves new Compensation for an employee.
        public Compensation Create(Compensation compensation)
        {
            if (compensation == null)
            {
                throw new NullReferenceException("Compensation is null.");
            }

            _compensationRepository.Add(compensation);
            _compensationRepository.SaveAsync().Wait();
            return compensation;
        }
    }
}
