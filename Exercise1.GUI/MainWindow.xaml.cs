using System;
using System.Windows;

namespace Exercise1.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            // Populat the DataContext which stands in for data from a database
            Exercise1.GUI.DataContext.Initialize();
            
            DataContext = new MainViewModel();
        }
    }
}
