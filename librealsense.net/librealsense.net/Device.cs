using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librealsense
{
    public class Device
    {
        IntPtr device;

        internal Device( IntPtr device )
        {
            this.device = device;
        }

        public string GetDeviceName()
        {
            IntPtr error = IntPtr.Zero;
            var deviceName = NativeMethod.Device.rs_get_device_name( device, out error );
            RealSenseException.Handle( error );

            return deviceName;
        }

        public void EnableStream( StreamType stream, int width, int height, FormatType format, int framerate )
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_enable_stream( device, stream, width, height, format, framerate, out error );
            RealSenseException.Handle( error );
        }

        public void StartDevice()
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_start_device( device, out error );
            RealSenseException.Handle( error );
        }

        public void WaitForFrames()
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_wait_for_frames( device, out error );
            RealSenseException.Handle( error );
        }

        public IntPtr GetFrameData( StreamType stream )
        {
            IntPtr error = IntPtr.Zero;
            var data = NativeMethod.Device.rs_get_frame_data( device, StreamType.color, out error );
            RealSenseException.Handle( error );

            return data;
        }
    }
}
