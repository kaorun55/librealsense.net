using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace librealsense
{
    [StructLayout( LayoutKind.Sequential )]
    public class Extrinsics
    {
        [MarshalAs( UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 9 )]
        public float[] rotation;    /* column-major 3x3 rotation matrix */

        [MarshalAs( UnmanagedType.ByValArray, ArraySubType = UnmanagedType.R4, SizeConst = 3 )]
        public float[] translation; /* 3 element translation vector, in meters */

        public Extrinsics()
        {
            rotation = new float[9];
            translation = new float[3];
        }
    }
}
