using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HelloWorld.Models
{
    public class Contact :INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _fullName;
        
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set 
            {
                if (_fullName == value)
                    return;
                _fullName = value;
                OnPropertyChanged();
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        [MaxLength(100)]
        public string Phone { get; set; }

        [MaxLength(255)]
        public string Address { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        public bool Blocked { get; set; }

        public string ImageUrl { get; set; }

        [MaxLength(20)]
        public string ContactGroup { get; set; }

        
    }
}
