using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    public class UpdateDictionaryWindowMessage
    {
        public UpdateDictionaryWindowMessage(AddDictionaryViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public UpdateDictionaryWindowMessage()
        {
        }

        public AddDictionaryViewModel ViewModel { get; set; }
    }
}