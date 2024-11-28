using System;
using AuctionService.DTOs;
using AuctionService.Entities;
using AutoMapper;
using Contracts;

namespace AuctionService.RequestHelpers;

public class MappingProfiles: Profile
{
    public MappingProfiles()
    {
        CreateMap<Auction, AuctionDto>().IncludeMembers(a => a.Item);
        CreateMap<Item, AuctionDto>();
        CreateMap<CreateAuctionDto, Auction>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src));
        CreateMap<CreateAuctionDto, Item>();
        CreateMap<AuctionDto, AuctionCreated>();

        // CreateMap<Auction, AuctionUpdated>().IncludeMembers(a => a.Item);
        CreateMap<Auction, AuctionUpdated>()
            .ForMember(dest => dest.Id , opt => opt.MapFrom(src => src.Id.ToString()))
            .ForMember(dest => dest.Make , opt => opt.MapFrom(src => src.Item.Make))
            .ForMember(dest => dest.Model , opt => opt.MapFrom(src => src.Item.Model))
            .ForMember(dest => dest.Year , opt => opt.MapFrom(src => src.Item.Year))
            .ForMember(dest => dest.Color , opt => opt.MapFrom(src => src.Item.Color))
            .ForMember(dest => dest.Mileage , opt => opt.MapFrom(src => src.Item.Mileage));

        CreateMap<Auction, AuctionDeleted>()
            .ForMember(dest => dest.Id , opt => opt.MapFrom(src => src.Id.ToString()));
    }
}
