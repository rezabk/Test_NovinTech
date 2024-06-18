
using Domain.Entities;
using FluentValidation;
using MediatR;
using Shared.Items;
using Test_NovinTech;

public record CreateItemCommand(CreateItemRequest item) : IRequest<int>;

public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
{
    private readonly Db1Context _context;


    public CreateItemCommandValidator(Db1Context context)
    {
        _context = context;
    }

    public class CreateItemCommandHandler
        : IRequestHandler<CreateItemCommand, int>
    {
        private readonly Db1Context _context;

        public CreateItemCommandHandler(Db1Context context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var entity = new Item()
            {
                Name = request.item.Name,
                Quantity = request.item.Quantity,
            };

            _context.Items.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }


}