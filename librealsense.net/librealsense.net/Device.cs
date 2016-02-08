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

        public void EnableStream( StreamType stream, PresetType preset )
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_enable_stream_preset( device, stream, preset, out error );
            RealSenseException.Handle( error );
        }

        public bool IsStreamEnabled( StreamType stream )
        {
            IntPtr error = IntPtr.Zero;
            var enabled = NativeMethod.Device.rs_is_stream_enabled( device, stream, out error );
            RealSenseException.Handle( error );

            return enabled != 0;
        }

        public int GetStreamWidth( StreamType stream )
        {
            IntPtr error = IntPtr.Zero;
            var value = NativeMethod.Device.rs_get_stream_width( device, stream, out error );
            RealSenseException.Handle( error );

            return value;
        }

        public int GetStreamHeight( StreamType stream )
        {
            IntPtr error = IntPtr.Zero;
            var value = NativeMethod.Device.rs_get_stream_height( device, stream, out error );
            RealSenseException.Handle( error );

            return value;
        }

        public FormatType GetStreamFormat( StreamType stream )
        {
            IntPtr error = IntPtr.Zero;
            var value = NativeMethod.Device.rs_get_stream_format( device, stream, out error );
            RealSenseException.Handle( error );

            return value;
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
            var data = NativeMethod.Device.rs_get_frame_data( device, stream, out error );
            RealSenseException.Handle( error );

            return data;
        }

        public void Stop()
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_stop_device( device, out error );
            RealSenseException.Handle( error );
        }
    }
}
