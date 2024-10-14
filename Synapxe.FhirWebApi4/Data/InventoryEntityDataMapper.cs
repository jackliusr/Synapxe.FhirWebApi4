using Hl7.Fhir.Model;
using Ihis.FhirEngine.Core.Handlers.Data;
using Ihis.FhirEngine.Core.Utility;

namespace Synapxe.FhirWebApi4.Data
{
    public sealed class InventoryEntityDataMapper : IFhirDataMapper<InventoryEntity, Inventory>
    {
        public InventoryEntity ReverseMap(Inventory inventory)
        {
            return new InventoryEntity
            {
                Id = inventory.Id,
                VersionId = int.TryParse(inventory.VersionId, out var vid) ? vid : 0,
                LastUpdated = inventory.Meta?.LastUpdated,
                //Tag = inventory.Meta?.Tag.Select(x => x.Code).FirstOrDefault(),
                Active = inventory.Active,
            };
        }

        public Inventory Map(InventoryEntity data)
        {
            var inventory = new Inventory
            {
                Id = data.Id.ToUpper(),
                Meta = new Meta
                {
                    VersionId = data.VersionId.ToString(),
                    LastUpdated = data.LastUpdated,
                },
                Active = data.Active,
                //Sender = new ResourceReference(data.Sender.Reference),
                //Receiver = new ResourceReference(data.Receiver.Reference),
            };
            return inventory;
        }
    }
}
