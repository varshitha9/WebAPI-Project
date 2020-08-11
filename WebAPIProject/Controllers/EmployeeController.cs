using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIProject.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAPIProject.Controllers
{
    public class EmployeeController : ApiController
    {
    public IHttpActionResult getData()
    {
      List<Employee> employees = new List<Employee>();
      string conctn = ConfigurationManager.ConnectionStrings["TestConnection"].ConnectionString;
      SqlConnection sqlConnection = new SqlConnection(conctn);
      sqlConnection.Open();
      string query = "SELECT * FROM EmployeeInfo";
      SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
      SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
      while (sqlDataReader.Read())
      {
        employees.Add(new Employee() {
          id=Convert.ToInt16(sqlDataReader.GetValue(0)),
          name=sqlDataReader.GetValue(1).ToString(),
          salary=Convert.ToInt64(sqlDataReader.GetValue(2))
        });
      }
      return Ok(employees);
    }
    }
}
