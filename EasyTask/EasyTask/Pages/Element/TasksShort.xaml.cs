using System.Windows;
using System.Windows.Controls;
namespace EasyTask.Pages.Element
{
    /// <summary>
    /// Interaction logic for TasksShort.xaml
    /// </summary>
    public partial class TasksShort : UserControl
    {
        public TasksShort()
        {
            InitializeComponent();
        }


        public string TaskName
        {
            get { return (string)GetValue(TaskNameProperty); }
            set { SetValue(TaskNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TaskName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskNameProperty =
            DependencyProperty.Register("TaskName", typeof(string), typeof(TasksShort), new PropertyMetadata("TaskName"));



        public string TaskTime
        {
            get { return (string)GetValue(TaskTimeProperty); }
            set { SetValue(TaskTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TaskTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskTimeProperty =
            DependencyProperty.Register("TaskTime", typeof(string), typeof(TasksShort), new PropertyMetadata("00:00"));


    }
}
