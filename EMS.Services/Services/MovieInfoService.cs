using EMS.Repository;

namespace EMS.Services.Services
{
    public class MovieInfoService : ApplicationService<MovieInfo, int>, IMovieInfoService
    {
        public MovieInfoService(IMovieInfoRepository moviesInfoRepository) : base(moviesInfoRepository)
        {

        }
    }
}