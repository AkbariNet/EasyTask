using System.Text.RegularExpressions;
using System.Windows.Input;

namespace EasyTask.Class
{
    // for check TextBox for only NUMBER ~~
    class onlyNum
    {
        public static void onlyNumKeyPreviewDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // for dont add space
            if (e.Key == Key.Space)
                e.Handled = true;

        }
        public static void onlyNumPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // for limit To Number
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
