using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PalindromeChecker
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            string input = InputTextBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                ResultText.Text = "❌ Будь ласка, введіть слово!";
                return;
            }

            string cleanText = CleanText(input);

            if (IsPalindrome(cleanText))
            {
                ResultText.Text = $"✅ '{input}' - це паліндром!\n(без зайвих символів: '{cleanText}')";
                ResultBorder.Background = System.Windows.Media.Brushes.LightGreen;
            }
            else
            {
                ResultText.Text = $"❌ '{input}' - це не паліндром\n(без зайвих символів: '{cleanText}')";
                ResultBorder.Background = System.Windows.Media.Brushes.LightCoral;
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.Text = "";
            ResultText.Text = "Тут буде результат...";
            ResultBorder.Background = System.Windows.Media.Brushes.LightYellow;
        }

        private string CleanText(string text)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    result.Append(char.ToLower(c));
                }
            }
            return result.ToString();
        }

        private bool IsPalindrome(string text)
        {
            if (string.IsNullOrEmpty(text)) return false;

            for (int i = 0; i < text.Length / 2; i++)
            {
                if (text[i] != text[text.Length - 1 - i])
                    return false;
            }
            return true;
        }

        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}