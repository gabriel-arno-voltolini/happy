using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Happy.Web.Interfaces.Controllers
{
    internal interface IGenericController<TEntityRequestModel>
    {
        Task<IActionResult> Get();

        Task<IActionResult> Get(int id);

        Task<IActionResult> Post(TEntityRequestModel requestModel);

        Task<IActionResult> Put(int id, TEntityRequestModel requestModel);

        Task<IActionResult> Delete(int id);
    }
}