using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.ObjectModel;

namespace UniModel
{
    /// <summary>
    /// A collection of students. Particular benefits of ObservableCollection (instead of, e.g., List)  
    /// include an automated refresh of bound components after changes in the collection. In this exercise,
    /// such a change is triggered by means of a button.
    /// </summary>
    public class UniList : ObservableCollection<Uni>
    {
        public UniList()
        {
        }
    }

    public class Uni : ObservableObject
    {
        protected String _Name;
        public String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }
        protected String _Location;
        public String Location
        {
            get
            {
                return _Location;
            }
            set
            {
                _Location = value;
                OnPropertyChanged();
            }
        }
        public Uni(String name, String location)
        {
            _Name = name;
            _Location = location;
        }

        /*
        /// <summary>
        /// Qualify for INotifyPropertyChanged by implementing the event defined by the interface.
        /// Name of event (PropertyChanged) and the associated delegate (PropertyChangedEventHandler)
        /// are defined by the interface, and have to be adopted.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// Translates informations concerning a property values' change into an event.
        /// </summary>
        /// <param name="propertyName">A string describing the name of the property that has changed.</param>
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        */
    }
}