using UnityEngine;
using System.Collections;
using librealsense;
using System.Runtime.InteropServices;

public class RealSenseManager : MonoBehaviour
{

    Context context;
    Device device;

    public Texture2D texture;

    public int width = 640;
    public int height = 480;
    public int bytePerPixels = 3;

    // Use this for initialization
    void Start()
    {
        context = Context.Create( 4 );
        Debug.Log( context.GetDeviceCount() );

        device = context.GetDevice( 0 );
        Debug.Log( device.GetDeviceName() );

        device.EnableStream( StreamType.color, width, height, FormatType.rgb8, 60 );
        device.StartDevice();

        texture = new Texture2D( width, height, TextureFormat.RGB24, false );

        GetComponent<Renderer>().material.mainTexture = texture;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");

        device.WaitForFrames();
        var ptr = device.GetFrameData( StreamType.color );

        // CreateExternalTextureが動かない
        //var externalTexture =  Texture2D.CreateExternalTexture( width, height, TextureFormat.RGB24, false , false, ptr);
        //texture.UpdateExternalTexture( externalTexture );

        byte[] buffer = new byte[width * height * bytePerPixels];
        Marshal.Copy( ptr, buffer, 0, buffer.Length );

        var colors = texture.GetPixels32();
        for ( int i = 0; i < width * height; i++ ) {
            int index = i * bytePerPixels;
            colors[i].r = buffer[index + 0];
            colors[i].g = buffer[index + 1];
            colors[i].b = buffer[index + 2];
        }
        texture.SetPixels32(colors);
        texture.Apply();
    }

    public void OnApplicationQuit()
    {
        if ( device != null ) {
            device.Stop();
            device = null;
        }

        if(context != null ) {
            context.Close();
            context = null;
        }
    }
}
