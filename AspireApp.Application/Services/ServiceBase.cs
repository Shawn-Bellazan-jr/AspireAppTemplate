using AspireApp.Core.Abstracts;
using AspireApp.Core.Interfaces;
using AspireApp.Infrastructure.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace AspireApp.Application.Services
{
    public class ServiceBase<TDto, TEntity> : IService<TDto, TEntity>
        where TEntity : EntityBase
        where TDto : class
    {
        private readonly IUnitOfWork<TEntity> _unitOfWork;
        private readonly IMapper _mapper;

        public ServiceBase(IUnitOfWork<TEntity> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.Repositories.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);  // Map entities to DTOs
        }

        public async Task<TDto?> GetByIdAsync(string id)
        {
            var entity = await _unitOfWork.Repositories.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);  // Map entity to DTO
        }

        public async Task AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);  // Map DTO to entity
            await _unitOfWork.Repositories.AddAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(string id, TDto dto)
        {


            var entity = _mapper.Map<TEntity>(dto);

            entity.Id = id;

            await _unitOfWork.Repositories.UpdateAsync(entity);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(string id)
        {
            await _unitOfWork.Repositories.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<bool> Exist(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);  // Map DTO to entity
            return await _unitOfWork.Repositories.Exist(entity);
        }

    }
}
