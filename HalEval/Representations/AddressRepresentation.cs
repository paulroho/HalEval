using Newtonsoft.Json;
using WebApi.Hal;

namespace HalEval.Representations
{
    public class AddressRepresentation : Representation
    {
        [JsonProperty("street")]
        public string Street { get; set; }

        public override string Href { get { return "~/api/Addresses/1"; } }

        protected override void CreateHypermedia()
        {
        }
    }
}