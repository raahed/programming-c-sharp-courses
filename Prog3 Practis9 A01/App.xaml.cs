using System.Windows;
using UniModel;
using WpfMvvmExercise.ViewModels;

namespace WpfMvvmExercise
{
    /// <summary>
    /// Application logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            #region Model
            UniList model = new UniList();
            model.Add(new Uni("MIT", "Boston"));
            model.Add(new Uni("Harvard", "Cambridge"));
            model.Add(new Uni("Oxford", "Oxford"));
            #endregion Model

            #region ViewModel (for Grid)
            // Create the ViewModel to which the main window binds.
            var viewModel = new UniListViewModel(model);
            // When the ViewModel asks to be closed, close the window.
            //viewModel.RequestClose += delegate
            //{
            //    window.Close();
            //};
            #endregion ViewModel

            #region View Grid
            GridWindow window = new GridWindow();
            // Allow all controls in the window to bind to the ViewModel by setting the DataContext.
            window.DataContext = viewModel;
            window.Show();
            #endregion View Grid

            #region ViewModel (for Carousel)
            //todo Replace by carousel ViewModel.
            var viewModel2 = new UniListViewModel(model);
            #endregion ViewModel (for Carousel)

            #region View Page
            CarouselWindow window2 = new CarouselWindow();
            // Allow all controls in the window to bind to the ViewModel by setting the DataContext.
            window2.DataContext = viewModel2;
            window2.Show();
            #endregion View Page
        }
    }
}
