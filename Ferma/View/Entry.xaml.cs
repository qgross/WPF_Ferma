using Ferma.ViewModel;
using System.Windows;

namespace Ferma.View
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Entry : Window
    {
        public Entry()
        {
            InitializeComponent();
            DataContext = new EntryViewModel() { CloseAction = () => this.Close() };
        }
    }
}
