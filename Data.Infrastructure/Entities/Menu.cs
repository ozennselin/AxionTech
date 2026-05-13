using Data.Infrastructure.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure.Entities;

internal class Menu:BaseEntity
{
    public int Id { get; set; }
    public string ControllerName { get; set; }
    public string ViewName { get; set; }
    public bool CreateCase { get; set; }//false
    public bool UpdateCase { get; set; }
    public bool DeleteCase { get; set; }
}
