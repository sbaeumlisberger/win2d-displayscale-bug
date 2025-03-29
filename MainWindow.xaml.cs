using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Brushes;
using Microsoft.UI;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Graphics.Canvas.UI;

namespace Win2DBug
{
    public sealed partial class MainWindow : Window
    {
        private CanvasSolidColorBrush? blueBrush;
        private CanvasSolidColorBrush? redBrush;

        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void Canvas_CreateResources(CanvasControl sender, CanvasCreateResourcesEventArgs args)
        {
            blueBrush = new CanvasSolidColorBrush(sender, Colors.Blue);
            redBrush = new CanvasSolidColorBrush(sender, Colors.Red);
        }

        private void Canvas_Draw(CanvasControl sender, CanvasDrawEventArgs args)
        {
            Debug.WriteLine($"{sender.Size.Width} x {sender.Size.Height}");

            args.DrawingSession.Units = CanvasUnits.Pixels;
            args.DrawingSession.Antialiasing = CanvasAntialiasing.Aliased;

            args.DrawingSession.FillRectangle(new Rect(0, 100, 100, 100), blueBrush);

            args.DrawingSession.DrawRectangle(new Rect(0.5f, 300.5f, 99.5f, 99.5f), redBrush);

            Task.Delay(1000).ContinueWith(_ => canvas.Invalidate());
        }       
    }
}
