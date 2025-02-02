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
  public partial class DDUpdateActivityResponse : TBase
  {
    private AFActivity _activity;

    public AFActivity Activity
    {
      get
      {
        return _activity;
      }
      set
      {
        __isset.activity = true;
        this._activity = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool activity;
    }

    public DDUpdateActivityResponse() {
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
                Activity = new AFActivity();
                Activity.Read(iprot);
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
        TStruct struc = new TStruct("DDUpdateActivityResponse");
        oprot.WriteStructBegin(struc);
        TField field = new TField();
        if (Activity != null && __isset.activity) {
          field.Name = "activity";
          field.Type = TType.Struct;
          field.ID = 1;
          oprot.WriteFieldBegin(field);
          Activity.Write(oprot);
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
      StringBuilder __sb = new StringBuilder("DDUpdateActivityResponse(");
      bool __first = true;
      if (Activity != null && __isset.activity) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Activity: ");
        __sb.Append(Activity== null ? "<null>" : Activity.ToString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
