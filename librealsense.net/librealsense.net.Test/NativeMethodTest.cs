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
            context = NativeMethod.Context.rs_create_context( 4, out error );

            Assert.AreEqual( error, IntPtr.Zero );
        }

        [TestCleanup]
        public void TearDown()
        {
            IntPtr error = IntPtr.Zero;
            NativeMethod.Context.rs_delete_context( context, out error );

            Assert.AreEqual( error, IntPtr.Zero );
        }

        [TestMethod]
        public void Test_rs_get_device_count()
        {
            IntPtr error = IntPtr.Zero;
            var count = NativeMethod.Context.rs_get_device_count( context, out error );

            Assert.AreEqual( error, IntPtr.Zero );
        }

        [TestMethod]
        public void Test_rs_get_device()
        {
            // デバイスを接続した状態で実行してください
            IntPtr error = IntPtr.Zero;
            var device = NativeMethod.Context.rs_get_device( context, 0, out error );

            Assert.AreEqual( error, IntPtr.Zero );
        }

        [TestMethod]
        public void Test_rs_get_device_name()
        {
            // デバイスを接続した状態で実行してください
            IntPtr error = IntPtr.Zero;
            var device = NativeMethod.Context.rs_get_device( context, 0, out error );
            var deviceName = NativeMethod.Device.rs_get_device_name( device, out error );

            Assert.AreEqual( error, IntPtr.Zero );
        }
    }
}
