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

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class THSetPushCertificateRequest : TBase
  {
    private string _iosCertFile;
    private string _iosCertPassword;
    private bool _iosSandbox;
    private string _androidSenderId;
    private string _androidAppKey;
    private string _appId;

    public string IosCertFile
    {
      get
      {
        return _iosCertFile;
      }
      set
      {
        __isset.iosCertFile = true;
        this._iosCertFile = value;
      }
    }

    public string IosCertPassword
    {
      get
      {
        return _iosCertPassword;
      }
      set
      {
        __isset.iosCertPassword = true;
        this._iosCertPassword = value;
      }
    }

    public bool IosSandbox
    {
      get
      {
        return _iosSandbox;
      }
      set
      {
        __isset.iosSandbox = true;
        this._iosSandbox = value;
      }
    }

    public string AndroidSenderId
    {
      get
      {
        return _androidSenderId;
      }
      set
      {
        __isset.androidSenderId = true;
        this._androidSenderId = value;
      }
    }

    public string AndroidAppKey
    {
      get
      {
        return _androidAppKey;
      }
      set
      {
        __isset.androidAppKey = true;
        this._androidAppKey = value;
      }
    }

    /// <summary>
    /// - THAppPlatformProperties.pushNotificationsCertificateDev on iOS for sandbox
    /// </summary>
    public string AppId
    {
      get
      {
        return _appId;
      }
      set
      {
        __isset.appId = true;
        this._appId = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool iosCertFile;
      public bool iosCertPassword;
      public bool iosSandbox;
      public bool androidSenderId;
      public bool androidAppKey;
      public bool appId;
    }

    public THSetPushCertificateRequest() {
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
                IosCertFile = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                IosCertPassword = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.Bool) {
                IosSandbox = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                AndroidSenderId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.String) {
                AndroidAppKey = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.String) {
                AppId = iprot.ReadString();
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
        TStruct struc = new TStruct("THSetPushCertificateRequest");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (IosCertFile != null && __isset.iosCertFile) {
          field.Name = "iosCertFile";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(IosCertFile);
          oprot.WriteFieldEnd();
        }
        if (IosCertPassword != null && __isset.iosCertPassword) {
          field.Name = "iosCertPassword";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(IosCertPassword);
          oprot.WriteFieldEnd();
        }
        if (__isset.iosSandbox) {
          field.Name = "iosSandbox";
          field.Type = TType.Bool;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(IosSandbox);
          oprot.WriteFieldEnd();
        }
        if (AndroidSenderId != null && __isset.androidSenderId) {
          field.Name = "androidSenderId";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AndroidSenderId);
          oprot.WriteFieldEnd();
        }
        if (AndroidAppKey != null && __isset.androidAppKey) {
          field.Name = "androidAppKey";
          field.Type = TType.String;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AndroidAppKey);
          oprot.WriteFieldEnd();
        }
        if (AppId != null && __isset.appId) {
          field.Name = "appId";
          field.Type = TType.String;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AppId);
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
      StringBuilder __sb = new StringBuilder("THSetPushCertificateRequest(");
      bool __first = true;
      if (IosCertFile != null && __isset.iosCertFile) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IosCertFile: ");
        __sb.Append(IosCertFile);
      }
      if (IosCertPassword != null && __isset.iosCertPassword) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IosCertPassword: ");
        __sb.Append(IosCertPassword);
      }
      if (__isset.iosSandbox) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IosSandbox: ");
        __sb.Append(IosSandbox);
      }
      if (AndroidSenderId != null && __isset.androidSenderId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AndroidSenderId: ");
        __sb.Append(AndroidSenderId);
      }
      if (AndroidAppKey != null && __isset.androidAppKey) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AndroidAppKey: ");
        __sb.Append(AndroidAppKey);
      }
      if (AppId != null && __isset.appId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AppId: ");
        __sb.Append(AppId);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
