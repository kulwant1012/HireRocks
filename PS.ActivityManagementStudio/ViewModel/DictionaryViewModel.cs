using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PS.ActivityManagementStudio.CommonModel;
using PS.ActivityManagementStudio.Helpers;
using PS.ActivityManagementStudio.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PS.ActivityManagementStudio.PSServiceReference;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class DictionaryViewModel : BaseViewModel
    {
        public DictionaryViewModel()
        {
            AddKeywordCommand = new RelayCommand(AddKeywordCommandExecute);
            AddUpdateDictionaryCommand = new RelayCommand(AddUpdateDictionaryCommandExecute);
            OpenAddDictionaryCommand = new RelayCommand(OpenAddDictionaryCommandExecute);
            UpdateKeywordCommand = new RelayCommand(UpdateKeywordCommandExecute);
            OpenUpdateDictionaryCommand = new RelayCommand<KeywordDictionaryModel>(OpenUpdateDictionaryCommandExecute);

            KeywordDictionaryModel = new KeywordDictionaryModel();
            GetDictionaries();
        }

        public RelayCommand OpenAddDictionaryCommand { get; set; }
        public RelayCommand<KeywordDictionaryModel> OpenUpdateDictionaryCommand { get; set; }

        public RelayCommand AddKeywordCommand { get; private set; }
        public RelayCommand AddDictionaryCommand { get; private set; }

        public RelayCommand UpdateKeywordCommand { get; private set; }
        public RelayCommand AddUpdateDictionaryCommand { get; private set; }

        private ObservableCollection<KeywordDictionaryModel> _keywordDictionaryList { get; set; }

        public ObservableCollection<KeywordDictionaryModel> KeywordDictionaryList
        {
            get { return _keywordDictionaryList; }
            set
            {
                _keywordDictionaryList = value;
                RaisePropertyChanged(() => KeywordDictionaryList);
            }
        }

        private ObservableCollection<string> _tempKeywordList { get; set; }

        public ObservableCollection<string> TempKeywordList
        {
            get { return _tempKeywordList; }
            set
            {
                _tempKeywordList = value;
                RaisePropertyChanged(() => TempKeywordList);
            }
        }

        private string _selectedTiles { get; set; }

        public string SelectedTiles
        {
            get { return _selectedTiles; }
            set
            {
                if (_selectedTiles != value)
                {
                    _selectedTiles = value;
                    RaisePropertyChanged(() => SelectedTiles);
                }
            }
        }

        private string _keyword { get; set; }

        public string Keyword
        {
            get { return _keyword; }
            set
            {
                if (_keyword != value)
                {
                    _keyword = value;
                    RaisePropertyChanged(() => Keyword);
                }
            }
        }


        private int _keywordIndex { get; set; }

        public int KeywordIndex
        {
            get { return _keywordIndex; }
            set
            {
                if (_keywordIndex != value)
                {
                    _keywordIndex = value;
                    RaisePropertyChanged(() => KeywordIndex);
                }
            }
        }

        private string _windowTitle { get; set; }

        public string WindowTitle
        {
            get { return _windowTitle; }
            set
            {
                if (_windowTitle != value)
                {
                    _windowTitle = value;
                    RaisePropertyChanged(() => WindowTitle);
                }
            }
        }

        private string _buttonText { get; set; }

        public string ButtonText
        {
            get { return _buttonText; }
            set
            {
                if (_buttonText != value)
                {
                    _buttonText = value;
                    RaisePropertyChanged(() => ButtonText);
                }
            }
        }

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

        private void OpenAddDictionaryCommandExecute()
        {
            KeywordDictionaryModel = new KeywordDictionaryModel();
            Message = string.Empty;
            Messenger.Default.Send(new AddDictionaryWindowMessage());
        }

        private void OpenUpdateDictionaryCommandExecute(KeywordDictionaryModel keywordDictionaryModel)
        {
            KeywordDictionaryModel = keywordDictionaryModel;
            Message = string.Empty;
            //TempKeywordList = KeywordDictionaryModel.keywordList;
            Messenger.Default.Send(new UpdateDictionaryWindowMessage());
        }

        private void AddKeywordCommandExecute()
        {
            try
            {
                if (!string.IsNullOrEmpty(Keyword))
                {
                    try
                    {
                        KeywordDictionaryModel.keywordList.Add(Keyword);
                        Keyword = string.Empty;
                        Message = string.Empty;
                        RaisePropertyChanged(() => Keyword);
                        RaisePropertyChanged(() => KeywordDictionaryModel.DictionaryName);
                    }
                    catch (Exception ex)
                    {
                        Message = ex.ToString();
                    }
                }

                else
                {
                    Message = "Keyword Required";
                }
            }
            catch (Exception ex)
            {
                Message = ex.ToString();
            }
        }

        private void UpdateKeywordCommandExecute()
        {
            try
            {
                if (KeywordIndex > -1)
                {
                    KeywordDictionaryModel.keywordList[KeywordIndex] = Keyword;
                }
                else
                {
                    if (!string.IsNullOrEmpty(Keyword))
                        KeywordDictionaryModel.keywordList.Add(Keyword);
                }
            }
            catch (Exception ex)
            {
                Message = "Please select the keyword";
            }
        }

        private void AddUpdateDictionaryCommandExecute()
        {
            try
            {
                var keywordDictionary = new KeywordDictionary();
                keywordDictionary.Id = KeywordDictionaryModel.Id;
                keywordDictionary.DictionaryName = KeywordDictionaryModel.DictionaryName;
                keywordDictionary.Keywords = KeywordDictionaryModel.keywordList.ToArray();
                RemoteCaller.Call(
                    () => ActivityOptimizationSystemServiceClient.AddOrUpdateKeywordDictionary(keywordDictionary),
                    (response, exception) =>
                    {
                        if (!response.IsErrorReturned)
                        {
                            KeywordDictionaryModel = new KeywordDictionaryModel();
                            KeywordDictionaryModel.DictionaryName = response.Value.DictionaryName;
                            KeywordDictionaryModel.Id = response.Value.Id;
                            KeywordDictionaryModel.keywordList =
                                new ObservableCollection<string>(response.Value.Keywords);
                            RaisePropertyChanged(() => KeywordDictionaryModel.keywordList);
                            RaisePropertyChanged(() => KeywordDictionaryModel);
                            KeywordIndex = -1;

                            if (keywordDictionary.Id != null)
                            {
                                Message = "Dictionary has been updated";
                            }
                            else
                            {
                                KeywordDictionaryList.Add(KeywordDictionaryModel);
                                Message = "Dictionary has been Created";
                            }
                        }
                    });
            }
            catch (Exception ex)
            {
                Message = ex.ToString();
            }
        }

        private void GetDictionaries()
        {
            RemoteCaller.Call(() => ActivityOptimizationSystemServiceClient.GetKeywordDictionaries(),
                (response, exception) =>
                {
                    if (!response.IsErrorReturned)
                    {
                        IEnumerable<KeywordDictionaryModel> dictionary = from qspace in response.Value
                            select new KeywordDictionaryModel
                            {
                                Id = qspace.Id,
                                DictionaryName = qspace.DictionaryName,
                                keywordList = new ObservableCollection<string>(qspace.Keywords)
                            };
                        KeywordDictionaryList = new ObservableCollection<KeywordDictionaryModel>(dictionary);
                    }
                });
        }
    }
}