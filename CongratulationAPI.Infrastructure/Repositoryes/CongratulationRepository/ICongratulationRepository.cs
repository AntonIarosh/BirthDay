using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongratulationAPI.Infrastructure.Repositoryes.CongratulationRepository
{
    public interface ICongratulationRepository : IRepository<Congratulation>
    {
        Task<List<Congratulation>> GetAllCongratulationsWithUsersFromUsersAndBirthDays();
    }
}
