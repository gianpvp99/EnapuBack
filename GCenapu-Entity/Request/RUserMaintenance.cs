using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCenapu_Entity.Request
{
    public class RUserMaintenance
    {
      public int id {get;set;}
      public int idRol {get;set;}
      public string idTerminalPortuario {get;set;}
      public string lastName {get;set;}
      public string lastNameMother {get;set;}
      public string name {get;set;}
      //public string country {get;set;}
      public string department {get;set;}
      public string province {get;set;}
      public string district {get;set;}
      public string address {get;set;}
      public string numberPhone {get;set;}
      public string email {get;set;}
      public string nameUser {get;set;}
      public string password {get;set;}
      public string user {get;set;}
      public int option {get;set;}
    }
}
