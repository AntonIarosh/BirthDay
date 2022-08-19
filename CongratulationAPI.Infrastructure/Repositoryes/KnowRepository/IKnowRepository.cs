using CongratulationAPI.Domain.Entities;
using CongratulationAPI.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CongratulationAPI.Infrastructure.Repositoryes.KnowRepository
{
    public interface IKnowRepository: IRepository<Know>
    {
        Task<List<Know>> GetAllKnowsWithUsersСonnectedFromBothSides();
    }
}
