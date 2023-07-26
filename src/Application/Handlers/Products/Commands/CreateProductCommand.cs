using AutoMapper;
using MediatR;
using practice.Application.Common.Interfaces;
using practice.Application.Common.Results;
using practice.Domain.Entities;

namespace practice.Application.Handlers.Products.Commands;

public record CreateProductCommand() : IRequest<IDataResult<CreateProductCommand>>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public bool IsDeleted { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? ModifiedBy { get; set; }

    public class CreateProductHandler : IRequestHandler<CreateProductCommand, IDataResult<CreateProductCommand>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public CreateProductHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IDataResult<CreateProductCommand>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<CreateProductCommand>(request, "Added");
        }
    }
}