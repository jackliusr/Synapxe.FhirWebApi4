using Hl7.Fhir.Introspection;
using Hl7.Fhir.Model;
using Ihis.FhirEngine.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Synapxe.FhirWebApi4.Data
{
    [FhirType("Inventory", IsResource = true)]
    [PrimaryKey(nameof(Id), nameof(VersionId))]
    public class InventoryModel : IResourceEntity<Guid>
    {
        public Guid Id { get; set; }

        public int? VersionId { get; set; }

        public bool IsHistory { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }

        public bool? Active { get; set; }

        public string? Sender { get; set; }

        public string? Receiver { get; set; }

        public DateTimeOffset? CreationDateTime { get; set; }

        public string? Tag { get; set; }

        public byte[]? TimeStamp { get; set; }
    }
}
