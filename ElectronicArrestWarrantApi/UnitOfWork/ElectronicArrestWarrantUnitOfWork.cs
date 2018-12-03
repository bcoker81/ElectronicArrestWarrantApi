using ElectronicArrestWarrantApi.Interfaces;
using ElectronicArrestWarrantApi.Models;
using ElectronicArrestWarrantApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicArrestWarrantApi.UnitOfWork
{
    public class ElectronicArrestWarrantUnitOfWork : IElectronicArrestWarrantUnitOfWork
    {
        private GenericRepository<EntryModel> _entryRepo;
        private GenericRepository<PersonModel> _personRepo;
        private GenericRepository<AddressModel> _addressRepo;
        private GenericRepository<SupplementalNameModel> _supplementalNameRepo;
        private GenericRepository<ChargeModel> _chargeRepo;

        private ArrestWarrantDbContext _entities;

        public ElectronicArrestWarrantUnitOfWork(ArrestWarrantDbContext Entities)
        {
            _entities = Entities;
        }

        public GenericRepository<EntryModel> EntryRepo
        {
            get
            {
                if (_entryRepo == null)
                {
                    _entryRepo = new GenericRepository<EntryModel>(_entities);
                }

                return _entryRepo;
            }
        }

        public GenericRepository<ChargeModel> ChargeRepo
        {
            get
            {
                if (_chargeRepo == null)
                {
                    _chargeRepo = new GenericRepository<ChargeModel>(_entities);
                }

                return _chargeRepo;
            }
        }

        public GenericRepository<PersonModel> PersonRepo
        {
            get
            {
                if (_personRepo == null)
                {
                    _personRepo = new GenericRepository<PersonModel>(_entities);
                }

                return _personRepo;
            }
        }

        public GenericRepository<AddressModel> AddressRepo
        {
            get
            {
                if (_addressRepo == null)
                {
                    _addressRepo = new GenericRepository<AddressModel>(_entities);
                }

                return _addressRepo;
            }
        }

        public GenericRepository<SupplementalNameModel> SupplementalNameRepo
        {
            get
            {
                if (_supplementalNameRepo == null)
                {
                    _supplementalNameRepo = new GenericRepository<SupplementalNameModel>(_entities);
                }

                return _supplementalNameRepo;
            }
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}