using System.Collections.ObjectModel;

namespace PS.ActivityManagementStudio.CommonModel
{
    public class KeywordDictionaryModel
    {
        public KeywordDictionaryModel()
        {
            keywordList = new ObservableCollection<string>();
        }

        public string Id { get; set; }
        //public string Keyword { get; set; }
        public ObservableCollection<string> keywordList { get; set; }
        public string DictionaryName { get; set; }
    }
}