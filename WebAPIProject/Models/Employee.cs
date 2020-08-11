using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIProject.Models
{
  public class Employee
  {
    public int id { get; set; }
    public string name { get; set; }

    public long salary { get; set; }
  }
}