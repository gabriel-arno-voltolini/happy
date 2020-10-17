using Happy.Application.AppFlowControl;
using Happy.Application.Interfaces.Services;
using Happy.Application.Models.Orphanage;
using Happy.Domain.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Happy.Application.Services
{
    public class OrphanageService : IOrphanageService
    {
        private readonly IOrphanageRepository _orphanageRepository;

        public OrphanageService(IOrphanageRepository orphanageRepository)
        {
            _orphanageRepository = orphanageRepository;
        }

        public Task<DataResponse<OrphanageResponseModel>> Create(OrphanageRequestModel entity)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<OrphanageResponseModel>> GetAll(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DataResponse<OrphanageResponseModel>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Response> Update(int id, OrphanageRequestModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
