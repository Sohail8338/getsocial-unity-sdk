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
  public partial class CreateVoteRequest : TBase
  {
    private string _sessionId;
    private SGEntity _target;
    private THashSet<string> _optionIds;
    private bool _keepExisting;

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

    public SGEntity Target
    {
      get
      {
        return _target;
      }
      set
      {
        __isset.target = true;
        this._target = value;
      }
    }

    public THashSet<string> OptionIds
    {
      get
      {
        return _optionIds;
      }
      set
      {
        __isset.optionIds = true;
        this._optionIds = value;
      }
    }

    public bool KeepExisting
    {
      get
      {
        return _keepExisting;
      }
      set
      {
        __isset.keepExisting = true;
        this._keepExisting = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool sessionId;
      public bool target;
      public bool optionIds;
      public bool keepExisting;
    }

    public CreateVoteRequest() {
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
              if (field.Type == TType.Struct) {
                Target = new SGEntity();
                Target.Read(iprot);
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 3:
              if (field.Type == TType.Set) {
                {
                  OptionIds = new THashSet<string>();
                  TSet _set315 = iprot.ReadSetBegin();
                  for( int _i316 = 0; _i316 < _set315.Count; ++_i316)
                  {
                    string _elem317;
                    _elem317 = iprot.ReadString();
                    OptionIds.Add(_elem317);
                  }
                  iprot.ReadSetEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 4:
              if (field.Type == TType.Bool) {
                KeepExisting = iprot.ReadBool();
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
        TStruct struc = new TStruct("CreateVoteRequest");
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
        if (Target != null && __isset.target) {
          field.Name = "target";
          field.Type = TType.Struct;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          Target.Write(oprot);
          oprot.WriteFieldEnd();
        }
        if (OptionIds != null && __isset.optionIds) {
          field.Name = "optionIds";
          field.Type = TType.Set;
          field.ID = 3;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteSetBegin(new TSet(TType.String, OptionIds.Count));
            foreach (string _iter318 in OptionIds)
            {
              oprot.WriteString(_iter318);
            }
            oprot.WriteSetEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.keepExisting) {
          field.Name = "keepExisting";
          field.Type = TType.Bool;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteBool(KeepExisting);
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
      StringBuilder __sb = new StringBuilder("CreateVoteRequest(");
      bool __first = true;
      if (SessionId != null && __isset.sessionId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("SessionId: ");
        __sb.Append(SessionId);
      }
      if (Target != null && __isset.target) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Target: ");
        __sb.Append(Target== null ? "<null>" : Target.ToString());
      }
      if (OptionIds != null && __isset.optionIds) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("OptionIds: ");
        __sb.Append(OptionIds);
      }
      if (__isset.keepExisting) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("KeepExisting: ");
        __sb.Append(KeepExisting);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
