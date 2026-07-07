using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Classlibrary.Responses;

namespace ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces
{
    public interface ICountriesUnitOfWork
    {

        Task<ActionResponse<Country>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Country>>> GetAsync();

    }
}
