#if UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX || UNITY_EDITOR
/**
 * Autogenerated by Thrift Compiler ()
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace GetSocialSdk.Core 
{

  /// <summary>
  /// #sdk7
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class AFAttachment : TBase
  {
    private string _imageUrl;
    private string _videoUrl;

    public string ImageUrl
    {
      get
      {
        return _imageUrl;
      }
      set
      {
        __isset.imageUrl = true;
        this._imageUrl = value;
      }
    }

    public string VideoUrl
    {
      get
      {
        return _videoUrl;
      }
      set
      {
        __isset.videoUrl = true;
        this._videoUrl = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool imageUrl;
      public bool videoUrl;
    }

    public AFAttachment() {
    }

    public void Read (TProtocol iprot)
    {
      iprot.IncrementRecursionDepth();
      try
      {
        TField field;
        iprot.ReadStructBegin();
        while (true)
        {
          field = iprot.ReadFieldBegin();
          if (field.Type == TType.Stop) { 
            break;
          }
          switch (field.ID)
          {
            case 1:
              if (field.Type == TType.String) {
                ImageUrl = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                VideoUrl = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            default: 
              TProtocolUtil.Skip(iprot, field.Type);
              break;
          }
          iprot.ReadFieldEnd();
        }
        iprot.ReadStructEnd();
      }
      finally
      {
        iprot.DecrementRecursionDepth();
      }
    }

    public void Write(TProtocol oprot) {
      oprot.IncrementRecursionDepth();
      try
      {
        TStruct struc = new TStruct("AFAttachment");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (ImageUrl != null && __isset.imageUrl) {
          field.Name = "imageUrl";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ImageUrl);
          oprot.WriteFieldEnd();
        }
        if (VideoUrl != null && __isset.videoUrl) {
          field.Name = "videoUrl";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(VideoUrl);
          oprot.WriteFieldEnd();
        }
        oprot.WriteFieldStop();
        oprot.WriteStructEnd();
      }
      finally
      {
        oprot.DecrementRecursionDepth();
      }
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("AFAttachment(");
      bool __first = true;
      if (ImageUrl != null && __isset.imageUrl) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ImageUrl: ");
        __sb.Append(ImageUrl);
      }
      if (VideoUrl != null && __isset.videoUrl) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("VideoUrl: ");
        __sb.Append(VideoUrl);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
