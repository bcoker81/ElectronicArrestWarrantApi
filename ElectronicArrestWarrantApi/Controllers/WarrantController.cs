using ElectronicArrestWarrantApi.Models;
using ElectronicArrestWarrantApi.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElectronicArrestWarrantApi.Controllers
{
    [RoutePrefix("api/warrant")]
    public class WarrantController : BaseWarrantController
    {
        [HttpPost]
        [Route("submit")]
        public HttpResponseMessage Post(EntryModel entry)
        {
            if (entry != null)
            {
                using (var context = new ArrestWarrantDbContext())
                {
                    if (_uow == null)
                    {
                        _uow = new ElectronicArrestWarrantUnitOfWork(context);
                    }

                    var record = _uow.EntryRepo.FindMany(p => p.WarrantNumber == entry.WarrantNumber);
                    if (!record.Any())
                    {
                        _uow.EntryRepo.Add(entry);

                        if (entry.Persons != null)
                        {
                            foreach (var people in entry.Persons)
                            {
                                people.FkEntryId = entry.EntryId;
                                _uow.PersonRepo.Add(people);

                                if (people.Addresses != null)
                                {
                                    foreach (var address in people.Addresses)
                                    {
                                        address.FkPersonId = people.PersonId;
                                        _uow.AddressRepo.Add(address);
                                    }
                                }

                                if (people.SupplementalNames != null)
                                {
                                    foreach (var suppNames in people.SupplementalNames)
                                    {
                                        suppNames.FkPersonId = people.PersonId;
                                        _uow.SupplementalNameRepo.Add(suppNames);
                                    }
                                }
                               
                            }
                        }

                        if (entry.Charges != null)
                        {
                            foreach (var charge in entry.Charges)
                            {
                                charge.FkEntryId = entry.EntryId;
                                _uow.ChargeRepo.Add(charge);
                            }
                        }
                        _uow.Save();
                        _uow = null;
                    }
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, "Warrant Entry submitted successfully.");
        }
    }
}
