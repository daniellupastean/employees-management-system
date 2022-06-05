using LibrarieModele;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NivelAccesDate
{
    public interface IRolesStorage : IStocareFactory
    {
        List<Role> GetRoles();
        Role GetRole(int id);
        bool AddRole(Role r);
        bool UpdateRole(Role r);
        bool DeleteRole(int id);
    }
}
