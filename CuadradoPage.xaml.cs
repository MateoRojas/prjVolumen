using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using prjVolumen.Shape;
using prjVolumen.Shapes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.System;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace prjVolumen
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CuadradoPage : Page, IShapeScreen
    {
        private IMainScreen mainScreen;
        private Double side;

        public CuadradoPage()
        {
            this.InitializeComponent();
            this.initValues();
            this.updateValues();
        }

        private void initValues()
        {
            this.side = 0;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           this.mainScreen = (IMainScreen)e.Parameter;
        }

        private void updateValues()
        {
            this.side = Utils.Utils.getDoubleValue(txtSide.Text);

            this.updateValuesScreen();
        }

        private void updateValuesScreen()
        {
            txtSide.Text = this.side.ToString();
        }

        public Double getArea()
        {
            this.updateValues();
            return new Square(this.side).getArea();
        }

        private void OnKeyDownHandler(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                mainScreen.updateArea(this.getArea());
            }
        }

        private void plusOne_Click(object sender, RoutedEventArgs e)
        {
            this.side += 1;
            this.updateValuesScreen();
            mainScreen.updateArea(this.getArea());
        }
    }
}
