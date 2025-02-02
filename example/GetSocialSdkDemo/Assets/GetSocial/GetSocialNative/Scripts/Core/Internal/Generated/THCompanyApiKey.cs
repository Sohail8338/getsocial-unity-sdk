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
  public partial class THCompanyApiKey : TBase
  {
    private string _id;
    private string _companyId;
    private string _key;
    private string _name;
    private Role _role;
    private long _status;
    private List<string> _apps;
    private List<string> _ips;

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

    public string CompanyId
    {
      get
      {
        return _companyId;
      }
      set
      {
        __isset.companyId = true;
        this._companyId = value;
      }
    }

    public string Key
    {
      get
      {
        return _key;
      }
      set
      {
        __isset.key = true;
        this._key = value;
      }
    }

    public string Name
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

    /// <summary>
    /// valid values are ApiKeyAdmin and ApiKeyLimited
    /// 
    /// <seealso cref=".Role"/>
    /// </summary>
    public Role Role
    {
      get
      {
        return _role;
      }
      set
      {
        __isset.role = true;
        this._role = value;
      }
    }

    /// <summary>
    /// 0/1 for disabled/enabled
    /// </summary>
    public long Status
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

    /// <summary>
    /// Only set for role ApiKeyLimited
    /// </summary>
    public List<string> Apps
    {
      get
      {
        return _apps;
      }
      set
      {
        __isset.apps = true;
        this._apps = value;
      }
    }

    /// <summary>
    /// IP whitelist, in CIDR notation
    /// </summary>
    public List<string> Ips
    {
      get
      {
        return _ips;
      }
      set
      {
        __isset.ips = true;
        this._ips = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool companyId;
      public bool key;
      public bool name;
      public bool role;
      public bool status;
      public bool apps;
      public bool ips;
    }

    public THCompanyApiKey() {
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
                Id = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.String) {
                CompanyId = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.String) {
                Key = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.String) {
                Name = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.I32) {
                Role = (Role)iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.I64) {
                Status = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.List) {
                {
                  Apps = new List<string>();
                  TList _list12 = iprot.ReadListBegin();
                  for( int _i13 = 0; _i13 < _list12.Count; ++_i13)
                  {
                    string _elem14;
                    _elem14 = iprot.ReadString();
                    Apps.Add(_elem14);
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
                  Ips = new List<string>();
                  TList _list15 = iprot.ReadListBegin();
                  for( int _i16 = 0; _i16 < _list15.Count; ++_i16)
                  {
                    string _elem17;
                    _elem17 = iprot.ReadString();
                    Ips.Add(_elem17);
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
        TStruct struc = new TStruct("THCompanyApiKey");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Id != null && __isset.id) {
          field.Name = "id";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Id);
          oprot.WriteFieldEnd();
        }
        if (CompanyId != null && __isset.companyId) {
          field.Name = "companyId";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(CompanyId);
          oprot.WriteFieldEnd();
        }
        if (Key != null && __isset.key) {
          field.Name = "key";
          field.Type = TType.String;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Key);
          oprot.WriteFieldEnd();
        }
        if (Name != null && __isset.name) {
          field.Name = "name";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Name);
          oprot.WriteFieldEnd();
        }
        if (__isset.role) {
          field.Name = "role";
          field.Type = TType.I32;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32((int)Role);
          oprot.WriteFieldEnd();
        }
        if (__isset.status) {
          field.Name = "status";
          field.Type = TType.I64;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(Status);
          oprot.WriteFieldEnd();
        }
        if (Apps != null && __isset.apps) {
          field.Name = "apps";
          field.Type = TType.List;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, Apps.Count));
            foreach (string _iter18 in Apps)
            {
              oprot.WriteString(_iter18);
            }
            oprot.WriteListEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (Ips != null && __isset.ips) {
          field.Name = "ips";
          field.Type = TType.List;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.String, Ips.Count));
            foreach (string _iter19 in Ips)
            {
              oprot.WriteString(_iter19);
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
      StringBuilder __sb = new StringBuilder("THCompanyApiKey(");
      bool __first = true;
      if (Id != null && __isset.id) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Id: ");
        __sb.Append(Id);
      }
      if (CompanyId != null && __isset.companyId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CompanyId: ");
        __sb.Append(CompanyId);
      }
      if (Key != null && __isset.key) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Key: ");
        __sb.Append(Key);
      }
      if (Name != null && __isset.name) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Name: ");
        __sb.Append(Name);
      }
      if (__isset.role) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Role: ");
        __sb.Append(Role);
      }
      if (__isset.status) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Status: ");
        __sb.Append(Status);
      }
      if (Apps != null && __isset.apps) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Apps: ");
        __sb.Append(Apps.ToDebugString());
      }
      if (Ips != null && __isset.ips) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Ips: ");
        __sb.Append(Ips.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
