using Entities.ExtendedModels;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IOwnerRepository
    {
        Task<IEnumerable<Owner>> GetAllOwnersAsync();
        Task<Owner> GetOwnerByIdAsync(Guid OwnerId);
        Task<OwnerExtended> GetOwnerWithDetailsAsync(Guid OwnerId);
        Task CreateOwnerAsync(Owner owner);
        Task UpdateOwnerAsync(Owner dbOwner, Owner owner);
        Task DeleteOwnerAsync(Owner owner);
    }
}
