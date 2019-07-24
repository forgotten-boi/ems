using AutoMapper;
using EMS.Entity.DtoModel;
using EMS.Entity.Entities;

namespace EMS.Website
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
          
            CreateMap<DistributersDetail, DistributerDto>().ForMember(x => x.DistributerId, opts => opts.MapFrom(x => x.ID))
                .ForMember(y=> y.RegDoc, z=>z.Ignore())
                .ForMember(y=> y.CompanyRegDoc, z=>z.Ignore())
                .ForMember(y=> y.DistributionRightDoc, z=>z.Ignore())
                .ForMember(y=> y.IncomeTaxDoc, z=>z.Ignore())
                .ReverseMap(); 
            CreateMap<ExhibitorsDetail, ExhibitorDto>().ForMember(x => x.ExhibitorId, opts => opts.MapFrom(x => x.ID))
                .ForMember(y => y.RegDoc, z => z.Ignore())
                .ForMember(y => y.HallPermissionDoc, z => z.Ignore())
                .ForMember(y => y.CompanyRegDoc, z => z.Ignore())
                .ForMember(y => y.CheckcommitteeDoc, z => z.Ignore())
                .ForMember(y => y.ExhibPermissionDoc, z => z.Ignore())
                .ForMember(y => y.IncomeTaxDoc, z => z.Ignore())
                .ForMember(y => y.LocalBodyDoc, z => z.Ignore())
                .ReverseMap();
            CreateMap<BannerInfo, BannerDto>().ForMember(x => x.BannerId, opts => opts.MapFrom(x => x.ID))
                .ForMember(y => y.FormRegDoc, z => z.Ignore())
                .ForMember(y => y.TaxRegDoc, z => z.Ignore())
                .ReverseMap();

            CreateMap<MovieInfo, MovieDto>().ForMember(x => x.MovieId, opts => opts.MapFrom(x => x.ID))
                .ForMember(y => y.RegDoc, z => z.Ignore())
                .ForMember(y => y.ContractDoc, z => z.Ignore())
                .ForMember(y => y.PermissionDoc, z => z.Ignore())
                .ForMember(y => y.PostProdDoc, z => z.Ignore())
                .ForMember(y => y.ScriptDoc, z => z.Ignore())
                .ForMember(y => y.SensorDoc, z => z.Ignore())
                .ForMember(y => y.SongDoc, z => z.Ignore())
                .ForMember(y => y.MovieBannerDoc, z => z.Ignore())
                .ReverseMap();



            CreateMap<EmployeeInfo, EmployeeDto>().ForMember(x => x.EmployeeId, opts => opts.MapFrom(x => x.ID)).ReverseMap();

            CreateMap<TravelInfo, TravelDto>().ForMember(x => x.TravelId, opts => opts.MapFrom(x => x.ID))
                .ForMember(y => y.RecieptDoc, z => z.Ignore())
                .ReverseMap();
            CreateMap<TravelExpenses, TravelExpenseDto>().ForMember(x => x.TravelExpId, opts => opts.MapFrom(x => x.ID))
                .ReverseMap();
           
            CreateMap<ApprovalInfo, ApprovalDto>().ForMember(x => x.ApprovalId, opts => opts.MapFrom(x => x.ID))
                .ReverseMap();
            CreateMap<MiscExpenses, MiscExpenseDto>().ForMember(x => x.MiscExpId, opts => opts.MapFrom(x => x.ID))
                .ReverseMap();
            CreateMap<EntertainmentFB, EntertainmentFBDto>().ForMember(x => x.EntertainmentFBId, opts => opts.MapFrom(x => x.ID))
                .ReverseMap();

            CreateMap<MstExpenses, MstExpenseDto>().ForMember(x => x.MstExpId, opts => opts.MapFrom(x => x.ID))
                .ReverseMap();
            //CreateMap(typeof(QueryResult<>), typeof(QueryResultResource<>));

        }

      
    }
}
