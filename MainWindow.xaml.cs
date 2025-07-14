using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Password_Generator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            // Get the length from the textbox
            if (!int.TryParse(LengthTextBox.Text, out int length) || length < 1)
            {
                MessageBox.Show("Please enter a valid password length (1 or more)");
                return;
            }

            // Build character set based on checkboxes
            string characterSet = "";
            if (IncludeUppercase.IsChecked == true)
                characterSet += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            if (IncludeLowercase.IsChecked == true)
                characterSet += "abcdefghijklmnopqrstuvwxyz";
            if (IncludeNumbers.IsChecked == true)
                characterSet += "0123456789";
            if (IncludeSymbols.IsChecked == true)
                characterSet += "!@#$%^&*()_+-=[]{}|;:,.<>?";

            // Check if at least one character type is selected
            if (string.IsNullOrEmpty(characterSet))
            {
                MessageBox.Show("Please select at least one character type");
                return;
            }

            // Generate the password
            Random random = new Random();
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(characterSet.Length);
                password.Append(characterSet[randomIndex]);
            }

            // Display the generated password
            PasswordTextBox.Text = password.ToString();
        }

        private void CopyPassword_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                Clipboard.SetText(PasswordTextBox.Text);
                MessageBox.Show("Password copied to clipboard!");
            }
            else
            {
                MessageBox.Show("No password to copy. Generate one first!");
            }
        }
    }
}