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

namespace CRUD
{
    /// <summary>
    /// lógica da pagina principal Curso pagina.xaml
    /// </summary>
    public partial class CursoPagina : Page
    {
        public CursoPagina()
        {
            InitializeComponent();
            DataContext = new ViewModel.CursoPaginaVM();
        }
    }
}
