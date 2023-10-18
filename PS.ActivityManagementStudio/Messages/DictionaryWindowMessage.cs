using PS.ActivityManagementStudio.ViewModel;

namespace PS.ActivityManagementStudio.Messages
{
    public class DictionaryWindowMessage
    {
        public DictionaryWindowMessage(DictionaryViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        public DictionaryWindowMessage()
        {
        }

        public DictionaryViewModel ViewModel { get; set; }
    }
}