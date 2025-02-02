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
  /// #sdk6
  /// </summary>
  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class THNotificationsQuery : TBase
  {
    private int _limit;
    private string _newer;
    private string _older;
    private List<int> _type;
    private bool _isRead;
    private string _appId;
    private List<string> _types;
    private List<string> _statuses;
    private List<string> _actions;

    public int Limit
    {
      get
      {
        return _limit;
      }
      set
      {
        __isset.limit = true;
        this._limit = value;
      }
    }

    public string Newer
    {
      get
      {
        return _newer;
      }
      set
      {
        __isset.newer = true;
        this._newer = value;
      }
    }

    public string Older
    {
      get
      {
        return _older;
      }
      set
      {
        __isset.older = true;
        this._older = value;
      }
    }

    public List<int> Type
    {
      get
      {
        return _type;
      }
      set
      {
        __isset.type = true;
        this._type = value;
      }
    }

    /// <summary>
    /// - false: unread notifications
    /// </summary>
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

    public List<string> Types
    {
      get
      {
        return _types;
      }
      set
      {
        __isset.types = true;
        this._types = value;
      }
    }

    public List<string> Statuses
    {
      get
      {
        return _statuses;
      }
      set
      {
        __isset.statuses = true;
        this._statuses = value;
      }
    }

    public List<string> Actions
    {
      get
      {
        return _actions;
      }
      set
      {
        __isset.actions = true;
        this._actions = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool limit;
      public bool newer;
      public bool older;
      public bool type;
      public bool isRead;
      public bool appId;
      public bool types;
      public bool statuses;
      public bool actions;
    }

    public THNotificationsQuery() {
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
              if (field.Type == TType.I32) {
                Limit = iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                Newer = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Older = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.List) {
                {
                  Type = new List<int>();
                  TList _list79 = iprot.ReadListBegin();
                  for( int _i80 = 0; _i80 < _list79.Count; ++_i80)
                  {
                    int _elem81;
                    _elem81 = iprot.ReadI32();
                    Type.Add(_elem81);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.Bool) {
                IsRead = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.String) {
                AppId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.List) {
                {
                  Types = new List<string>();
                  TList _list82 = iprot.ReadListBegin();
                  for( int _i83 = 0; _i83 < _list82.Count; ++_i83)
                  {
                    string _elem84;
                    _elem84 = iprot.ReadString();
                    Types.Add(_elem84);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.List) {
                {
                  Statuses = new List<string>();
                  TList _list85 = iprot.ReadListBegin();
                  for( int _i86 = 0; _i86 < _list85.Count; ++_i86)
                  {
                    string _elem87;
                    _elem87 = iprot.ReadString();
                    Statuses.Add(_elem87);
                  }
                  iprot.ReadListEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.List) {
                {
                  Actions = new List<string>();
                  TList _list88 = iprot.ReadListBegin();
                  for( int _i89 = 0; _i89 < _list88.Count; ++_i89)
                  {
                    string _elem90;
                    _elem90 = iprot.ReadString();
                    Actions.Add(_elem90);
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
        TStruct struc = new TStruct("THNotificationsQuery");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (__isset.limit) {
          field.Name = "limit";
          field.Type = TType.I32;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32(Limit);
          oprot.WriteFieldEnd();
        }
        if (Newer != null && __isset.newer) {
          field.Name = "newer";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Newer);
          oprot.WriteFieldEnd();
        }
        if (Older != null && __isset.older) {
          field.Name = "older";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Older);
          oprot.WriteFieldEnd();
        }
        if (Type != null && __isset.type) {
          field.Name = "type";
          field.Type = TType.List;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.I32, Type.Count));
            foreach (int _iter91 in Type)
            {
              oprot.WriteI32(_iter91);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.isRead) {
          field.Name = "isRead";
          field.Type = TType.Bool;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(IsRead);
          oprot.WriteFieldEnd();
        }
        if (AppId != null && __isset.appId) {
          field.Name = "appId";
          field.Type = TType.String;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AppId);
          oprot.WriteFieldEnd();
        }
        if (Types != null && __isset.types) {
          field.Name = "types";
          field.Type = TType.List;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, Types.Count));
            foreach (string _iter92 in Types)
            {
              oprot.WriteString(_iter92);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Statuses != null && __isset.statuses) {
          field.Name = "statuses";
          field.Type = TType.List;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, Statuses.Count));
            foreach (string _iter93 in Statuses)
            {
              oprot.WriteString(_iter93);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Actions != null && __isset.actions) {
          field.Name = "actions";
          field.Type = TType.List;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, Actions.Count));
            foreach (string _iter94 in Actions)
            {
              oprot.WriteString(_iter94);
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
      StringBuilder __sb = new StringBuilder("THNotificationsQuery(");
      bool __first = true;
      if (__isset.limit) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Limit: ");
        __sb.Append(Limit);
      }
      if (Newer != null && __isset.newer) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Newer: ");
        __sb.Append(Newer);
      }
      if (Older != null && __isset.older) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Older: ");
        __sb.Append(Older);
      }
      if (Type != null && __isset.type) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Type: ");
        __sb.Append(Type.ToDebugString());
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
      if (Types != null && __isset.types) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Types: ");
        __sb.Append(Types.ToDebugString());
      }
      if (Statuses != null && __isset.statuses) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Statuses: ");
        __sb.Append(Statuses.ToDebugString());
      }
      if (Actions != null && __isset.actions) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Actions: ");
        __sb.Append(Actions.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
