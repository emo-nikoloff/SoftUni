using CinemaApp.Data.Models;
using CinemaApp.Data.Repository.Contracts.Common;

namespace CinemaApp.Data.Repository.Contracts;

public interface ICinemaMovieRepository : ISoftDeletableRepository<CinemaMovie>
{

}
