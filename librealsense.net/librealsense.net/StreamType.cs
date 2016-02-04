﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librealsense
{
    public enum StreamType
    {
        depth                            = 0, ///< Native stream of depth data produced by RealSense device
        color                            = 1, ///< Native stream of color data captured by RealSense device
        infrared                         = 2, ///< Native stream of infrared data captured by RealSense device
        infrared2                        = 3, ///< Native stream of infrared data captured from a second viewpoint by RealSense device
        points                           = 4, ///< Synthetic stream containing point cloud data generated by deprojecting the depth image
        rectified_color                  = 5, ///< Synthetic stream containing undistorted color data with no extrinsic rotation from the depth stream
        color_aligned_to_depth           = 6, ///< Synthetic stream containing color data but sharing intrinsics of depth stream
        infrared2_aligned_to_depth       = 7, ///< Synthetic stream containing second viewpoint infrared data but sharing intrinsics of depth stream
        depth_aligned_to_color           = 8, ///< Synthetic stream containing depth data but sharing intrinsics of color stream
        depth_aligned_to_rectified_color = 9, ///< Synthetic stream containing depth data but sharing intrinsics of rectified color stream
        depth_aligned_to_infrared2       = 10 ///< Synthetic stream containing depth data but sharing intrinsics of second viewpoint infrared stream
    }
}
