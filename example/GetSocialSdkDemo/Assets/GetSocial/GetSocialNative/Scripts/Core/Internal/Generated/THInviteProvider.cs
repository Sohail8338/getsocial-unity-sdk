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
  /// #sdk6 #sdk7
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class THInviteProvider : TBase
  {
    private Dictionary<string, string> _name;
    private string _providerId;
    private THDeviceOs _os;
    private int _displayOrder;
    private string _iconUrl;
    private bool _enabled;
    private bool _supportsInviteText;
    private bool _supportsInviteImageUrl;
    private bool _supportsInviteSubject;
    private THInviteProperties _properties;
    private THInviteContent _inviteContent;
    private bool _supportsGif;
    private bool _supportsVideo;

    public Dictionary<string, string> Name
    {
      get
      {
        return _name;
      }
      set
      {
        __isset.name = true;
        this._name = value;
      }
    }

    public string ProviderId
    {
      get
      {
        return _providerId;
      }
      set
      {
        __isset.providerId = true;
        this._providerId = value;
      }
    }

    /// <summary>
    /// 
    /// <seealso cref=".THDeviceOs"/>
    /// </summary>
    public THDeviceOs Os
    {
      get
      {
        return _os;
      }
      set
      {
        __isset.os = true;
        this._os = value;
      }
    }

    /// <summary>
    /// not needed for SDK, filter by os. needed for dev portal
    /// </summary>
    public int DisplayOrder
    {
      get
      {
        return _displayOrder;
      }
      set
      {
        __isset.displayOrder = true;
        this._displayOrder = value;
      }
    }

    public string IconUrl
    {
      get
      {
        return _iconUrl;
      }
      set
      {
        __isset.iconUrl = true;
        this._iconUrl = value;
      }
    }

    public bool Enabled
    {
      get
      {
        return _enabled;
      }
      set
      {
        __isset.enabled = true;
        this._enabled = value;
      }
    }

    /// <summary>
    /// not needed for SDK, hide enabled=false
    /// </summary>
    public bool SupportsInviteText
    {
      get
      {
        return _supportsInviteText;
      }
      set
      {
        __isset.supportsInviteText = true;
        this._supportsInviteText = value;
      }
    }

    /// <summary>
    /// for dev portal only
    /// </summary>
    public bool SupportsInviteImageUrl
    {
      get
      {
        return _supportsInviteImageUrl;
      }
      set
      {
        __isset.supportsInviteImageUrl = true;
        this._supportsInviteImageUrl = value;
      }
    }

    /// <summary>
    /// for dev portal only
    /// </summary>
    public bool SupportsInviteSubject
    {
      get
      {
        return _supportsInviteSubject;
      }
      set
      {
        __isset.supportsInviteSubject = true;
        this._supportsInviteSubject = value;
      }
    }

    /// <summary>
    /// for dev portal only
    /// </summary>
    public THInviteProperties Properties
    {
      get
      {
        return _properties;
      }
      set
      {
        __isset.properties = true;
        this._properties = value;
      }
    }

    public THInviteContent InviteContent
    {
      get
      {
        return _inviteContent;
      }
      set
      {
        __isset.inviteContent = true;
        this._inviteContent = value;
      }
    }

    public bool SupportsGif
    {
      get
      {
        return _supportsGif;
      }
      set
      {
        __isset.supportsGif = true;
        this._supportsGif = value;
      }
    }

    /// <summary>
    /// for dev portal only
    /// </summary>
    public bool SupportsVideo
    {
      get
      {
        return _supportsVideo;
      }
      set
      {
        __isset.supportsVideo = true;
        this._supportsVideo = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool name;
      public bool providerId;
      public bool os;
      public bool displayOrder;
      public bool iconUrl;
      public bool enabled;
      public bool supportsInviteText;
      public bool supportsInviteImageUrl;
      public bool supportsInviteSubject;
      public bool properties;
      public bool inviteContent;
      public bool supportsGif;
      public bool supportsVideo;
    }

    public THInviteProvider() {
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
              if (field.Type == TType.Map) {
                {
                  Name = new Dictionary<string, string>();
                  TMap _map33 = iprot.ReadMapBegin();
                  for( int _i34 = 0; _i34 < _map33.Count; ++_i34)
                  {
                    string _key35;
                    string _val36;
                    _key35 = iprot.ReadString();
                    _val36 = iprot.ReadString();
                    Name[_key35] = _val36;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                ProviderId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.I32) {
                Os = (THDeviceOs)iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.I32) {
                DisplayOrder = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.String) {
                IconUrl = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.Bool) {
                Enabled = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.Bool) {
                SupportsInviteText = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.Bool) {
                SupportsInviteImageUrl = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.Bool) {
                SupportsInviteSubject = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 10:
              if (field.Type == TType.Struct) {
                Properties = new THInviteProperties();
                Properties.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 11:
              if (field.Type == TType.Struct) {
                InviteContent = new THInviteContent();
                InviteContent.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 12:
              if (field.Type == TType.Bool) {
                SupportsGif = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 13:
              if (field.Type == TType.Bool) {
                SupportsVideo = iprot.ReadBool();
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
        TStruct struc = new TStruct("THInviteProvider");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Name != null && __isset.name) {
          field.Name = "name";
          field.Type = TType.Map;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, Name.Count));
            foreach (string _iter37 in Name.Keys)
            {
              oprot.WriteString(_iter37);
              oprot.WriteString(Name[_iter37]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (ProviderId != null && __isset.providerId) {
          field.Name = "providerId";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(ProviderId);
          oprot.WriteFieldEnd();
        }
        if (__isset.os) {
          field.Name = "os";
          field.Type = TType.I32;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32((int)Os);
          oprot.WriteFieldEnd();
        }
        if (__isset.displayOrder) {
          field.Name = "displayOrder";
          field.Type = TType.I32;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(DisplayOrder);
          oprot.WriteFieldEnd();
        }
        if (IconUrl != null && __isset.iconUrl) {
          field.Name = "iconUrl";
          field.Type = TType.String;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(IconUrl);
          oprot.WriteFieldEnd();
        }
        if (__isset.enabled) {
          field.Name = "enabled";
          field.Type = TType.Bool;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(Enabled);
          oprot.WriteFieldEnd();
        }
        if (__isset.supportsInviteText) {
          field.Name = "supportsInviteText";
          field.Type = TType.Bool;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(SupportsInviteText);
          oprot.WriteFieldEnd();
        }
        if (__isset.supportsInviteImageUrl) {
          field.Name = "supportsInviteImageUrl";
          field.Type = TType.Bool;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(SupportsInviteImageUrl);
          oprot.WriteFieldEnd();
        }
        if (__isset.supportsInviteSubject) {
          field.Name = "supportsInviteSubject";
          field.Type = TType.Bool;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(SupportsInviteSubject);
          oprot.WriteFieldEnd();
        }
        if (Properties != null && __isset.properties) {
          field.Name = "properties";
          field.Type = TType.Struct;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          Properties.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (InviteContent != null && __isset.inviteContent) {
          field.Name = "inviteContent";
          field.Type = TType.Struct;
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          InviteContent.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (__isset.supportsGif) {
          field.Name = "supportsGif";
          field.Type = TType.Bool;
          field.ID = 12;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(SupportsGif);
          oprot.WriteFieldEnd();
        }
        if (__isset.supportsVideo) {
          field.Name = "supportsVideo";
          field.Type = TType.Bool;
          field.ID = 13;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(SupportsVideo);
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
      StringBuilder __sb = new StringBuilder("THInviteProvider(");
      bool __first = true;
      if (Name != null && __isset.name) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Name: ");
        __sb.Append(Name.ToDebugString());
      }
      if (ProviderId != null && __isset.providerId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("ProviderId: ");
        __sb.Append(ProviderId);
      }
      if (__isset.os) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Os: ");
        __sb.Append(Os);
      }
      if (__isset.displayOrder) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DisplayOrder: ");
        __sb.Append(DisplayOrder);
      }
      if (IconUrl != null && __isset.iconUrl) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IconUrl: ");
        __sb.Append(IconUrl);
      }
      if (__isset.enabled) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Enabled: ");
        __sb.Append(Enabled);
      }
      if (__isset.supportsInviteText) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SupportsInviteText: ");
        __sb.Append(SupportsInviteText);
      }
      if (__isset.supportsInviteImageUrl) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SupportsInviteImageUrl: ");
        __sb.Append(SupportsInviteImageUrl);
      }
      if (__isset.supportsInviteSubject) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SupportsInviteSubject: ");
        __sb.Append(SupportsInviteSubject);
      }
      if (Properties != null && __isset.properties) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Properties: ");
        __sb.Append(Properties== null ? "<null>" : Properties.ToString());
      }
      if (InviteContent != null && __isset.inviteContent) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("InviteContent: ");
        __sb.Append(InviteContent== null ? "<null>" : InviteContent.ToString());
      }
      if (__isset.supportsGif) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SupportsGif: ");
        __sb.Append(SupportsGif);
      }
      if (__isset.supportsVideo) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SupportsVideo: ");
        __sb.Append(SupportsVideo);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
