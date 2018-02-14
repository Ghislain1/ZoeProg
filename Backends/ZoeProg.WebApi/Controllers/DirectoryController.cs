using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ZoeProg.WebApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ZoeProg.WebApi.Directory;
    using ZoeProg.WebApi.Directory.Models;
    using ZoeProg.WebApi.Models;

    [Route("api/[controller]")]
    public class DirectoryController : Controller
    {
        private readonly IDirectoryService directoryService;
        public DirectoryController(IDirectoryService directoryService)
        {
            this.directoryService = directoryService;
        }


        [HttpGet]
        public IEnumerable<DirectoryItem> GetAll()
        {
            // Get the logical drives
            var children = this. directoryService.GetLogicalDrives();

            return children;
        }
    }
}