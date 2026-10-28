using RentCore.Domain.Enums;

namespace RentCore.Domain.Entities
{
    public class RentalAgreementEquipment
    {
        public Guid RentalAgreementId { get; set; }
        public Guid EquipmentId { get; set; }
        public EquipmentStage Stage { get; set; }
        public bool? ReturnedOk { get; set; }
    }
}
