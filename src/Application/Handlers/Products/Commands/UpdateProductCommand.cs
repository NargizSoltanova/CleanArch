using MediatR;
using Microsoft.EntityFrameworkCore;
using practice.Application.Common.Interfaces;
using practice.Application.Common.Results;
using practice.Domain.Entities;

namespace practice.Application.Handlers.Products.Commands;

public record UpdateProductCommand(int Id) : IRequest<IDataResult<UpdateProductCommand>>
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Count { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string? ModifiedBy { get; set; }
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, IDataResult<UpdateProductCommand>>
    {
        private readonly IAppDbContext _context;

        public UpdateProductHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<IDataResult<UpdateProductCommand>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product exists = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (exists == null) return new ErrorDataResult<UpdateProductCommand>("NotFound");
            exists.Name = request.Name;
            exists.Price = request.Price;
            exists.Count = request.Count;
            exists.IsDeleted = request.IsDeleted;
            exists.ModifiedDate = request.ModifiedDate;
            exists.ModifiedBy = request.ModifiedBy;
            _context.Products.Update(exists);
            await _context.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<UpdateProductCommand>(request, "Updated");
        }
    }
}
