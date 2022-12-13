using System.ComponentModel;

namespace WpfDataTemplate
{
    /// <summary>
    /// A simple representation of a student's properties.
    /// 
    /// Implements INotifyPropertyChanged in order to communicate changes of a single student's
    /// properties (to be distinguished from changes to the student collection).
    /// </summary>
    public class Student : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor for a new instance of class Student.
        /// </summary>
        /// <param name="matriculation">Matriculation number</param>
        /// <param name="name">Full name</param>
        /// <param name="age">Age</param>
        /// <param name="study">Study</param>
        public Student(int matriculation, string name, int age, string study)
        {
            this.Matriculation = matriculation;
            this.Name = name;
            this.Age = age;
            this.Study = study;
        }

        /// <summary>
        /// Qualify for INotifyPropertyChanged by implementing the event defined by the interface.
        /// Name of event (PropertyChanged) and the associated delegate (PropertyChangedEventHandler)
        /// are defined by the interface, and have to be adopted.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Translates informations concerning a property values' change into an event.
        /// 
        /// The method's name and parameters can be chosen without particular limitations. It uses
        /// the event defined by this class to dispatch the change to registered methods.
        /// 
        /// Information concerning the change is stored in an instance of PropertyChangedEventArgs.
        /// </summary>
        /// <param name="pname">A string describing the name of the property that has changed.</param>
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        int _Matriculation = 708312;
        public int Matriculation
        {
            set
            {
                this._Matriculation = value;
                this.OnPropertyChanged();
            }
            get
            {
                return this._Matriculation;
            }
        }

        string _Name = "John Doe";
        public string Name
        {
            set
            {
                this._Name = value;
                this.OnPropertyChanged();
            }
            get
            {
                return this._Name;
            }
        }

        int _Age = 21;
        public int Age
        {
            set
            {
                this._Age = value;
                this.OnPropertyChanged();
            }
            get
            {
                return _Age;
            }
        }

        string _Study = "Informatik";
        public string Study
        {
            set
            {
                this._Study = value;
                this.OnPropertyChanged();
            }
            get
            {
                return this._Study;
            }
        }
    }
}