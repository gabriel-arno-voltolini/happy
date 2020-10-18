using Happy.Application.AppFlowControl;
using Happy.Application.Models.Orphanage;
using System.Threading.Tasks;

namespace Happy.Application.Interfaces.Services
{
    public interface IOrphanageService : IGenericService<OrphanageRequestModel, OrphanageResponseModel>
    {
        Task<DataResponse<OrphanageResponseModel>> GetAll();
    }
}
