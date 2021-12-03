using Core.Input;
using Core.Interfaces;

namespace Core
{
    public class InputViewModel : IInputViewModel
    {
        public IRotateInputViewModel RotateInputViewModel { get; }

        public InputViewModel()
        {
            RotateInputViewModel = new RotateInputViewModel();
        }
    }
}