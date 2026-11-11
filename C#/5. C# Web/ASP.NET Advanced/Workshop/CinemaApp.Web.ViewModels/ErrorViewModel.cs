namespace CinemaApp.Web.ViewModels
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public string Icon { get; set; } = string.Empty;

        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
