using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;
using SearchService.Models;

namespace SearchService.Consumers;

public class AuctionUpdatedConsumer : IConsumer<AuctionUpdated>
{
    private readonly IMapper _mapper;

    public AuctionUpdatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    public async Task Consume(ConsumeContext<AuctionUpdated> context)
    {
        Console.WriteLine("--> Consuming auction updated: " + context.Message.Id);
        /*await DB.Update<Item>()
            .Match(a => a.ID == context.Message.Id)
            .Modify(x => x.Set(a => a.UpdatedAt, DateTime.UtcNow))
            .Modify(x => x.Set(a => a.Make, context.Message.Make))
            .Modify(x => x.Set(m => m.Model, context.Message.Model))
            .Modify(x => x.Set(y => y.Year, context.Message.Year))
            .Modify(x => x.Set(c => c.Color, context.Message.Color))
            .Modify(x => x.Set(mil => mil.Mileage, context.Message.Mileage))
            .ExecuteAsync();*/
        var item = _mapper.Map<Item>(context.Message);
        var result = await DB.Update<Item>()
            .Match(a => a.ID == context.Message.Id)
            .ModifyOnly(x => new
            {
                x.UpdatedAt,
                x.Make,
                x.Model,
                x.Year,
                x.Color,
                x.Mileage
            }, item)
            .ExecuteAsync();
        
        if (!result.IsAcknowledged)
            throw new MessageException(typeof(AuctionUpdated), "Problem updating mongoDB");
    }
}
