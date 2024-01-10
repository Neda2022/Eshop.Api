using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.Entities.RoleAgg.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities.RoleAgg;

public class Role:AggregateRoot
    {

    public string Title { get; private set; }

    public List<RolePermission> Permission { get; private set; }
    private Role()
    {

    }
    public Role(string title, List<RolePermission> permission)
    {
        NullOrEmtyDomainDataException.CheckString(title, nameof(title));

        Title = title;
        Permission = permission;

    }
    public Role(string title)
    {
        NullOrEmtyDomainDataException.CheckString(title, nameof(title));
        Title = title;
        Permission = new List<RolePermission>();

    }
    



    public void Edit(string title)
    {
        NullOrEmtyDomainDataException.CheckString(title, nameof(title));    
        Title=title;
    }
    public void SetPermissions(List<RolePermission> permissions)
    {
        Permission = permissions;
    }
}
