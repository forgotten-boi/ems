using EMS.DataAccess;
using EMS.Entity.Entities;
using EMS.Repository.Irepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Repository.Repositories
{
    public class ProducerDetailRepository : Repository<ProducerDetail, int>, IProducerDetailRepository
    {
        public ProducerDetailRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IProducerDetailRepository : IRepository<ProducerDetail, int>
    {

    }

    public class ExhibitorsDetailRepository : Repository<ExhibitorsDetail, int>, IExhibitorsDetailRepository
    {
        public ExhibitorsDetailRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IExhibitorsDetailRepository : IRepository<ExhibitorsDetail, int>
    {

    }

    public class DistributersDetailRepository : Repository<DistributersDetail, int>, IDistributersDetailRepository
    {
        public DistributersDetailRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IDistributersDetailRepository : IRepository<DistributersDetail, int>
    {

    }

    public class ArtistInfoRepository : Repository<ArtistInfo, int>, IArtistInfoRepository
    {
        public ArtistInfoRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IArtistInfoRepository : IRepository<ArtistInfo, int>
    {

    }

    public class MovieInfoRepository : Repository<MovieInfo, int>, IMovieInfoRepository
    {
        public MovieInfoRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IMovieInfoRepository : IRepository<MovieInfo, int>
    {

    }

    public class ApprovalInfoRepository : Repository<ApprovalInfo, int>, IApprovalInfoRepository
    {
        public ApprovalInfoRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IApprovalInfoRepository : IRepository<ApprovalInfo, int>
    {

    }

    public class BannerRepository : Repository<BannerInfo, int>, IBannerRepository
    {
        public BannerRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IBannerRepository : IRepository<BannerInfo, int>
    {

    }
}
