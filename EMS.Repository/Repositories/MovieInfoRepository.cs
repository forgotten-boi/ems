using EMS.DataAccess;
using EMS.Entity.Entities;
using EMS.Repository.Irepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Repository.Repositories
{
    public class MovieInfoRepository : Repository<MovieInfo, int>, IMovieInfoRepository
    {
        public MovieInfoRepository(ProjectDbContext context, UserContext userContext) : base(context, userContext)
        {

        }
    }

    public interface IMovieInfoRepository : IRepository<MovieInfo, int>
    {

    }
}
