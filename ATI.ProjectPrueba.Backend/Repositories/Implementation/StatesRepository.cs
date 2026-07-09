using ATI.ProjectPrueba.Backend.Data;
using ATI.ProjectPrueba.Backend.Repositories.Interfaces;
using ATI.ProjectPrueba.Classlibrary.Entities;
using ATI.ProjectPrueba.Classlibrary.Responses;
using Microsoft.EntityFrameworkCore;

namespace ATI.ProjectPrueba.Backend.Repositories.Implementation
{
    public class StatesRepository :  GenericRepository<State>,
        IStatesRepository
    {
        private readonly DataContext _context;

        public StatesRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<ActionResponse<State>> GetAsync(int id)
        {

            var state = await _context.States
                .Include(s => s.Cities)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (state == null)
            {
                return new ActionResponse<State>
                {
                    WasSuccess = false,
                    Message = "Etado no Existe"
                };
            }

            return new ActionResponse<State>
            {
                WasSuccess = true,
                Result = state
            };
        }

        public override async Task<ActionResponse<IEnumerable<State>>> GetAsync()
        {
            var States = await _context.States
                .Include(s => s.Cities)
                .ToListAsync();

            return new ActionResponse<IEnumerable<State>>
            {
                WasSuccess = true,
                Result = States
            };
        }
    }
}

