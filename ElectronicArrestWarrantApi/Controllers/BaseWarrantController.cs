using ElectronicArrestWarrantApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElectronicArrestWarrantApi.Controllers
{
    public class BaseWarrantController : ApiController
    {
        public static IElectronicArrestWarrantUnitOfWork _uow;
    }
}
