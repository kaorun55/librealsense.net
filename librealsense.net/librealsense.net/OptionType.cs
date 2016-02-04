﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librealsense
{
    public enum OptionType
    {
        color_backlight_compensation                    = 0,  
        color_brightness                                = 1,  
        color_contrast                                  = 2,  
        color_exposure                                  = 3,  ///< Controls exposure time of color camera. Setting any value will disable auto exposure.
        color_gain                                      = 4,  
        color_gamma                                     = 5,  
        color_hue                                       = 6,  
        color_saturation                                = 7,  
        color_sharpness                                 = 8,  
        color_white_balance                             = 9,  ///< Controls white balance of color image. Setting any value will disable auto white balance.
        color_enable_auto_exposure                      = 10, ///< Set to 1 to enable automatic exposure control, or 0 to return to manual control
        color_enable_auto_white_balance                 = 11, ///< Set to 1 to enable automatic white balance control, or 0 to return to manual control
        f200_laser_power                                = 12, ///< 0 - 15
        f200_accuracy                                   = 13, ///< 0 - 3
        f200_motion_range                               = 14, ///< 0 - 100
        f200_filter_option                              = 15, ///< 0 - 7
        f200_confidence_threshold                       = 16, ///< 0 - 15
        sr300_dynamic_fps                               = 17, ///< {2, 5, 15, 30, 60}
        sr300_auto_range_enable_motion_versus_range     = 18, 
        sr300_auto_range_enable_laser                   = 19, 
        sr300_auto_range_min_motion_versus_range        = 20, 
        sr300_auto_range_max_motion_versus_range        = 21, 
        sr300_auto_range_start_motion_versus_range      = 22, 
        sr300_auto_range_min_laser                      = 23, 
        sr300_auto_range_max_laser                      = 24, 
        sr300_auto_range_start_laser                    = 25, 
        sr300_auto_range_upper_threshold                = 26, 
        sr300_auto_range_lower_threshold                = 27, 
        r200_lr_auto_exposure_enabled                   = 28, ///< {0, 1}
        r200_lr_gain                                    = 29, ///< 100 - 1600 (Units of 0.01)
        r200_lr_exposure                                = 30, ///< > 0 (Units of 0.1 ms)
        r200_emitter_enabled                            = 31, ///< {0, 1}
        r200_depth_units                                = 32, ///< micrometers per increment in integer depth values, 1000 is default (mm scale)
        r200_depth_clamp_min                            = 33, ///< 0 - USHORT_MAX
        r200_depth_clamp_max                            = 34, ///< 0 - USHORT_MAX
        r200_disparity_multiplier                       = 35, ///< 0 - 1000, the increments in integer disparity values corresponding to one pixel of disparity
        r200_disparity_shift                            = 36, 
        r200_auto_exposure_mean_intensity_set_point     = 37, 
        r200_auto_exposure_bright_ratio_set_point       = 38, 
        r200_auto_exposure_kp_gain                      = 39, 
        r200_auto_exposure_kp_exposure                  = 40, 
        r200_auto_exposure_kp_dark_threshold            = 41, 
        r200_auto_exposure_top_edge                     = 42, 
        r200_auto_exposure_bottom_edge                  = 43, 
        r200_auto_exposure_left_edge                    = 44, 
        r200_auto_exposure_right_edge                   = 45, 
        r200_depth_control_estimate_median_decrement    = 46, 
        r200_depth_control_estimate_median_increment    = 47, 
        r200_depth_control_median_threshold             = 48, 
        r200_depth_control_score_minimum_threshold      = 49, 
        r200_depth_control_score_maximum_threshold      = 50, 
        r200_depth_control_texture_count_threshold      = 51, 
        r200_depth_control_texture_difference_threshold = 52, 
        r200_depth_control_second_peak_threshold        = 53, 
        r200_depth_control_neighbor_threshold           = 54, 
        r200_depth_control_lr_threshold                 = 55  
    }
}
