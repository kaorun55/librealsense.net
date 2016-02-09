using UnityEngine;
using System.Collections;
using librealsense;
using System.Runtime.InteropServices;

public class RealSenseImageViewer : MonoBehaviour {
    public RealSenseManager realsense;

    public Texture2D texture;
    public StreamType streamType = StreamType.color;

    public int width;
    public int height;
    public int bytePerPixels = 3;
    public FormatType format;

    // Use this for initialization
    void Start () {
        //texture = new Texture2D( width, height, TextureFormat.RGB24, false );
        //GetComponent<Renderer>().material.mainTexture = texture;

    }

    // Update is called once per frame
    void Update () {
        Debug.Log( "Update RealSenseImageViewer" );

        if ( !realsense.Device.IsStreamEnabled( streamType ) ) {
            return;
        }

        if ( texture == null ) {
            width = realsense.Device.GetStreamWidth( streamType );
            height = realsense.Device.GetStreamHeight( streamType );
            texture = new Texture2D( width, height, TextureFormat.RGB24, false );
            GetComponent<Renderer>().material.mainTexture = texture;

            format = realsense.Device.GetStreamFormat( streamType );
            if ( format == FormatType.rgb8 ) {
                bytePerPixels = 3;
            }
            else if ( format == FormatType.y16 ) {
                bytePerPixels = 2;
            }
            else if ( format == FormatType.y8 ) {
                bytePerPixels = 1;
            }
        }
        return;

        var ptr = realsense.Device.GetFrameData( streamType );

        // CreateExternalTextureが動かない
        //var externalTexture =  Texture2D.CreateExternalTexture( width, height, TextureFormat.RGB24, false , false, ptr);
        //texture.UpdateExternalTexture( externalTexture );

        byte[] buffer = new byte[width * height * bytePerPixels];
        Marshal.Copy( ptr, buffer, 0, buffer.Length );

        var colors = texture.GetPixels32();

        if ( format == FormatType.rgb8 ) {
            for ( int i = 0; i < width * height; i++ ) {
                int index = i * bytePerPixels;
                colors[i].r = buffer[index + 0];
                colors[i].g = buffer[index + 1];
                colors[i].b = buffer[index + 2];
            }
        }
        //else if ( format == FormatType.y16 ) {
        //    for ( int i = 0; i < width * height; i++ ) {
        //        int index = i * bytePerPixels;
        //        byte value = (byte)((buffer[index + 0] << 8 | buffer[index + 1]) * 65535 / 255);
        //        colors[i].r = value;
        //        colors[i].g = value;
        //        colors[i].b = value;
        //    }
        //}
        //else if ( format == FormatType.y8 ) {
        //    for ( int i = 0; i < width * height; i++ ) {
        //        colors[i].r = buffer[i];
        //        colors[i].g = buffer[i];
        //        colors[i].b = buffer[i];
        //    }
        //}

        texture.SetPixels32( colors );
        texture.Apply();
    }
}
