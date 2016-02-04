using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librealsense
{
    public enum FormatType
    {
        any         = 0,  
        z16         = 1,  ///< 16 bit linear depth values. The depth is meters is equal to depth scale * pixel value
        disparity16 = 2,  ///< 16 bit linear disparity values. The depth in meters is equal to depth scale / pixel value
        xyz32f      = 3,  ///< 32 bit floating point 3D coordinates.
        yuyv        = 4,  
        rgb8        = 5,  
        bgr8        = 6,  
        rgba8       = 7,  
        bgra8       = 8,  
        y8          = 9,  
        y16         = 10, 
        raw10       = 11  ///< Four 10-bit luminance values encoded into a 5-byte macropixel
    }
}
