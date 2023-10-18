using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    public class AddDictionaryWindowMessage
    {
        public AddDictionaryWindowMessage(AddDictionaryViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public AddDictionaryWindowMessage()
        {
        }

        public AddDictionaryViewModel ViewModel { get; set; }
    }
}