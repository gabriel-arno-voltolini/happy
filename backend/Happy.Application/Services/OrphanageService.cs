using AutoMapper;
using Happy.Application.AppFlowControl;
using Happy.Application.Interfaces.Services;
using Happy.Application.Models.Orphanage;
using Happy.Domain.Entities;
using Happy.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Happy.Application.Services
{
    public class OrphanageService : IOrphanageService
    {
        private readonly IOrphanageRepository _orphanageRepository;
        private readonly IMapper _mapper;

        public OrphanageService(IOrphanageRepository orphanageRepository, IMapper mapper)
        {
            _orphanageRepository = orphanageRepository;
            _mapper = mapper;
        }

        public async Task<DataResponse<OrphanageResponseModel>> Create(OrphanageRequestModel requestModel)
        {
            var response = new DataResponse<OrphanageResponseModel>();
            var orphanage = _mapper.Map<Orphanage>(requestModel);
            var validationResult = orphanage.Validade();

            if (validationResult.IsValid)
            {
                try
                {
                    var entityExists = await _orphanageRepository.EntityExists(orphanage);
                    if (!entityExists)
                    {
                        var creationId = await _orphanageRepository.Create(orphanage);
                        response.Data.Add(new OrphanageResponseModel { Id = creationId });
                    }
                    else
                    {
                        response.Errors.Add($"{orphanage.Name} is already created");
                    }
                }
                catch (Exception)
                {
                    response.Errors.Add("Database error, contact the manager");
                }
            }
            else
            {
                response.SetErrorsList(validationResult.Errors);
            }
            return response;
        }

        public async Task<Response> Delete(int id)
        {
            var response = new Response();
            try
            {
                var entityExists = await _orphanageRepository.EntityExists(id);
                if (entityExists)
                {
                    await _orphanageRepository.Delete(id);
                }
                else
                {
                    response.Errors.Add($"{id} is not a valid orphanage id");
                }
            }
            catch (Exception)
            {
                response.Errors.Add("Database error, contact the manager");
            }
            return response;
        }

        public async Task<DataResponse<OrphanageResponseModel>> GetAll()
        {
            var response = new DataResponse<OrphanageResponseModel>();
            try
            {
                var orphanages = await _orphanageRepository.GetAll();
                response.Data = _mapper.Map<List<OrphanageResponseModel>>(orphanages);
            }
            catch (Exception)
            {
                response.Errors.Add("Database error, contact the manager");
            }
            return response;
        }

        public async Task<DataResponse<OrphanageResponseModel>> GetById(int id)
        {
            var response = new DataResponse<OrphanageResponseModel>();
            try
            {
                var entityExists = await _orphanageRepository.EntityExists(id);
                if (entityExists)
                {
                    var orphanage = await _orphanageRepository.GetById(id);
                    response.Data.Add(_mapper.Map<OrphanageResponseModel>(orphanage));
                }
                else
                {
                    response.Errors.Add($"{id} is not a valid orphanage id");
                }
            }
            catch (Exception)
            {
                response.Errors.Add("Database error, contact the manager");
            }
            return response;
        }

        public async Task<Response> Update(int id, OrphanageRequestModel requestModel)
        {
            var response = new DataResponse<OrphanageResponseModel>();
            var orphanage = _mapper.Map<Orphanage>(requestModel);
            var validationResult = orphanage.Validade();

            try
            {
                var entityExists = await _orphanageRepository.EntityExists(id);

                if (entityExists)
                {
                    var orphanageFromDb = await _orphanageRepository.GetById(id);

                    if (validationResult.IsValid)
                    {
                        orphanageFromDb.Update
                            (
                            orphanage.Name,
                            orphanage.Latitude,
                            orphanage.Longitude
                            );

                        orphanageFromDb.Update
                            (
                            orphanage.About,
                            orphanage.Instructions,
                            orphanage.OpeningHours,
                            orphanage.OpensOnWeekends
                            );

                        await _orphanageRepository.Update(orphanageFromDb);
                    }
                    else
                    {
                        response.SetErrorsList(validationResult.Errors);
                    }
                }
                else
                {
                    response.Errors.Add($"{id} is not a valid orphanage id");
                }
            }
            catch (Exception)
            {
                response.Errors.Add("Database error, contact the manager");
            }
            return response;
        }
    }
}
