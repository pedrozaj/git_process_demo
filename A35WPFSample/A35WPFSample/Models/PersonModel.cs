using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A35WPFSample.Models
{
    public class PersonModel : BaseModel
    {
        //CONSTRUCTOR
        public PersonModel(String fName, String lName, int age)
        {
            _firstName = fName;
            _lastName = lName;
            _age = age;
        }


        //MEMBERS
        private String _firstName;
        private String _lastName;
        private int _age;
        private ObservableCollection<ToyModel> _favToysList;
        private ToyModel _selectedFavToy;


        //PROPERTIES
        public String FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public String LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<ToyModel> FavToysList
        {
            get { return _favToysList ?? (_favToysList = new ObservableCollection<ToyModel>()); }
            set
            {
                _favToysList = value;
                OnPropertyChanged();
            }
        }
        public ToyModel SelectedFavToy
        {
            get { return _selectedFavToy ?? (_selectedFavToy = new ToyModel("n/a")); }
            set
            {
                _selectedFavToy = value;
                OnPropertyChanged();
            }
        }
    }
}
