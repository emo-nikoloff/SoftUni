using CinemaApp.Services.Core.Data.Enums;

namespace CinemaApp.Services.Core.Data.Movie.Response;

public class MovieServiceStatusResponseModel
{
    public MovieServiceResponseStatus Status { get; set; }

    public IEnumerable<string?> ErrorMessages { get; set; } = new List<string?>();
}
