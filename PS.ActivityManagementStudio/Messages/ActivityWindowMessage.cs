using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    internal class ActivityWindowMessage
    {
        public ActivityWindowMessage(ActivityViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public ActivityWindowMessage()
        {
        }

        public ActivityViewModel ViewModel { get; set; }
    }

    public struct CloseActivityWindow
    {
    }
}