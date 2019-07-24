using EMS.DataAccess;
using EMS.Entity.DtoModel;
using EMS.Entity.Entities;
using EMS.Repository;
using EMS.Repository.Irepositories;
using EMS.Repository.Repositories;
using EMS.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Services.Repositories
{
    public class EmployeeService : ApplicationService<EmployeeInfo, int>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {

        }
    }
    public class ProducerDetailService : ApplicationService<ProducerDetail, int>, IProducerDetailService
    {
        public ProducerDetailService(IProducerDetailRepository producerDetailRepository) : base(producerDetailRepository)
        {

        }
    }
    public class ExhibitorsDetailService : ApplicationService<ExhibitorsDetail, int>, IExhibitorsDetailService
    {
        public ExhibitorsDetailService(IExhibitorsDetailRepository exhibitorDetailRepository) : base(exhibitorDetailRepository)
        {

        }
    }
    public class DistributersDetailService : ApplicationService<DistributersDetail, int>, IDistributersDetailService
    {
        public DistributersDetailService(IDistributersDetailRepository distributersDetailService) : base(distributersDetailService)
        {

        }
    }
    public class ArtistInfoService : ApplicationService<ArtistInfo, int>, IArtistInfoService
    {
        public ArtistInfoService(IArtistInfoRepository artistInfoRepository) : base(artistInfoRepository)
        {

        }
    }
    public class MovieInfoService : ApplicationService<MovieInfo, int>, IMovieInfoService
    {
        public MovieInfoService(IMovieInfoRepository moviesInfoRepository) : base(moviesInfoRepository)
        {

        }
    }
    public class ApprovalInfoService : ApplicationService<ApprovalInfo, int>, IApprovalInfoService
    {
        public ApprovalInfoService(IApprovalInfoRepository approvalsInfoRepository) : base(approvalsInfoRepository)
        {

        }
    }
    public class BannerInfoService : ApplicationService<BannerInfo, int>, IBannerInfoService
    {
        public BannerInfoService(IBannerRepository bannerInfoRepository) : base(bannerInfoRepository)
        {

        }
    }

}
