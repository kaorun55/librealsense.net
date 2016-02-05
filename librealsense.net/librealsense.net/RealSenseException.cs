using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace librealsense
{
    public class RealSenseException : Exception
    {
        string message;
        public override string Message
        {
            get
            {
                return message;    
            }
        }

        private RealSenseException( IntPtr error )
        {
            message = NativeMethod.Error.rs_get_error_message( error );
            //var args = NativeMethod.Error.rs_get_failed_args( error );
            //var function = NativeMethod.Error.rs_get_failed_function( error );

            NativeMethod.Error.rs_free_error( error );
        }

        public static void Handle( IntPtr error )
        {
            if ( error != IntPtr.Zero ) {
                throw new RealSenseException( error );
            }
        }
    }
}
