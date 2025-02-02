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
  public partial class THNotificationsSetStatusParams : TBase
  {
    private List<string> _ids;
    private bool _isRead;
    private string _appId;
    private string _status;

    /// <summary>
    /// id has the same format as described in the THNotification struct
    /// </summary>
    public List<string> Ids
    {
      get
      {
        return _ids;
      }
      set
      {
        __isset.ids = true;
        this._ids = value;
      }
    }

    public bool IsRead
    {
      get
      {
        return _isRead;
      }
      set
      {
        __isset.isRead = true;
        this._isRead = value;
      }
    }

    /// <summary>
    /// but we need it for dashboard
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

    public string Status
    {
      get
      {
        return _status;
      }
      set
      {
        __isset.status = true;
        this._status = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool ids;
      public bool isRead;
      public bool appId;
      public bool status;
    }

    public THNotificationsSetStatusParams() {
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
                  Ids = new List<string>();
                  TList _list95 = iprot.ReadListBegin();
                  for( int _i96 = 0; _i96 < _list95.Count; ++_i96)
                  {
                    string _elem97;
                    _elem97 = iprot.ReadString();
                    Ids.Add(_elem97);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.Bool) {
                IsRead = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                AppId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                Status = iprot.ReadString();
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
        TStruct struc = new TStruct("THNotificationsSetStatusParams");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Ids != null && __isset.ids) {
          field.Name = "ids";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, Ids.Count));
            foreach (string _iter98 in Ids)
            {
              oprot.WriteString(_iter98);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.isRead) {
          field.Name = "isRead";
          field.Type = TType.Bool;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(IsRead);
          oprot.WriteFieldEnd();
        }
        if (AppId != null && __isset.appId) {
          field.Name = "appId";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AppId);
          oprot.WriteFieldEnd();
        }
        if (Status != null && __isset.status) {
          field.Name = "status";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Status);
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
      StringBuilder __sb = new StringBuilder("THNotificationsSetStatusParams(");
      bool __first = true;
      if (Ids != null && __isset.ids) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Ids: ");
        __sb.Append(Ids.ToDebugString());
      }
      if (__isset.isRead) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IsRead: ");
        __sb.Append(IsRead);
      }
      if (AppId != null && __isset.appId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AppId: ");
        __sb.Append(AppId);
      }
      if (Status != null && __isset.status) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Status: ");
        __sb.Append(Status);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
