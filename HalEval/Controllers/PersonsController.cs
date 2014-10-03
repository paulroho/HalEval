using System.Collections.Generic;
using System.Web.Http;
using HalEval.Representations;

namespace HalEval.Controllers
{
    public class PersonsController : ApiController
    {
        public List<PersonRepresentation> GetAll()
        {
            return new List<PersonRepresentation>
            {
                new PersonRepresentation()
            };
        }

        public PersonRepresentation GetAPerson(int id)
        {
            return new PersonRepresentation(){Name = "Paul"};
        }
    }
}