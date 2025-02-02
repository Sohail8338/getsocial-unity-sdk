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
  public partial class GetNotificationsResponse : TBase
  {
    private List<PNNotification> _notifications;
    private int _totalNumber;
    private string _nextCursor;
    private Dictionary<string, THPublicUser> _authors;

    public List<PNNotification> Notifications
    {
      get
      {
        return _notifications;
      }
      set
      {
        __isset.notifications = true;
        this._notifications = value;
      }
    }

    public int TotalNumber
    {
      get
      {
        return _totalNumber;
      }
      set
      {
        __isset.totalNumber = true;
        this._totalNumber = value;
      }
    }

    public string NextCursor
    {
      get
      {
        return _nextCursor;
      }
      set
      {
        __isset.nextCursor = true;
        this._nextCursor = value;
      }
    }

    public Dictionary<string, THPublicUser> Authors
    {
      get
      {
        return _authors;
      }
      set
      {
        __isset.authors = true;
        this._authors = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool notifications;
      public bool totalNumber;
      public bool nextCursor;
      public bool authors;
    }

    public GetNotificationsResponse() {
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
              if (field.Type == TType.List) {
                {
                  Notifications = new List<PNNotification>();
                  TList _list111 = iprot.ReadListBegin();
                  for( int _i112 = 0; _i112 < _list111.Count; ++_i112)
                  {
                    PNNotification _elem113;
                    _elem113 = new PNNotification();
                    _elem113.Read(iprot);
                    Notifications.Add(_elem113);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I32) {
                TotalNumber = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                NextCursor = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Map) {
                {
                  Authors = new Dictionary<string, THPublicUser>();
                  TMap _map114 = iprot.ReadMapBegin();
                  for( int _i115 = 0; _i115 < _map114.Count; ++_i115)
                  {
                    string _key116;
                    THPublicUser _val117;
                    _key116 = iprot.ReadString();
                    _val117 = new THPublicUser();
                    _val117.Read(iprot);
                    Authors[_key116] = _val117;
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
        TStruct struc = new TStruct("GetNotificationsResponse");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Notifications != null && __isset.notifications) {
          field.Name = "notifications";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Notifications.Count));
            foreach (PNNotification _iter118 in Notifications)
            {
              _iter118.Write(oprot);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.totalNumber) {
          field.Name = "totalNumber";
          field.Type = TType.I32;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(TotalNumber);
          oprot.WriteFieldEnd();
        }
        if (NextCursor != null && __isset.nextCursor) {
          field.Name = "nextCursor";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(NextCursor);
          oprot.WriteFieldEnd();
        }
        if (Authors != null && __isset.authors) {
          field.Name = "authors";
          field.Type = TType.Map;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.Struct, Authors.Count));
            foreach (string _iter119 in Authors.Keys)
            {
              oprot.WriteString(_iter119);
              Authors[_iter119].Write(oprot);
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
      StringBuilder __sb = new StringBuilder("GetNotificationsResponse(");
      bool __first = true;
      if (Notifications != null && __isset.notifications) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Notifications: ");
        __sb.Append(Notifications.ToDebugString());
      }
      if (__isset.totalNumber) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TotalNumber: ");
        __sb.Append(TotalNumber);
      }
      if (NextCursor != null && __isset.nextCursor) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("NextCursor: ");
        __sb.Append(NextCursor);
      }
      if (Authors != null && __isset.authors) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Authors: ");
        __sb.Append(Authors.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
