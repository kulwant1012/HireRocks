using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    public class UserWindowMessage
    {
        public UserWindowMessage(UserViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public UserWindowMessage()
        {
        }

        public UserViewModel ViewModel { get; set; }
    }

    public struct CloseUserWindowMessage
    {
    }
}