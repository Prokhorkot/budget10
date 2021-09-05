using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GAIExam.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для HelloWiew.xaml
    /// </summary>
    public partial class HelloWiew : UserControl
    {
        public HelloWiew()
        {
            InitializeComponent();
        }

        private void Closebtn_Click(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void AnalizeBtn_Click(object sender, RoutedEventArgs e)
        {
            GAIExam.MVVM.Model.Program.readInfo(temp.Text);
            GAIExam.MVVM.Model.Program.analyzeInfo(temp.Text);
        }
    }
}
