// File: BalanceTestingWebAPi.contracts/Interfaces/IBalanceDbContext.
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BalanceTestingWebApi.contracts.Interfaces;

public interface IBalanceDbContext
{

    // Include common DbContext methods you intend to use in application logic
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
