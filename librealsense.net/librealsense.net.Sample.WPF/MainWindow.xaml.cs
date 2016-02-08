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

namespace librealsense.net.Sample.WPF
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isContinue = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            Task.Run( () =>
            {
                try {
                    StartCppApi();
                    //StartCApi();
                }
                catch ( Exception ex ) {
                    MessageBox.Show( ex.Message );
                }
            } );
        }

        BitmapSource CreateBitmapSource( Device device, StreamType stream )
        {
            var width = device.GetStreamWidth( stream );
            var height = device.GetStreamHeight( stream );
            var format = device.GetStreamFormat( stream );

            var pixelFormat = PixelFormats.Rgb24;
            if ( format == FormatType.y8 ) {
                pixelFormat = PixelFormats.Gray8;
            }
            else if ( format == FormatType.z16 ) {
                pixelFormat = PixelFormats.Gray16;
            }

            var bpp = pixelFormat.BitsPerPixel / 8;

            return BitmapSource.Create( width, height, 96, 96, pixelFormat, null,
                device.GetFrameData( stream ), width * height * bpp, width * bpp );
        }

        private void StartCppApi()
        {
            var context = Context.Create( 4 );
            int count = context.GetDeviceCount();
            if ( count == 0 ) {
                // 例外をだす
                context.GetDevice( 0 );
                return;
            }

            var device = context.GetDevice( 0 );
            Dispatcher.BeginInvoke( new Action( () =>
            {
                TextDeviceName.Text = device.GetDeviceName();
            } ) );

            device.EnableStream( StreamType.color, PresetType.best_quality );
            device.EnableStream( StreamType.depth, PresetType.best_quality );
            device.EnableStream( StreamType.infrared, PresetType.best_quality );
            device.StartDevice();

            while ( isContinue ) {
                device.WaitForFrames();

                Dispatcher.BeginInvoke( new Action( () =>
                {
                    ImageColor.Source = CreateBitmapSource( device, StreamType.color );
                    ImageDepth.Source = CreateBitmapSource( device, StreamType.depth );
                    ImageIr.Source = CreateBitmapSource( device, StreamType.infrared );
                } ) );
            }

            device.Stop();
        }

        private void StartCApi()
        {
            IntPtr error = IntPtr.Zero;
            var context = NativeMethod.Context.rs_create_context( 4, out error );

            var count = NativeMethod.Context.rs_get_device_count( context, out error );
            if ( count == 0 ) {
                var d = NativeMethod.Context.rs_get_device( context, 0, out error );
                var message = NativeMethod.Error.rs_get_error_message( error );
                var args = NativeMethod.Error.rs_get_failed_args( error );
                var function = NativeMethod.Error.rs_get_failed_function( error );
                //var p = error.ToPointer();
                return;
            }

            var device = NativeMethod.Context.rs_get_device( context, 0, out error );
            var deviceName = NativeMethod.Device.rs_get_device_name( device, out error );
            Console.WriteLine( deviceName );

            NativeMethod.Device.rs_enable_stream( device, StreamType.color, 640, 480, FormatType.rgb8, 60, out error );
            NativeMethod.Device.rs_start_device( device, out error );

            while ( isContinue ) {
                NativeMethod.Device.rs_wait_for_frames( device, out error );

                Dispatcher.BeginInvoke( new Action( () =>
                {
                    var ptr = NativeMethod.Device.rs_get_frame_data( device, StreamType.color, out error );
                    int stride = 640 * 3;
                    int size = stride * 480;
                    ImageColor.Source = BitmapSource.Create( 640, 480, 96, 96, PixelFormats.Rgb24, null, ptr, size, stride );
                } ) );
            }
        }
    }
}
