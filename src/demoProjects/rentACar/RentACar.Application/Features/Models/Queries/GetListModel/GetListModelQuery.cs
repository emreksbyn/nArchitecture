using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RentACar.Application.Features.Models.Models;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;

namespace RentACar.Application.Features.Models.Queries.GetListModel
{
    public class GetListModelQuery : IRequest<ModelListViewModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, ModelListViewModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                this._modelRepository = modelRepository;
                this._mapper = mapper;
            }
            public async Task<ModelListViewModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                            // Car Models
               IPaginate<Model> models =  await _modelRepository.GetListAsync(
                                                   include: m => m.Include(b => b.Brand),
                                                   index: request.PageRequest.Page,
                                                   size: request.PageRequest.PageSize
                                                   );
                            // data models
                ModelListViewModel mappedModel = _mapper.Map<ModelListViewModel>(models);
                return mappedModel;
            }
        }
    }
}