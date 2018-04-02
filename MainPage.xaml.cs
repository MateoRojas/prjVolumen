using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using prjVolumen.Shape;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace prjVolumen
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IMainScreen
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.initComboBox();
            this.updateNavigation();
            this.updateAreaText(this.getCurrentScreen().getArea());
        }

        private void updateNavigation()
        {
            frmContent.Navigate(this.getSelectedType((ShapeType) cmbMenu.SelectedItem), this);
        }

        private IShapeScreen getCurrentScreen() => (IShapeScreen)frmContent.Content;

        private Type getSelectedType(ShapeType type)
        {
            switch(type)
            {
                case ShapeType.Cuadrado:
                    return typeof(CuadradoPage);

                case ShapeType.Rectangulo:
                    return typeof(RectanguloPage);

                default:
                    return null;
            }
        }

        private void updateAreaText(Double area)
        {
            txbArea.Text = area.ToString();
        }

        private void initComboBox()
        {
            cmbMenu.ItemsSource = Enum.GetValues(typeof(ShapeType)).Cast<ShapeType>();
            cmbMenu.SelectedIndex = 0;
        }

        private void cmbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.updateNavigation();
            this.updateAreaText(this.getCurrentScreen().getArea());
        }

        public void updateArea(Double area)
        {
            this.updateAreaText(area);
        }

        private void btnArea_Click(object sender, RoutedEventArgs e)
        {
            this.updateAreaText(this.getCurrentScreen().getArea());
        }
    }

    public enum ShapeType
    {
        Cuadrado,
        Rectangulo
    }
}
