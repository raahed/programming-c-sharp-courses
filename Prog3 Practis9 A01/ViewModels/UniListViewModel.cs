using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using UniModel;

namespace WpfMvvmExercise.ViewModels
{
    class UniListViewModel
    {
        public UniList Model { get; }
        public ICommand AddUniCommand { get; private set; }

        /// <summary>
        /// Constructs a new ViewModel based on a given Model.
        /// </summary>
        /// <param name="model">The Model this ViewModel is meant to use.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when model is undefined.</exception>
        public UniListViewModel(UniList model)
        {
            Model = model ?? throw new System.ArgumentNullException(nameof(model));
            AddUniCommand = new RelayCommand(this.AddUni);
        }

        protected void AddUni()
        {
            Model.Add(new Uni("TH Nürnberg GSO", "Nuremberg"));
        }
    }
}