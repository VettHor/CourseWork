using System;
using System.Windows;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Windows.Input;

namespace Highway.Loading
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();
            loadProgress();
        }
        private void loadProgress()
        {
            Duration duration = new Duration(TimeSpan.FromSeconds(4)); // time period between each value
            DoubleAnimation doubleAnimation = new DoubleAnimation(100, duration); // create a transition effect
            ProgressLoading.BeginAnimation(ProgressBar.ValueProperty, doubleAnimation); // start animating
        }

        private void ProgressLoading_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(ProgressLoading.Value == 100) // if progress bar value is equal to 100, than stop it and open MainWindow
            {
                MainWindow mainWindow = new MainWindow();
                this.Close();
                mainWindow.Show();
            }
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) // when left click
                DragMove(); // to be able to move the window when left click
        }
    }
}
