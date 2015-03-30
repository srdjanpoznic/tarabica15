using System.Collections.Generic;
using System.Linq;
using Tarabica15.WebAPI.Common.Logging;
using Tarabica15.WebAPI.Contracts.Interfaces;
using Tarabica15.WebAPI.Contracts.Models;
using Tarabica15.WebAPI.Data.Models;

namespace Tarabica15.WebAPI.Business.Managers
{
    public class LibraryManager : BaseManager, ILibraryManager
    {
        private readonly Tarabica15Context _context;

        public LibraryManager(ILogger logger, Tarabica15Context context)
            : base(logger)
        {
            _context = context;
        }

        public List<LibraryDto> GetLibraries()
        {
            var libraries = _context.Libraries.ToList();
            return libraries.Select(lib => (LibraryDto)lib).ToList();
        }

        public LibraryDto GetLibrary(int libraryId)
        {
            LibraryDto library = _context.Libraries.SingleOrDefault(lib => lib.Id == libraryId);
            return library;
        }

        public void UpdateLibrary(LibraryDto library)
        {
            throw new System.NotImplementedException();
        }

        public void InsertLibrary(LibraryDto newLibrary)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLibrary(int libraryId)
        {
            throw new System.NotImplementedException();
        }
    }
}