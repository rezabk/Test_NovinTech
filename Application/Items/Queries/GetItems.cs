using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Shared.Items;
using Test_NovinTech;
using Mapper = Shared.Mapepr.Mapper;

public record GetItemsQuery : IRequest<List<ItemDTO>>;

public class GetItemsQueryHandler
    : IRequestHandler<GetItemsQuery, List<ItemDTO>>
{
    private readonly Db1Context _context;
    private readonly Mapper _mapper;

    public GetItemsQueryHandler(Db1Context context, Mapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<ItemDTO>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.Items.ToListAsync();

        var showItems = new List<ItemDTO>();
        foreach (var item in items)
        {
            showItems.Add(await _mapper.MapAsync(item, new ItemDTO()));
        }

        return showItems;

    }
}