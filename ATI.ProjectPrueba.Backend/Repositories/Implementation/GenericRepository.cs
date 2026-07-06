using ATI.ProjectPrueba.Backend.Data;
using ATI.ProjectPrueba.Backend.Repositories.Interfaces;
using ATI.ProjectPrueba.Classlibrary.Responses;
using Microsoft.EntityFrameworkCore;

namespace ATI.ProjectPrueba.Backend.Repositories.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public async Task<ActionResponse<T>> AddAsync(T entity)
        { 
            _context.Add(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)

            {
               return ExceptionActionResponse(exception);
            }   
 
        }

       

        public async Task<ActionResponse<T>> DeleteAsync(int ID)
        {
             
            var row = await _entity.FindAsync(ID); 
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Message =  "Registro no encontrado"
                };
            }

            try
            {
                 _entity.Remove(row);   
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true
                };
            }
            catch 
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "No se puede borrar por que tiene registos relacionados"
                };
            }
        }

        public async Task<ActionResponse<T>> GetAsync(int ID)
        {

            var row = await _entity.FindAsync(ID);
            if (row == null)
            {
                return new ActionResponse<T>
                {
                    WasSuccess = false,
                    Message = "Registro no encontrado"
                };
            }

            return new ActionResponse<T>
            {
                WasSuccess = true,
                Result = row
            };

        }


        public async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        {
            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result =  await _entity.ToListAsync()
            };
        }


        public async Task<ActionResponse<T>> UpdateAsync(T entity)
        {

            _context.Update(entity);
            try
            {
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    WasSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)

            {
                return ExceptionActionResponse(exception);
            }
        }


        private ActionResponse<T> DbUpdateExceptionActionResponse()
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = "Ya existe el registro que estas intentado crear."
            };
        }


        private ActionResponse<T> ExceptionActionResponse(Exception exception)
        {
            return new ActionResponse<T>
            {
                WasSuccess = false,
                Message = exception.Message
            };
        }
    }
}
