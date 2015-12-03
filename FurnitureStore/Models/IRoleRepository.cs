using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FurnitureStore.Models
{
    public interface IRoleRepository
    {
        List<Role> GetAllRoles();

        void Save(Role Role);

        Role GetRoleById(Guid Id);

        void RemoveRoleById(Guid Id);

        void UpdateRoleById(Role Role);
    }
}