using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librealsense
{
    public enum DistortionType
    {
        none = 0, ///< Rectilinear images, no distortion compensation required
        modified_brown_conrady = 1, ///< Equivalent to Brown-Conrady distortion, except that tangential distortion is applied to radially distorted points
        inverse_brown_conrady = 2  ///< Equivalent to Brown-Conrady distortion, except undistorts image instead of distorting it
    }
}
