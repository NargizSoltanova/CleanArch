using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using practice.Application.Common.Interfaces;
using practice.Application.Common.Results;

namespace practice.Application.Handlers.Products.Queries;

public class GetProductsQuery : IRequest<IDataResult<IEnumerable<GetProductsQuery>>>
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IDataResult<IEnumerable<GetProductsQuery>>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<IEnumerable<GetProductsQuery>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return new SuccessDataResult<IEnumerable<GetProductsQuery>>(
                _mapper.Map<IEnumerable<GetProductsQuery>>(await _context.Products.ToListAsync()));
        }
    }
}
