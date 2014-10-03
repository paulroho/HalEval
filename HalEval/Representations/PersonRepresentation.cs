using WebApi.Hal;

namespace HalEval.Representations
{
    public class PersonRepresentation : Representation
    {
        public string Name { get; set; }

        public override string Href { get { return "~/api/Persons/1"; } }

        protected override void CreateHypermedia()
        {
        }
    }
}