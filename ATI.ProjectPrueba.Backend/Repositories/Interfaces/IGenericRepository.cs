using ATI.ProjectPrueba.Classlibrary.Responses;

namespace ATI.ProjectPrueba.Backend.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class 
    {
        Task<ActionResponse<T>> GetAsync(int ID);

        Task<ActionResponse<IEnumerable<T>>> GetAsync();

        Task<ActionResponse<T>> AddAsync(T entity);

        Task<ActionResponse<T>> DeleteAsync(int ID);

        Task<ActionResponse<T>> UpdateAsync(T entity);
    }
}
