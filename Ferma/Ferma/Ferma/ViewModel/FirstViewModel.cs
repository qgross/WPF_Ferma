using Ferma.Helper;
using Ferma.View;

namespace Ferma.ViewModel
{
    public class FirstViewModel : BaseViewModel
    {
        #region Command
        public DelegateCommand AboutCommand => new DelegateCommand(OpenStartWin);
        public DelegateCommand CommandEntry => new DelegateCommand(OpenEntry);
        public DelegateCommand CommandRegistration => new DelegateCommand(OpenRegCloseWin);
        #endregion

        #region Command implementation
        private void OpenStartWin()
        {
            new Start().Show();
            CloseAction();
        }
        
        private void OpenRegCloseWin(object x)
        {
            new Registration().Show();
            CloseAction();
        }

        private void OpenEntry(object x)
        {
            new Entry().Show();
            CloseAction();
        }
        #endregion

    }

}




