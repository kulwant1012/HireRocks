using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    public class LoginMessage
    {
        public LoginMessage(LoginViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public LoginMessage()
        {
        }

        public LoginViewModel ViewModel { get; set; }
    }

    public struct CloseLoginWindow
    {
    }
}