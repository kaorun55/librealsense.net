using UnityEngine;
using System.Collections;
using librealsense;
using System.Runtime.InteropServices;

public class RealSenseManager : MonoBehaviour
{

    Context context;
    public Device Device
    {
        get;
        private set;
    }

    // Use this for initialization
    void Start()
    {
        context = Context.Create( 4 );
        Debug.Log( context.GetDeviceCount() );

        Device = context.GetDevice( 0 );
        Debug.Log( Device.GetDeviceName() );

        Device.EnableStream( StreamType.color, PresetType.best_quality );
        Device.EnableStream( StreamType.depth, PresetType.best_quality );
        Device.EnableStream( StreamType.infrared, PresetType.best_quality );
        Device.StartDevice();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log( "Update RealSenseManager" );

        Device.WaitForFrames();

    }

    public void OnDestroy()
    {
        //if ( device != null ) {
        //    device.Stop();
        //    device = null;
        //}

        if ( context != null ) {
            context.Close();
            context = null;
        }
    }

    public void OnApplicationQuit()
    {
    }
}
