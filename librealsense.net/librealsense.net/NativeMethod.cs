using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace librealsense
{
    public static class NativeMethod
    {
        //static string DllPath = ((IntPtr.Size == 4) ? @"lib\x86\" : @"lib\x64\") + "realsense.dll";

        const string DllPath = @"lib\x86\realsense.dll";

        public static class Context
        {
            [DllImport( DllPath )]
            public static extern IntPtr rs_create_context( int api_version, out IntPtr error );

            [DllImport( DllPath )]
            public static extern void rs_delete_context( IntPtr context, out IntPtr error );

            [DllImport( DllPath )]
            public static extern int rs_get_device_count( IntPtr context, out IntPtr error );

            [DllImport( DllPath )]
            public static extern IntPtr rs_get_device( IntPtr context, int index, out IntPtr error );
        }


        public static class Device
        {
            [DllImport( DllPath )]
            public static extern string rs_get_device_name( IntPtr device, out IntPtr error );

            [DllImport( DllPath )]
            public static extern string rs_get_device_serial( IntPtr device, out IntPtr error );

            [DllImport( DllPath )]
            public static extern string rs_get_device_firmware_version( IntPtr device, out IntPtr error );

            //[DllImport( DllPath )]
            //public static extern void rs_get_device_extrinsics(IntPtr device, StreamType from_stream, StreamType to_stream, out RsExtrinsics extrin, out IntPtr error);

            [DllImport( DllPath )]
            public static extern void rs_enable_stream( IntPtr device, StreamType stream, int width, int height, FormatType format, int framerate, out IntPtr error );

            [DllImport( DllPath )]
            public static extern void rs_wait_for_frames( IntPtr device, out IntPtr error );

            [DllImport( DllPath )]
            public static extern IntPtr rs_get_frame_data( IntPtr device, StreamType stream, out IntPtr error );

            [DllImport( DllPath )]
            public static extern void rs_start_device( IntPtr device, out IntPtr error );

        }
    }
}
