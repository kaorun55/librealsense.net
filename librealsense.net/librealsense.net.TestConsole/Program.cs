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
            var ctx = NativeMethod.Context.rs_create_context(4, error );

            var count = NativeMethod.Context.rs_get_device_count(ctx, error);
            Console.WriteLine(count);

            /*if ( count > 0 )*/ {
                var device = NativeMethod.Context.rs_get_device( ctx, 0, error );
                var deviceName = NativeMethod.Device.rs_get_device_name(device, error);
                Console.WriteLine( deviceName );
            }

            NativeMethod.Context.rs_delete_context( ctx, error );

        }
    }
}
