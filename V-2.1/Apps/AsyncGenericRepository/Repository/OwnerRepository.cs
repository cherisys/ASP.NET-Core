using Contracts;
using Entities;
using Entities.ExtendedModels;
using Entities.Extensions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class OwnerRepository:RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext):base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            var owners = await FindAllAsync();
            return owners.OrderBy(x => x.Name);
        }

        public async Task<Owner> GetOwnerByIdAsync(Guid OwnerId)
        {
            var owner = await FindByConditionAsync(o => o.Id.Equals(OwnerId));
            return owner.DefaultIfEmpty(new Owner()).FirstOrDefault();
        }

        public async Task<OwnerExtended> GetOwnerWithDetailsAsync(Guid OwnerId)
        {
            var owner = await GetOwnerByIdAsync(OwnerId);
            return new OwnerExtended(owner)
            {
                Accounts = await RepositoryContext.Accounts.Where(o => o.Id == OwnerId).ToListAsync()
            };
        }

        public async Task CreateOwnerAsync(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            Create(owner);
            await SaveAsync();
        }

        public async Task UpdateOwnerAsync(Owner dbOwner, Owner owner)
        {
            dbOwner.Map(owner);
            Update(dbOwner);
            await SaveAsync();
        }

        public async Task DeleteOwnerAsync(Owner owner)
        {
            Delete(owner);
            await SaveAsync();
        }
    }
}
