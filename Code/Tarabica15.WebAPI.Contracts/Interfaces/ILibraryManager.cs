using System.Collections.Generic;
using Tarabica15.WebAPI.Contracts.Models;

namespace Tarabica15.WebAPI.Contracts.Interfaces
{
    public interface ILibraryManager
    {
        List<LibraryDto> GetLibraries();
        LibraryDto GetLibrary(int libraryId);
        void UpdateLibrary(LibraryDto library);
        void InsertLibrary(LibraryDto newLibrary);
        void DeleteLibrary(int libraryId);
    }
}