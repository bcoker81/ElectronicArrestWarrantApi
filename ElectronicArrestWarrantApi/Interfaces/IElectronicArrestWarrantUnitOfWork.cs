using ElectronicArrestWarrantApi.Models;
using ElectronicArrestWarrantApi.Repository;

namespace ElectronicArrestWarrantApi.Interfaces
{
    public interface IElectronicArrestWarrantUnitOfWork
    {
        GenericRepository<AddressModel> AddressRepo { get; }
        GenericRepository<ChargeModel> ChargeRepo { get; }
        GenericRepository<EntryModel> EntryRepo { get; }
        GenericRepository<PersonModel> PersonRepo { get; }
        GenericRepository<SupplementalNameModel> SupplementalNameRepo { get; }

        void Save();
    }
}