using ATI.ProjectPrueba.Backend.Repositories.Interfaces;
using ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces;
using ATI.ProjectPrueba.Classlibrary.Responses;

namespace ATI.ProjectPrueba.Backend.UnitsOfWork.Implementation
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }


        public virtual async Task<ActionResponse<T>> AddAsync(T model) => await _repository.AddAsync(model);
     

        public virtual async Task<ActionResponse<T>> DeleteAsync(int ID) => await _repository.DeleteAsync(ID);
       

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync() => await _repository.GetAsync();
        

        public virtual async Task<ActionResponse<T>> GetAsync(int ID) => await _repository.GetAsync(ID);


        public virtual async Task<ActionResponse<T>> UpdateAsync(T model) => await _repository.UpdateAsync(model);

    }
}
