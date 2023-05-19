using SimpraOdev.Data.Context;
using SimpraOdev.Data.Models;
using SimpraOdev.Data.Repository.Base;

namespace SimApi.Data.Repository;

public class StaffRepository : GenericRepository<Staff>, IStaffRepository
{
    public StaffRepository(SimpraDbContext context) : base(context)
    {
    }

    public IEnumerable<Staff> FindByName(string name)
    {
        var list = dbContext.Set<Staff>().Where(c => c.FirstName.Contains(name)).ToList();
        return list;
    }

    public IEnumerable<Staff> FindBySurname(string surname)
    {
        var list = dbContext.Set<Staff>().Where(c => c.LastName.Contains(surname)).ToList();
        return list;
    }
}