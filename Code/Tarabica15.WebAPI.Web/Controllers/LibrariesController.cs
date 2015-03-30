using System.Collections.Generic;
using System.Web.Http;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Web.Controllers
{
    public class LibrariesController : ApiController
    {
        //public IEnumerable<LibraryDto> GetLibraries()
        //{
        //    return _libraryManager.GetLibraries();
        //}

        //public LibraryDto GetLibrary(int id)
        //{
        //    var lib = _libraryManager.GetLibrary(id);

        //    if (lib == null)
        //    {
        //        throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
        //    }
        //    return lib;
        //}

        //[HttpPost]
        //public IHttpActionResult Post(LibraryDto lib)
        //{
        //    if (lib == null)
        //    {
        //        return BadRequest("Argument Null");
        //    }

        //    var libExists = _libraryManager.GetLibrary(lib.Id);

        //    if (libExists != null)
        //    {
        //        return BadRequest("Exists");
        //    }

        //    _libraryManager.InsertLibrary(lib);
        //    return Ok();
        //}

        //[HttpPut]
        //public IHttpActionResult Put(LibraryDto lib)
        //{
        //    if (lib == null)
        //    {
        //        return BadRequest("Argument Null");
        //    }

        //    var libExists = _libraryManager.GetLibrary(lib.Id);

        //    if (libExists == null)
        //    {
        //        return NotFound();
        //    }

        //    _libraryManager.UpdateLibrary(lib);
        //    return Ok();
        //}

        //[HttpDelete]
        //public IHttpActionResult Delete(int id)
        //{
        //    var lib = _libraryManager.GetLibrary(id);
            
        //    if (lib == null)
        //    {
        //        return NotFound();
        //    }

        //    _libraryManager.DeleteLibrary(id);
        //    return Ok();
        //}
    }
}
