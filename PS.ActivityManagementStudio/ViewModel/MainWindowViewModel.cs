using System;
using System.Collections.ObjectModel;
using System.Linq;
using PS.ActivityManagementStudio.Messages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Telerik.Windows.Controls;
using PS.ActivityManagementStudio.PSServiceReference;

namespace PS.ActivityManagementStudio.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        public MainWindowViewModel()
        {
            LogoutCommand = new RelayCommand(LogoutCommandExecuted);
            GetViewData();
        }

        public RelayCommand LogoutCommand { get; set; }

        private ObservableCollection<MenuItem> _menuItemsList { get; set; }

        public ObservableCollection<MenuItem> MenuItemsList
        {
            get { return _menuItemsList; }
            set
            {
                _menuItemsList = value;
                RaisePropertyChanged(() => MenuItemsList);
            }
        }

        private string _selectedMenuItem { get; set; }

        public string SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set
            {
                if (_selectedMenuItem != value)
                {
                    _selectedMenuItem = value;
                    RaisePropertyChanged(() => SelectedMenuItem);
                }
            }
        }

        private string _selectedQSpace { get; set; }

        public string SelectedQSpace
        {
            get { return _selectedQSpace; }
            set
            {
                if (_selectedQSpace != value)
                {
                    _selectedQSpace = value;
                    RaisePropertyChanged(() => SelectedQSpace);
                    try
                    {
                        switch (SelectedQSpace)
                        {
                            case "QSpaces":
                                Messenger.Default.Send(new QSpaceWindowMessage());
                                break;

                            case "Activitivities":
                                Messenger.Default.Send(new ActivityWindowMessage());
                                break;

                            case "VerifyActivity":
                                Messenger.Default.Send(new ActivityVerificationWindowMessage());
                                break;

                            case "Users":
                                Messenger.Default.Send(new UserWindowMessage());
                                break;

                            case "Dictionary":
                                Messenger.Default.Send(new DictionaryWindowMessage());
                                break;

                            case "ActivityTools":
                                Messenger.Default.Send(new ActivityToolWindowMessage());
                                break;

                            case "Reports":
                                Messenger.Default.Send(new ReportsWindowMessage());
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                    }
                }
            }
        }

        private string _userName { get; set; }

        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    RaisePropertyChanged(() => UserName);
                }
            }
        }

        private void GetViewData()
        {
            UserName = ApplicationSession.User.Login;
            MenuItemsList = new ObservableCollection<MenuItem>();
            MenuItemsList.Add(new MenuItem
            {
                MenuItemId = "Activitivities",
                MenuItemName = "Activities",
                MenuItemBackGround = "#FFFFFF",
                TileType = TileType.Double
            });
            MenuItemsList.Add(new MenuItem
            {
                MenuItemId = "Reports",
                MenuItemName = "Reports",
                MenuItemBackGround = "#FFFFFF",
                TileType = TileType.Double
            });
            MenuItemsList.Add(new MenuItem
            {
                MenuItemId = "VerifyActivity",
                MenuItemName = "Verify Activity",
                MenuItemBackGround = "#FFFFFF",
                TileType = TileType.Double
            });

            if (ApplicationSession.User.Roles.Contains(UserRole.Manager))
            {
                MenuItemsList.Add(new MenuItem
                {
                    MenuItemId = "Users",
                    MenuItemName = "Users",
                    MenuItemBackGround = "#FFFFFF",
                    TileType = TileType.Double
                });
                MenuItemsList.Add(new MenuItem
                {
                    MenuItemId = "QSpaces",
                    MenuItemName = "QSpaces",
                    MenuItemBackGround = "#FFFFFF",
                    TileType = TileType.Double
                });
                MenuItemsList.Add(new MenuItem
                {
                    MenuItemId = "ActivityTools",
                    MenuItemName = "Activity Tools",
                    MenuItemBackGround = "#FFFFFF",
                    TileType = TileType.Double
                });
                MenuItemsList.Add(new MenuItem
                {
                    MenuItemId = "Dictionary",
                    MenuItemName = "Dictionaries",
                    MenuItemBackGround = "#FFFFFF",
                    TileType = TileType.Single
                });
            }
        }

        private void LogoutCommandExecuted()
        {
            ApplicationSession.User = null;
            Messenger.Default.Send(new LoginMessage());
            Messenger.Default.Send(new CloseMainWindowMessage());
        }
    }

    public class MenuItem
    {
        public string MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemBackGround { get; set; }
        public TileType TileType { get; set; }
    }
}