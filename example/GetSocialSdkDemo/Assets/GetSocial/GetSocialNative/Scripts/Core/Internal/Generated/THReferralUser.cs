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
  public partial class THReferralUser : TBase
  {
    private THPublicUser _user;
    private string _eventDate;
    private string _event;
    private Dictionary<string, string> _customData;

    public THPublicUser User
    {
      get
      {
        return _user;
      }
      set
      {
        __isset.user = true;
        this._user = value;
      }
    }

    public string EventDate
    {
      get
      {
        return _eventDate;
      }
      set
      {
        __isset.eventDate = true;
        this._eventDate = value;
      }
    }

    /// <summary>
    /// as Unix timestamp
    /// </summary>
    public string Event
    {
      get
      {
        return _event;
      }
      set
      {
        __isset.@event = true;
        this._event = value;
      }
    }

    /// <summary>
    /// The event that established the referral relationship
    /// </summary>
    public Dictionary<string, string> CustomData
    {
      get
      {
        return _customData;
      }
      set
      {
        __isset.customData = true;
        this._customData = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool user;
      public bool eventDate;
      public bool @event;
      public bool customData;
    }

    public THReferralUser() {
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
                User = new THPublicUser();
                User.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                EventDate = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Event = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Map) {
                {
                  CustomData = new Dictionary<string, string>();
                  TMap _map38 = iprot.ReadMapBegin();
                  for( int _i39 = 0; _i39 < _map38.Count; ++_i39)
                  {
                    string _key40;
                    string _val41;
                    _key40 = iprot.ReadString();
                    _val41 = iprot.ReadString();
                    CustomData[_key40] = _val41;
                  }
                  iprot.ReadMapEnd();
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
        TStruct struc = new TStruct("THReferralUser");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (User != null && __isset.user) {
          field.Name = "user";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          User.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (EventDate != null && __isset.eventDate) {
          field.Name = "eventDate";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(EventDate);
          oprot.WriteFieldEnd();
        }
        if (Event != null && __isset.@event) {
          field.Name = "event";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Event);
          oprot.WriteFieldEnd();
        }
        if (CustomData != null && __isset.customData) {
          field.Name = "customData";
          field.Type = TType.Map;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, CustomData.Count));
            foreach (string _iter42 in CustomData.Keys)
            {
              oprot.WriteString(_iter42);
              oprot.WriteString(CustomData[_iter42]);
            }
            oprot.WriteMapEnd();
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
      StringBuilder __sb = new StringBuilder("THReferralUser(");
      bool __first = true;
      if (User != null && __isset.user) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("User: ");
        __sb.Append(User== null ? "<null>" : User.ToString());
      }
      if (EventDate != null && __isset.eventDate) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("EventDate: ");
        __sb.Append(EventDate);
      }
      if (Event != null && __isset.@event) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Event: ");
        __sb.Append(Event);
      }
      if (CustomData != null && __isset.customData) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CustomData: ");
        __sb.Append(CustomData.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
