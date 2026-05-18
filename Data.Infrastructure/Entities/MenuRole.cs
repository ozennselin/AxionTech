using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class MenuRole:BaseEntity
{
    public int RoleId { get; set; }//Test->1//PK
    public int   MenuId { get; set; }//Product,Create,Delete,Update,list//PK
    public bool IsActive{ get; set; }//true-false, false,true
}
