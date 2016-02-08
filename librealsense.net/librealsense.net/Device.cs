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

        public void GetDeviceExtrinsics( StreamType from_stream, StreamType to_stream, ref Extrinsics extrin )
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_get_device_extrinsics( device, from_stream, to_stream, ref extrin, out error );
            RealSenseException.Handle( error );
        }

        public void GetStreamIntrinsics( StreamType stream, ref Intrinsics intrin )
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_get_stream_intrinsics( device, stream, ref intrin, out error );
            RealSenseException.Handle( error );
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
            var value = NativeMethod.Device.rs_is_stream_enabled( device, stream, out error );
            RealSenseException.Handle( error );

            return value != 0;
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

        public bool IsSupportsOption( OptionType option )
        {
            IntPtr error = IntPtr.Zero;
            var value = NativeMethod.Device.rs_device_supports_option( device, option, out error );
            RealSenseException.Handle( error );

            return value != 0;
        }

        public void GetOptionRange( OptionType option, out double min, out double max, out double step )
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_get_device_option_range( device, option, out min, out max, out step, out error );
            RealSenseException.Handle( error );
        }

        public double GetOption( OptionType option )
        {
            IntPtr error = IntPtr.Zero;
            var value = NativeMethod.Device.rs_get_device_option( device, option, out error );
            RealSenseException.Handle( error );

            return value;
        }

        public void SetOption( OptionType option, double value )
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Device.rs_set_device_option( device, option, value, out error );
            RealSenseException.Handle( error );
        }
    }
}
