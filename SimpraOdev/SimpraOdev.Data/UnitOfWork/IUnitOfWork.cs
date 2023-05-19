using SimpraOdev.Data.Models;
using SimpraOdev.Data.Repository.Base;

namespace SimApi.Data.Uow;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Staff> StaffRepository { get; }

    void Complete();
    void CompleteWithTransaction();
}