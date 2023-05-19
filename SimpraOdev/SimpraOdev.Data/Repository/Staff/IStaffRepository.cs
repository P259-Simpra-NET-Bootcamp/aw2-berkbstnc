using SimpraOdev.Data.Models;
using SimpraOdev.Data.Repository.Base;

namespace SimApi.Data.Repository;

public interface IStaffRepository : IGenericRepository<Staff>
{
    IEnumerable<Staff> FindByName(string name);
    IEnumerable<Staff> FindBySurname(string surname);
}