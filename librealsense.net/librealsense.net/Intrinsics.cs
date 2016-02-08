using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace librealsense
{
    [StructLayout( LayoutKind.Sequential )]
    public class Intrinsics
    {
        public int width;                      /* width of the image in pixels */
        public int height;                     /* height of the image in pixels */
        public float ppx;                      /* horizontal coordinate of the principal point of the image, as a pixel offset from the left edge */
        public float ppy;                      /* vertical coordinate of the principal point of the image, as a pixel offset from the top edge */
        public float fx;                       /* focal length of the image plane, as a multiple of pixel width */
        public float fy;                       /* focal length of the image plane, as a multiple of pixel height */
        public DistortionType model;           /* distortion model of the image */
        public float[] coeffs = new float[5];  /* distortion coefficients */
    }
}
