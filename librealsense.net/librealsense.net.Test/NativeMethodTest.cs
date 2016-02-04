using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace librealsense.net.Test
{
    [TestClass]
    public class NativeMethodTest
    {
        IntPtr context = IntPtr.Zero;

        [TestInitialize]
        public void SetUp()
        {
            IntPtr error = IntPtr.Zero;
            context = NativeMethod.Context.rs_create_context( 4, error );

            Assert.AreEqual( error, IntPtr.Zero );
        }

        [TestCleanup]
        public void TearDown()
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Context.rs_delete_context( context, error );

            Assert.AreEqual( error, IntPtr.Zero );
        }

        [TestMethod]
        public void Test_rs_get_device_count()
        {
            IntPtr error = IntPtr.Zero;
            var count = NativeMethod.Context.rs_get_device_count( context, error );

            Assert.AreEqual( error, IntPtr.Zero );
        }

        [TestMethod]
        public void Test_rs_get_device()
        {
            IntPtr error = IntPtr.Zero;
            var device = NativeMethod.Context.rs_get_device( context, 0, error );

            Assert.AreEqual( error, IntPtr.Zero );
        }

        [TestMethod]
        public void Test_rs_get_device_name()
        {
            IntPtr error = IntPtr.Zero;
            var device = NativeMethod.Context.rs_get_device( context, 0, error );
            var deviceName = NativeMethod.Device.rs_get_device_name( device, error );

            Assert.AreEqual( error, IntPtr.Zero );
        }
    }
}
