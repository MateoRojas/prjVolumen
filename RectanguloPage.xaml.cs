using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using prjVolumen.Shape;
using prjVolumen.Shapes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace prjVolumen
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class RectanguloPage : Page, IShapeScreen
    {
        private IMainScreen mainScreen;
        private Double bottom;
        private Double height;

        public RectanguloPage()
        {
            this.InitializeComponent();
            this.initValues();
            this.updateValuesScreen();
        }

        private void initValues()
        {
            this.bottom = 0;
            this.height = 0;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.mainScreen = (IMainScreen)e.Parameter;
        }

        private void updateValues()
        {
            this.bottom = Utils.Utils.getDoubleValue(txtBase.Text);
            this.height = Utils.Utils.getDoubleValue(txtHeight.Text);

            this.updateValuesScreen();
        }

        private void updateValuesScreen()
        {
            txtBase.Text = this.bottom.ToString();
            txtHeight.Text = this.height.ToString();
        }

        public double getArea()
        {
            this.updateValues();
            return new Rectangle(this.height, this.bottom).getArea();
        }

        private void OnKeyDownHandler(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                mainScreen.updateArea(this.getArea());
            }
        }

        private void plusOneBase_Click(object sender, RoutedEventArgs e)
        {
            this.bottom += 1;
            this.updateValuesScreen();
            mainScreen.updateArea(this.getArea());
        }

        private void plusOneHeight_Click(object sender, RoutedEventArgs e)
        {
            this.height += 1;
            this.updateValuesScreen();
            mainScreen.updateArea(this.getArea());
        }
    }
}
