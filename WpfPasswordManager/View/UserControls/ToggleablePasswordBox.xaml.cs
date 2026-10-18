using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPasswordManager.View.UserControls
{
    /// <summary>
    /// Interaction logic for ToggleablePasswordBox.xaml
    /// </summary>
    public partial class ToggleablePasswordBox : UserControl
    {
        bool passHidden = true;
        public ToggleablePasswordBox()
        {
            InitializeComponent();
        }

        private void btnToggle_Click(object sender, RoutedEventArgs e)
        {
            if(passHidden)
            {
                passwordRevealed.Text = passwordHidden.Password;
                passwordRevealed.Visibility = Visibility.Visible;
                passwordHidden.Visibility = Visibility.Hidden;
                btnShow.Content = "o";
            }
            else
            {
                passwordHidden.Password = passwordRevealed.Text;
                passwordRevealed.Visibility = Visibility.Hidden;
                passwordHidden.Visibility = Visibility.Visible;
                btnShow.Content = "●";
            }
            passHidden = !passHidden;
        }

        private void passwordHidden_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordHidden.Password))
            {
                tbPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                tbPlaceholder.Visibility = Visibility.Hidden;
            }
        }

        private void passwordRevealed_PasswordChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordRevealed.Text))
            {
                tbPlaceholder.Visibility = Visibility.Visible;
            }
            else
            {
                tbPlaceholder.Visibility = Visibility.Hidden;
            }
        }
    }
}
