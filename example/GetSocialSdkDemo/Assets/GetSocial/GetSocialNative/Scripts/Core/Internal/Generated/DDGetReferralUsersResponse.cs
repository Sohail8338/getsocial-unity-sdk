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
  public partial class DDGetReferralUsersResponse : TBase
  {
    private List<THReferralUser> _users;

    public List<THReferralUser> Users
    {
      get
      {
        return _users;
      }
      set
      {
        __isset.users = true;
        this._users = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool users;
    }

    public DDGetReferralUsersResponse() {
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
                  Users = new List<THReferralUser>();
                  TList _list132 = iprot.ReadListBegin();
                  for( int _i133 = 0; _i133 < _list132.Count; ++_i133)
                  {
                    THReferralUser _elem134;
                    _elem134 = new THReferralUser();
                    _elem134.Read(iprot);
                    Users.Add(_elem134);
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
        TStruct struc = new TStruct("DDGetReferralUsersResponse");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Users != null && __isset.users) {
          field.Name = "users";
          field.Type = TType.List;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteListBegin(new TList(TType.Struct, Users.Count));
            foreach (THReferralUser _iter135 in Users)
            {
              _iter135.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("DDGetReferralUsersResponse(");
      bool __first = true;
      if (Users != null && __isset.users) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Users: ");
        __sb.Append(Users.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
