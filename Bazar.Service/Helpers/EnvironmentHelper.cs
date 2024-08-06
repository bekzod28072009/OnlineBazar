namespace Bazar.Service.Helpers
{
    public static class EnvironmentHelper
    {
        public static string WebRootPath { get; set; }
        public static string AttachmentPath => Path.Combine(WebRootPath, "Attachment");
        public static string FilePath => Path.Combine(WebRootPath, "Images");
    }
}
