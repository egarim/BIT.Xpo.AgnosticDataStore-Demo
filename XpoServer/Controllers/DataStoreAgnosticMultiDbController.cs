using BIT.Xpo.AspNetCore;
using BIT.Xpo.AspNetCore.AgnosticDataStore;
using DevExpress.Xpo.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace XpoServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataStoreAgnosticMultiDbController : MultiDataStoreBaseController
    {
        public DataStoreAgnosticMultiDbController(IDataStoreResolver DataStoreResolver) : base(DataStoreResolver)
        {

        }
    }
}
