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
using System.Windows.Shapes;

namespace CRUD
{
    /// <summary>
    /// Lógica interna para CursoJanela.xaml
    /// </summary>
    public partial class CursoJanela : Window
    {
        public CursoJanela()
        {
            InitializeComponent();
            NivelComboBox.ItemsSource = Enum.GetValues(typeof(Model.Nivel)).Cast<Model.Nivel>();
            AreaComboBox.ItemsSource = Enum.GetValues(typeof(Model.Area)).Cast<Model.Area>();
        }
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
