using ATI.ProjectPrueba.Classlibrary.Responses;

namespace ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {

        Task<ActionResponse<IEnumerable<T>>> GetAsync();
      
        Task<ActionResponse<T>> AddAsync(T model);

        Task<ActionResponse<T>> UpdateAsync(T model);

        Task<ActionResponse<T>> DeleteAsync(int ID);
      
        Task<ActionResponse<T>> GetAsync(int ID);


    }
}
