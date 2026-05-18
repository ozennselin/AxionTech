using Data.Infrastructure.Abstraction;

namespace Data.Infrastructure.Entities;

public class Menu:BaseEntity
{
    public string ControllerName { get; set; }//(5)ProductController
     public int ParentId { get; set; }//0
    public string ViewName { get; set; }//List,Create,Delete,Update
    public bool IsActive { get; set; }//false

    //
}
