using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librealsense
{
    public class Context
    {
        IntPtr context;

        private Context( IntPtr context )
        {
            this.context = context;
        }

        public static Context Create( int version )
        {
            IntPtr error = IntPtr.Zero;
            var context = NativeMethod.Context.rs_create_context( version, out error );
            RealSenseException.Handle( error );

            return new Context( context );
        }

        public int GetDeviceCount()
        {
            IntPtr error = IntPtr.Zero;
            var count = NativeMethod.Context.rs_get_device_count( context, out error );
            RealSenseException.Handle( error );

            return count;
        }

        public Device GetDevice( int index )
        {
            IntPtr error = IntPtr.Zero;
            var device = NativeMethod.Context.rs_get_device( context, index, out error );
            RealSenseException.Handle( error );

            return new Device( device );
        }

        public void Close()
        {
            if( context != IntPtr.Zero ) {
                IntPtr error = IntPtr.Zero;
                NativeMethod.Context.rs_delete_context( context, out error );
                RealSenseException.Handle( error );

                context = IntPtr.Zero;
            }
        }
    }
}
