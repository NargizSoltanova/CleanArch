using MediatR;
using Microsoft.EntityFrameworkCore;
using practice.Application.Common.Interfaces;
using practice.Application.Common.Results;
using practice.Domain.Entities;

namespace practice.Application.Handlers.Products.Commands;

public record DeleteProductCommand(int ProductId) : IRequest<Common.Results.IResult>
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, Common.Results.IResult>
    {
        private readonly IAppDbContext _context;

        public DeleteProductHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Common.Results.IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.ProductId);
            if (product == null) return new Result(false, "NotFound");
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return new Result(true, "Deleted");
        }
    }
}
