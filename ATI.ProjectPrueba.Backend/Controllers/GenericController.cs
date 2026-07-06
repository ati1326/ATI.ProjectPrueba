using ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ATI.ProjectPrueba.Backend.Controllers
{
    public class GenericController<T>  : Controller where T : class
    {
        private readonly IGenericUnitOfWork<T> _unitOfWork;

        public GenericController(IGenericUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            var  action = await _unitOfWork.GetAsync();
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("{ID}")]
        public  virtual async Task<IActionResult> GetAsync(int ID)
        {
            var action = await _unitOfWork.GetAsync(ID);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return NotFound();
        }

        [HttpPost]
        public virtual async Task<IActionResult> PostAsync( T model)
        {
            var action = await _unitOfWork.AddAsync(model );
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }


        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T model)
        {
            var action = await _unitOfWork.UpdateAsync( model);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest(action.Message);
        }

        [HttpDelete("{ID}")]
        public virtual async Task<IActionResult> DeleteAsync(int ID)
        {
            var action = await _unitOfWork.DeleteAsync(ID);
            if (action.WasSuccess)
            {
                return NoContent();
            }
            return BadRequest(action.Message);
        }
    }
}
