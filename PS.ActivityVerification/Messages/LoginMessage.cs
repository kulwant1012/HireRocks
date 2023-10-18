using PS.ActivityVerification.ViewModel;

namespace PS.ActivityVerification.Messages
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