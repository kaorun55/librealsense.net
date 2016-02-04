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
            public static extern IntPtr rs_create_context( int api_version, IntPtr error );

            [DllImport( DllPath )]
            public static extern void rs_delete_context( IntPtr context, IntPtr error );

            [DllImport( DllPath )]
            public static extern int rs_get_device_count( IntPtr context, IntPtr error );

            [DllImport( DllPath )]
            public static extern IntPtr rs_get_device( IntPtr context, int index, IntPtr error );
        }


        public static class Device
        {
            [DllImport( DllPath )]
            public static extern string rs_get_device_name( IntPtr device, IntPtr error );
        }
    }
}
