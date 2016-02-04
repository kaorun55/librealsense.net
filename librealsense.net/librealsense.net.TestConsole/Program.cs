using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librealsense.net.TestConsole
{
    class Program
    {
        static void Main( string[] args )
        {
            IntPtr error = IntPtr.Zero;
            var ctx = NativeMethod.Context.rs_create_context(4, out error );

            var count = NativeMethod.Context.rs_get_device_count(ctx, out error );
            Console.WriteLine(count);

            if ( count > 0 ) {
                var device = NativeMethod.Context.rs_get_device( ctx, 0, out error );
                var deviceName = NativeMethod.Device.rs_get_device_name(device, out error );
                Console.WriteLine( deviceName );

                NativeMethod.Device.rs_enable_stream( device, StreamType.color, 640, 480, FormatType.rgb8, 60, out error );
                NativeMethod.Device.rs_start_device( device, out error );

                for ( int i = 0; i < 10; i++ ) {
                    NativeMethod.Device.rs_wait_for_frames( device, out error );

                    var ptr = NativeMethod.Device.rs_get_frame_data( device, StreamType.color, out error );

                    Console.WriteLine(i);
                }
            }

            NativeMethod.Context.rs_delete_context( ctx, out error );

        }
    }
}
