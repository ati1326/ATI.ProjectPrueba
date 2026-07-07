using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Classlibrary.Responses;

namespace ATI.ProjectPrueba.Backend.Repositories.Interfaces
{
    public interface ICountriesRepository
    {
        Task<ActionResponse<Country>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<Country>>> GetAsync();

    }
}
