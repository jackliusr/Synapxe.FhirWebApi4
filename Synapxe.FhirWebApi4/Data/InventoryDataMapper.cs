using Hl7.Fhir.Model;
using Ihis.FhirEngine.Core.Handlers.Data;
using Ihis.FhirEngine.Core.Utility;

namespace Synapxe.FhirWebApi4.Data
{
    public sealed class InventoryDataMapper : IFhirDataMapper<InventoryModel, Inventory>
    {
        public InventoryModel ReverseMap(Inventory inventory)
        {
            return new InventoryModel
            {
                Id = Guid.Parse(inventory.Id),
                VersionId = int.TryParse(inventory.VersionId, out var vid) ? vid : 0,
                LastUpdated = inventory.Meta?.LastUpdated,
                Tag = inventory.Meta?.Tag.Select(x => x.Code).FirstOrDefault(),
                Active = inventory.Active,
                Sender = inventory.Sender?.Reference,
                Receiver = inventory.Receiver?.Reference,
            };
        }

        public Inventory Map(InventoryModel data)
        {
            var inventory = new Inventory
            {
                Id = data.Id.ToString("N").ToUpper(),
                Meta = new Meta
                {
                    VersionId = data.VersionId.ToString(),
                    LastUpdated = data.LastUpdated,
                },
                Active = data.Active,
                Sender = new ResourceReference(data.Sender),
                Receiver = new ResourceReference(data.Receiver),
            };

            if (data.Tag != null)
            {
                inventory.Meta.Tag = new List<Coding>
                {
                    new Coding{ Code = data.Tag },
                };
            }

            return inventory;
        }
    }
}
