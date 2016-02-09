# librealsense.net
librealsense for .NET

https://github.com/IntelRealSense/librealsense

## Platforms

 1. Windows 10(Visual Studio 2015 .NET Framework 3.5)
 
## Frameworks
 
 1. WPF
 2. Unity
 
## How To Use
 
    var context = Context.Create( 4 );
    int count = context.GetDeviceCount();
    if ( count == 0 ) {
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
