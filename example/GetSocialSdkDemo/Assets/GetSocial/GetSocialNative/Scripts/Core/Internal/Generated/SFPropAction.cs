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
  public partial class SFPropAction : TBase
  {
    private string _value;
    private SFPropOp _op;

    public string Value
    {
      get
      {
        return _value;
      }
      set
      {
        __isset.@value = true;
        this._value = value;
      }
    }

    /// <summary>
    /// 
    /// <seealso cref="SFPropOp"/>
    /// </summary>
    public SFPropOp Op
    {
      get
      {
        return _op;
      }
      set
      {
        __isset.op = true;
        this._op = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool @value;
      public bool op;
    }

    public SFPropAction() {
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
                Value = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 2:
              if (field.Type == TType.I32) {
                Op = (SFPropOp)iprot.ReadI32();
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
        TStruct struc = new TStruct("SFPropAction");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Value != null && __isset.@value) {
          field.Name = "value";
          field.Type = TType.String;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Value);
          oprot.WriteFieldEnd();
        }
        if (__isset.op) {
          field.Name = "op";
          field.Type = TType.I32;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32((int)Op);
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
      StringBuilder __sb = new StringBuilder("SFPropAction(");
      bool __first = true;
      if (Value != null && __isset.@value) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Value: ");
        __sb.Append(Value);
      }
      if (__isset.op) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Op: ");
        __sb.Append(Op);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
