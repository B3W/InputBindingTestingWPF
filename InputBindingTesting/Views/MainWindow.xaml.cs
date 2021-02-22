using InputBindingTesting.ViewModels;
using System.Windows;

namespace InputBindingTesting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private readonly MainWindowViewModel _viewModel;

        #endregion // Fields


        #region Properties
        #endregion // Properties


        #region Methods

        public MainWindow()
        {
            InitializeComponent();

            // Set DataContext
            _viewModel = new MainWindowViewModel(this);
            DataContext = _viewModel;
        }

        #endregion // Methods
    }
}
