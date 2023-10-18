using PS.ActivityVerification.PSServiceReference;
using Hardcodet.Wpf.TaskbarNotification;

namespace PS.ActivityVerification.ViewModel
{
    public static class Session
    {
        public static User User { get; set; }

        public static string QSpaceId { get; set; }

        public static TaskbarIcon taskbarIcon { get; set; }
    }
}