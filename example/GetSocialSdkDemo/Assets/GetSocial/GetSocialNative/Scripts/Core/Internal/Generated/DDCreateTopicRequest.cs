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
  public partial class DDCreateTopicRequest : TBase
  {
    private string _sessionId;
    private string _appId;
    private string _id;
    private Dictionary<string, string> _title;
    private Dictionary<string, string> _topicDescription;
    private string _avatarUrl;
    private Dictionary<int, int> _permissions;
    private Dictionary<string, string> _properties;
    private bool _isDiscoverable;
    private List<string> _labels;

    public string SessionId
    {
      get
      {
        return _sessionId;
      }
      set
      {
        __isset.sessionId = true;
        this._sessionId = value;
      }
    }

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

    public string Id
    {
      get
      {
        return _id;
      }
      set
      {
        __isset.id = true;
        this._id = value;
      }
    }

    public Dictionary<string, string> Title
    {
      get
      {
        return _title;
      }
      set
      {
        __isset.title = true;
        this._title = value;
      }
    }

    public Dictionary<string, string> TopicDescription
    {
      get
      {
        return _topicDescription;
      }
      set
      {
        __isset.topicDescription = true;
        this._topicDescription = value;
      }
    }

    public string AvatarUrl
    {
      get
      {
        return _avatarUrl;
      }
      set
      {
        __isset.avatarUrl = true;
        this._avatarUrl = value;
      }
    }

    /// <summary>
    /// map<SGAction, SGRole> permissions, check SGAction and SGRole for possible values
    /// </summary>
    public Dictionary<int, int> Permissions
    {
      get
      {
        return _permissions;
      }
      set
      {
        __isset.permissions = true;
        this._permissions = value;
      }
    }

    /// <summary>
    /// feed.post = admin, feed.post.interact = everyone
    /// </summary>
    public Dictionary<string, string> Properties
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

    public bool IsDiscoverable
    {
      get
      {
        return _isDiscoverable;
      }
      set
      {
        __isset.isDiscoverable = true;
        this._isDiscoverable = value;
      }
    }

    public List<string> Labels
    {
      get
      {
        return _labels;
      }
      set
      {
        __isset.labels = true;
        this._labels = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool sessionId;
      public bool appId;
      public bool id;
      public bool title;
      public bool topicDescription;
      public bool avatarUrl;
      public bool permissions;
      public bool properties;
      public bool isDiscoverable;
      public bool labels;
    }

    public DDCreateTopicRequest() {
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
                SessionId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                AppId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Id = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Map) {
                {
                  Title = new Dictionary<string, string>();
                  TMap _map55 = iprot.ReadMapBegin();
                  for( int _i56 = 0; _i56 < _map55.Count; ++_i56)
                  {
                    string _key57;
                    string _val58;
                    _key57 = iprot.ReadString();
                    _val58 = iprot.ReadString();
                    Title[_key57] = _val58;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.Map) {
                {
                  TopicDescription = new Dictionary<string, string>();
                  TMap _map59 = iprot.ReadMapBegin();
                  for( int _i60 = 0; _i60 < _map59.Count; ++_i60)
                  {
                    string _key61;
                    string _val62;
                    _key61 = iprot.ReadString();
                    _val62 = iprot.ReadString();
                    TopicDescription[_key61] = _val62;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.String) {
                AvatarUrl = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.Map) {
                {
                  Permissions = new Dictionary<int, int>();
                  TMap _map63 = iprot.ReadMapBegin();
                  for( int _i64 = 0; _i64 < _map63.Count; ++_i64)
                  {
                    int _key65;
                    int _val66;
                    _key65 = iprot.ReadI32();
                    _val66 = iprot.ReadI32();
                    Permissions[_key65] = _val66;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.Map) {
                {
                  Properties = new Dictionary<string, string>();
                  TMap _map67 = iprot.ReadMapBegin();
                  for( int _i68 = 0; _i68 < _map67.Count; ++_i68)
                  {
                    string _key69;
                    string _val70;
                    _key69 = iprot.ReadString();
                    _val70 = iprot.ReadString();
                    Properties[_key69] = _val70;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.Bool) {
                IsDiscoverable = iprot.ReadBool();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 10:
              if (field.Type == TType.List) {
                {
                  Labels = new List<string>();
                  TList _list71 = iprot.ReadListBegin();
                  for( int _i72 = 0; _i72 < _list71.Count; ++_i72)
                  {
                    string _elem73;
                    _elem73 = iprot.ReadString();
                    Labels.Add(_elem73);
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
        TStruct struc = new TStruct("DDCreateTopicRequest");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (SessionId != null && __isset.sessionId) {
          field.Name = "sessionId";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(SessionId);
          oprot.WriteFieldEnd();
        }
        if (AppId != null && __isset.appId) {
          field.Name = "appId";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AppId);
          oprot.WriteFieldEnd();
        }
        if (Id != null && __isset.id) {
          field.Name = "id";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Id);
          oprot.WriteFieldEnd();
        }
        if (Title != null && __isset.title) {
          field.Name = "title";
          field.Type = TType.Map;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, Title.Count));
            foreach (string _iter74 in Title.Keys)
            {
              oprot.WriteString(_iter74);
              oprot.WriteString(Title[_iter74]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (TopicDescription != null && __isset.topicDescription) {
          field.Name = "topicDescription";
          field.Type = TType.Map;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, TopicDescription.Count));
            foreach (string _iter75 in TopicDescription.Keys)
            {
              oprot.WriteString(_iter75);
              oprot.WriteString(TopicDescription[_iter75]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (AvatarUrl != null && __isset.avatarUrl) {
          field.Name = "avatarUrl";
          field.Type = TType.String;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(AvatarUrl);
          oprot.WriteFieldEnd();
        }
        if (Permissions != null && __isset.permissions) {
          field.Name = "permissions";
          field.Type = TType.Map;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.I32, TType.I32, Permissions.Count));
            foreach (int _iter76 in Permissions.Keys)
            {
              oprot.WriteI32(_iter76);
              oprot.WriteI32(Permissions[_iter76]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Properties != null && __isset.properties) {
          field.Name = "properties";
          field.Type = TType.Map;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, Properties.Count));
            foreach (string _iter77 in Properties.Keys)
            {
              oprot.WriteString(_iter77);
              oprot.WriteString(Properties[_iter77]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.isDiscoverable) {
          field.Name = "isDiscoverable";
          field.Type = TType.Bool;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(IsDiscoverable);
          oprot.WriteFieldEnd();
        }
        if (Labels != null && __isset.labels) {
          field.Name = "labels";
          field.Type = TType.List;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, Labels.Count));
            foreach (string _iter78 in Labels)
            {
              oprot.WriteString(_iter78);
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
      StringBuilder __sb = new StringBuilder("DDCreateTopicRequest(");
      bool __first = true;
      if (SessionId != null && __isset.sessionId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SessionId: ");
        __sb.Append(SessionId);
      }
      if (AppId != null && __isset.appId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AppId: ");
        __sb.Append(AppId);
      }
      if (Id != null && __isset.id) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Id: ");
        __sb.Append(Id);
      }
      if (Title != null && __isset.title) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Title: ");
        __sb.Append(Title.ToDebugString());
      }
      if (TopicDescription != null && __isset.topicDescription) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("TopicDescription: ");
        __sb.Append(TopicDescription.ToDebugString());
      }
      if (AvatarUrl != null && __isset.avatarUrl) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AvatarUrl: ");
        __sb.Append(AvatarUrl);
      }
      if (Permissions != null && __isset.permissions) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Permissions: ");
        __sb.Append(Permissions.ToDebugString());
      }
      if (Properties != null && __isset.properties) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Properties: ");
        __sb.Append(Properties.ToDebugString());
      }
      if (__isset.isDiscoverable) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("IsDiscoverable: ");
        __sb.Append(IsDiscoverable);
      }
      if (Labels != null && __isset.labels) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Labels: ");
        __sb.Append(Labels.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
