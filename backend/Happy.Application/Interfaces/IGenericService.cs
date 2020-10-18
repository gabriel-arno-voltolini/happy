using Happy.Application.AppFlowControl;
using System.Threading.Tasks;

namespace Happy.Application.Interfaces
{
    public interface IGenericService<TEntityRequest, TEntityResponse>
    {
        Task<DataResponse<TEntityResponse>> Create(TEntityRequest requestModel);

        Task<DataResponse<TEntityResponse>> GetById(int id);

        Task<Response> Update(int id, TEntityRequest requestModel);

        Task<Response> Delete(int id);
    }
}
