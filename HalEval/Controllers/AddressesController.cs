using System.Web.Http;
using HalEval.Representations;

namespace HalEval.Controllers
{
    public class AddressesController : ApiController
    {
        public AddressRepresentation GetAnAddress(int id)
        {
            return new AddressRepresentation {Street = "Otto-Bondy-Platz"};
        }
    }
}