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
  public partial class THInviteProviders : TBase
  {
    private THInviteContent _defaultInviteContent;
    private List<THInviteProvider> _providers;

    public THInviteContent DefaultInviteContent
    {
      get
      {
        return _defaultInviteContent;
      }
      set
      {
        __isset.defaultInviteContent = true;
        this._defaultInviteContent = value;
      }
    }

    public List<THInviteProvider> Providers
    {
      get
      {
        return _providers;
      }
      set
      {
        __isset.providers = true;
        this._providers = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool defaultInviteContent;
      public bool providers;
    }

    public THInviteProviders() {
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
              if (field.Type == TType.Struct) {
                DefaultInviteContent = new THInviteContent();
                DefaultInviteContent.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.List) {
                {
                  Providers = new List<THInviteProvider>();
                  TList _list38 = iprot.ReadListBegin();
                  for( int _i39 = 0; _i39 < _list38.Count; ++_i39)
                  {
                    THInviteProvider _elem40;
                    _elem40 = new THInviteProvider();
                    _elem40.Read(iprot);
                    Providers.Add(_elem40);
                  }
                  iprot.ReadListEnd();
                }
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
        TStruct struc = new TStruct("THInviteProviders");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (DefaultInviteContent != null && __isset.defaultInviteContent) {
          field.Name = "defaultInviteContent";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          DefaultInviteContent.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (Providers != null && __isset.providers) {
          field.Name = "providers";
          field.Type = TType.List;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Providers.Count));
            foreach (THInviteProvider _iter41 in Providers)
            {
              _iter41.Write(oprot);
            }
            oprot.WriteListEnd();
          }
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
      StringBuilder __sb = new StringBuilder("THInviteProviders(");
      bool __first = true;
      if (DefaultInviteContent != null && __isset.defaultInviteContent) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("DefaultInviteContent: ");
        __sb.Append(DefaultInviteContent== null ? "<null>" : DefaultInviteContent.ToString());
      }
      if (Providers != null && __isset.providers) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Providers: ");
        __sb.Append(Providers.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
