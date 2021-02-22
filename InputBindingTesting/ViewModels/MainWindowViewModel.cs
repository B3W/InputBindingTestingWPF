using InputBindingTesting.Commands;
using System;
using System.Windows;
using System.Windows.Input;

namespace InputBindingTesting.ViewModels
{
    class MainWindowViewModel : BaseViewModel
    {
        #region Fields

        private readonly IInputElement _owner;

        #endregion // Fields


        #region Properties

        /// <summary>
        /// Key bound to action
        /// </summary>
        public Key ActionKey { get; } = Key.A;

        /// <summary>
        /// Action key command
        /// </summary>
        public ICommand ActionKeyCommand { get; }

        /// <summary>
        /// Key down command
        /// </summary>
        public ICommand KeyDownCommand { get; }

        /// <summary>
        /// Mouse down command
        /// </summary>
        public ICommand MouseDownCommand { get; }

        /// <summary>
        /// Mouse up command
        /// </summary>
        public ICommand MouseUpCommand { get; }

        /// <summary>
        /// Mouse move command
        /// </summary>
        public ICommand MouseMoveCommand { get; }

        #endregion // Properties


        #region Methods

        /// <summary>
        /// Constructs the view model
        /// </summary>
        /// <param name="owner">Input element that owns this viewmodel</param>
        public MainWindowViewModel(IInputElement owner)
        {
            _owner = owner;

            ActionKeyCommand = new RelayCommand(_ => ExecuteAction());
            KeyDownCommand = new RelayCommand<KeyEventArgs>(KeyDown);
            MouseDownCommand = new RelayCommand<MouseButtonEventArgs>(MouseDown);
            MouseUpCommand = new RelayCommand<MouseButtonEventArgs>(MouseUp);
            MouseMoveCommand = new RelayCommand<MouseEventArgs>(MouseMove);
        }

        /// <summary>
        /// Handler for the mouse down command
        /// </summary>
        /// <param name="e">Arguments for the mouse down event</param>
        public void MouseDown(MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(_owner);
            Console.WriteLine($"Mouse down: ({position.X}, {position.Y})");

            e.Handled = true;
        }

        /// <summary>
        /// Handler for the mouse up command
        /// </summary>
        /// <param name="e">Arguments for the mouse up event</param>
        public void MouseUp(MouseButtonEventArgs e)
        {
            Point position = e.GetPosition(_owner);
            Console.WriteLine($"Mouse up: ({position.X}, {position.Y})");

            e.Handled = true;
        }

        /// <summary>
        /// Handler for the mouse move command
        /// </summary>
        /// <param name="e">Arguments for the mouse move event</param>
        public void MouseMove(MouseEventArgs e)
        {
            Point position = e.GetPosition(_owner);
            Console.WriteLine($"Mouse move: ({position.X}, {position.Y})");

            e.Handled = true;
        }

        /// <summary>
        /// Handler for key up command
        /// </summary>
        public void ExecuteAction()
        {
            Console.WriteLine("Execute action!");
        }

        /// <summary>
        /// Handler for action key command
        /// </summary>
        public void KeyDown(KeyEventArgs e)
        {
            Console.WriteLine($"Key down: {e.Key}");
        }

        #endregion // Methods
    }
}
