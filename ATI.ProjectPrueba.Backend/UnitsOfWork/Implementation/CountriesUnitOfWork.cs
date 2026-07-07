using ATI.ProjectPrueba.Backend.Repositories.Interfaces;
using ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces;
using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Classlibrary.Responses;

namespace ATI.ProjectPrueba.Backend.UnitsOfWork.Implementation
{

    public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
    {
        private readonly ICountriesRepository _countriesRepository;

        public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository countriesRepository) : base(repository)
        {
            _countriesRepository = countriesRepository;
        }

        public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await _countriesRepository.GetAsync();

        public override async Task<ActionResponse<Country>> GetAsync(int id) => await _countriesRepository.GetAsync(id);
    }

}
