using Newtonsoft.Json;
using System;

namespace Client.Models
{
    class User : Property
    {
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }

        public string Firstname
        {
            get => _firstname;
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        public string Middlename
        {
            get => _middlename;
            set
            {
                _middlename = value;
                OnPropertyChanged(nameof(Middlename));
            }
        }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                _birthday = value;
                OnPropertyChanged(nameof(Birthday));
            }
        }

        public Genders Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }


        [JsonProperty("have_childrens")]
        public bool HaveChildrens
        {
            get => _haveChildrens;
            set
            {
                _haveChildrens = value;
                OnPropertyChanged(nameof(HaveChildrens));
            }
        }


        private int _id;
        private string _surname;
        private string _firstname;
        private string _middlename;
        private DateTime _birthday;
        private Genders _gender;
        private bool _haveChildrens;
    }
}
