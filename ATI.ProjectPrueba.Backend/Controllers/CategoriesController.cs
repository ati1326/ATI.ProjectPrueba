using ATI.ProjectPrueba.Backend.UnitsOfWork.Interfaces;
using ATI.ProjectPrueba.Classlibrary.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ATI.ProjectPrueba.Backend.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : GenericController<Category>
    {
        public CategoriesController(IGenericUnitOfWork<Category> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
