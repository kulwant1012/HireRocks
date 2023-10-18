using PS.ActivityManagementStudio.CommonModel;
using GalaSoft.MvvmLight.Command;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class AddDictionaryViewModel : BaseViewModel
    {
        public RelayCommand AddKeywordCommand { get; private set; }
        public RelayCommand AddDictionaryCommand { get; private set; }
        private KeywordDictionaryModel _keywordDictionaryModel { get; set; }

        public KeywordDictionaryModel KeywordDictionaryModel
        {
            get { return _keywordDictionaryModel; }
            set
            {
                _keywordDictionaryModel = value;
                RaisePropertyChanged(() => KeywordDictionaryModel);
            }
        }
    }
}