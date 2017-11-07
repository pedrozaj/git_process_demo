using A35WPFSample.Comm;
using A35WPFSample.Models;
using A35WPFSample.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using ToastNotifications;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;

namespace A35WPFSample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        //CONSTRUCTOR
        public MainViewModel(EventHandler<PersonModel> samsEvent)
        {
            SetupToastNotifications();
            LoadFakeData();
            FakeSerialPort.GetInstance().errorOccurred += (object sender, ErrorModel model) =>
            {
                String err = model.ErrorDescription;
                int count = model.ErrorCount;
            };

            FakeSerialPort.GetInstance().newInfoObtained += OnNewInfoObtained;

            samsEvent += FakeSerialPort.GetInstance().OnSamIsCoolSoHereHeIs;
        }


        //MEMBERS
        private bool _canSeeGlassButton;
        private bool _isGridEnabled;
        private int _selectedPersonIndex;
        private UserControl _infoUserControl;
        private MyPointlessUserControl _myPointlessUserControl;
        private PersonUserControl _personUserControl;
        private PersonModel _selectedPersonModel;
        private ObservableCollection<PersonModel> _personModelList;
        private Notifier _notifier;


        public bool CanSeeGlassButton
        {
            get { return _canSeeGlassButton; }
            set
            {
                _canSeeGlassButton = value;
                OnPropertyChanged();
            }
        }
        public bool IsGridEnabled
        {
            get { return _isGridEnabled; }
            set
            {
                _isGridEnabled = value;
                OnPropertyChanged();
            }
        }
        public int SelectetPersonIndex
        {
            get { return _selectedPersonIndex; }
            set
            {
                _selectedPersonIndex = value;
                OnPropertyChanged();
            }
        }
        public UserControl InfoUserControl
        {
            get { return _infoUserControl; }
            set
            {
                _infoUserControl = value;
                OnPropertyChanged();
            }
        }
        public PersonModel SelectedPersonModel
        {
            get { return _selectedPersonModel ?? (_selectedPersonModel = new PersonModel("", "", 0)); }
            set
            {
                _selectedPersonModel = value;
                if(_selectedPersonModel != null)
                {
                    InfoUserControl = MyPersonUserControl;
                }
                OnPropertyChanged();
            }
        }
        public ObservableCollection<PersonModel> PersonModelList
        {
            get { return _personModelList ?? (_personModelList = new ObservableCollection<PersonModel>()); }
            set
            {
                _personModelList = value;
                OnPropertyChanged();
            }
        }
        private UserControl MyPointlessUserControl
        {
            get { return _myPointlessUserControl ?? (_myPointlessUserControl = new MyPointlessUserControl()); }
            set { _myPointlessUserControl = (MyPointlessUserControl)value; }
        }
        private UserControl MyPersonUserControl
        {
            get
            {
                if(_personUserControl == null)
                {
                    _personUserControl = new PersonUserControl();
                }
                _personUserControl.DataContext = SelectedPersonModel;

                return _personUserControl;
            }
            set { _personUserControl = (PersonUserControl)value; }
        }


        //LIFE CYCLE OVERRIDES
        public void OnPageLoaded(object sender, object e)
        {
            _notifier?.ShowSuccess("OnPageLoaded");
        }


        //EVENT HANDLING
        private void OnNewInfoObtained(object sender, PlotDataModel model)
        {
           
            //do stuff with plot data
        }
     

        //INTERNAL METHODS
        private void LoadFakeData()
        {
            InfoUserControl = MyPointlessUserControl;
            PersonModel sam = new PersonModel("Sam", "Rosewall", 34);
            ToyModel basketball = new ToyModel("Basketball");
            sam.FavToysList.Add(new ToyModel("GI Joes"));
            sam.FavToysList.Add(new ToyModel("Knives"));
            sam.FavToysList.Add(basketball);
            sam.SelectedFavToy = basketball;

            PersonModel jim = new PersonModel("Jim", "Carrey", 52);

            PersonModel mila = new PersonModel("Mila", "Kunis", 34);
            mila.FavToysList.Add(new ToyModel("Sam"));
            mila.FavToysList.Add(new ToyModel("Still Sam"));
            mila.FavToysList.Add(new ToyModel("Yup, Just Sam, that is all"));
            mila.FavToysList.Add(new ToyModel("Ok, fine, maybe also Pictures of Sam"));

            PersonModelList.Add(sam);
            PersonModelList.Add(jim);
            PersonModelList.Add(mila);
        }
        private void SetupToastNotifications()
        {
            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(
                    parentWindow: Application.Current.MainWindow,
                    corner: Corner.BottomCenter,
                    offsetX: 10,
                    offsetY: 10);

                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
                    notificationLifetime: TimeSpan.FromSeconds(2),
                    maximumNotificationCount: MaximumNotificationCount.FromCount(5));

                cfg.Dispatcher = Application.Current.Dispatcher;
            });
        }


        //EXTERNAL METHODS
        public bool IsSamCool()
        {
            return true;
        }
    }
}
