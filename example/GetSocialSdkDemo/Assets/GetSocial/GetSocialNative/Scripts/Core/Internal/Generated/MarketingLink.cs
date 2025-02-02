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
  public partial class MarketingLink : TBase
  {
    private string _id;
    private string _campaignId;
    private string _appId;
    private string _name;
    private string _token;
    private string _channel;
    private string _medium;
    private string _image;
    private string _fallbackUrl;
    private string _linkUrl;
    private LinkStatus _status;
    private Dictionary<string, string> _description;
    private Dictionary<string, string> _customData;
    private long _updatedAt;
    private Dictionary<string, string> _title;

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

    public string CampaignId
    {
      get
      {
        return _campaignId;
      }
      set
      {
        __isset.campaignId = true;
        this._campaignId = value;
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

    public string Token
    {
      get
      {
        return _token;
      }
      set
      {
        __isset.token = true;
        this._token = value;
      }
    }

    public string Channel
    {
      get
      {
        return _channel;
      }
      set
      {
        __isset.channel = true;
        this._channel = value;
      }
    }

    public string Medium
    {
      get
      {
        return _medium;
      }
      set
      {
        __isset.medium = true;
        this._medium = value;
      }
    }

    public string Image
    {
      get
      {
        return _image;
      }
      set
      {
        __isset.image = true;
        this._image = value;
      }
    }

    public string FallbackUrl
    {
      get
      {
        return _fallbackUrl;
      }
      set
      {
        __isset.fallbackUrl = true;
        this._fallbackUrl = value;
      }
    }

    public string LinkUrl
    {
      get
      {
        return _linkUrl;
      }
      set
      {
        __isset.linkUrl = true;
        this._linkUrl = value;
      }
    }

    /// <summary>
    /// 
    /// <seealso cref=".LinkStatus"/>
    /// </summary>
    public LinkStatus Status
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

    public Dictionary<string, string> Description
    {
      get
      {
        return _description;
      }
      set
      {
        __isset.description = true;
        this._description = value;
      }
    }

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

    public long UpdatedAt
    {
      get
      {
        return _updatedAt;
      }
      set
      {
        __isset.updatedAt = true;
        this._updatedAt = value;
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


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool id;
      public bool campaignId;
      public bool appId;
      public bool name;
      public bool token;
      public bool channel;
      public bool medium;
      public bool image;
      public bool fallbackUrl;
      public bool linkUrl;
      public bool status;
      public bool description;
      public bool customData;
      public bool updatedAt;
      public bool title;
    }

    public MarketingLink() {
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
                CampaignId = iprot.ReadString();
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
                Name = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 5:
              if (field.Type == TType.String) {
                Token = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 6:
              if (field.Type == TType.String) {
                Channel = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 7:
              if (field.Type == TType.String) {
                Medium = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 8:
              if (field.Type == TType.String) {
                Image = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 9:
              if (field.Type == TType.String) {
                FallbackUrl = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 10:
              if (field.Type == TType.String) {
                LinkUrl = iprot.ReadString();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 11:
              if (field.Type == TType.I32) {
                Status = (LinkStatus)iprot.ReadI32();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 12:
              if (field.Type == TType.Map) {
                {
                  Description = new Dictionary<string, string>();
                  TMap _map4 = iprot.ReadMapBegin();
                  for( int _i5 = 0; _i5 < _map4.Count; ++_i5)
                  {
                    string _key6;
                    string _val7;
                    _key6 = iprot.ReadString();
                    _val7 = iprot.ReadString();
                    Description[_key6] = _val7;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 13:
              if (field.Type == TType.Map) {
                {
                  CustomData = new Dictionary<string, string>();
                  TMap _map8 = iprot.ReadMapBegin();
                  for( int _i9 = 0; _i9 < _map8.Count; ++_i9)
                  {
                    string _key10;
                    string _val11;
                    _key10 = iprot.ReadString();
                    _val11 = iprot.ReadString();
                    CustomData[_key10] = _val11;
                  }
                  iprot.ReadMapEnd();
                }
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 14:
              if (field.Type == TType.I64) {
                UpdatedAt = iprot.ReadI64();
              } else { 
                TProtocolUtil.Skip(iprot, field.Type);
              }
              break;
            case 15:
              if (field.Type == TType.Map) {
                {
                  Title = new Dictionary<string, string>();
                  TMap _map12 = iprot.ReadMapBegin();
                  for( int _i13 = 0; _i13 < _map12.Count; ++_i13)
                  {
                    string _key14;
                    string _val15;
                    _key14 = iprot.ReadString();
                    _val15 = iprot.ReadString();
                    Title[_key14] = _val15;
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
        TStruct struc = new TStruct("MarketingLink");
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
        if (CampaignId != null && __isset.campaignId) {
          field.Name = "campaignId";
          field.Type = TType.String;
          field.ID = 2;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(CampaignId);
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
        if (Name != null && __isset.name) {
          field.Name = "name";
          field.Type = TType.String;
          field.ID = 4;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Name);
          oprot.WriteFieldEnd();
        }
        if (Token != null && __isset.token) {
          field.Name = "token";
          field.Type = TType.String;
          field.ID = 5;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Token);
          oprot.WriteFieldEnd();
        }
        if (Channel != null && __isset.channel) {
          field.Name = "channel";
          field.Type = TType.String;
          field.ID = 6;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Channel);
          oprot.WriteFieldEnd();
        }
        if (Medium != null && __isset.medium) {
          field.Name = "medium";
          field.Type = TType.String;
          field.ID = 7;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Medium);
          oprot.WriteFieldEnd();
        }
        if (Image != null && __isset.image) {
          field.Name = "image";
          field.Type = TType.String;
          field.ID = 8;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(Image);
          oprot.WriteFieldEnd();
        }
        if (FallbackUrl != null && __isset.fallbackUrl) {
          field.Name = "fallbackUrl";
          field.Type = TType.String;
          field.ID = 9;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(FallbackUrl);
          oprot.WriteFieldEnd();
        }
        if (LinkUrl != null && __isset.linkUrl) {
          field.Name = "linkUrl";
          field.Type = TType.String;
          field.ID = 10;
          oprot.WriteFieldBegin(field);
          oprot.WriteString(LinkUrl);
          oprot.WriteFieldEnd();
        }
        if (__isset.status) {
          field.Name = "status";
          field.Type = TType.I32;
          field.ID = 11;
          oprot.WriteFieldBegin(field);
          oprot.WriteI32((int)Status);
          oprot.WriteFieldEnd();
        }
        if (Description != null && __isset.description) {
          field.Name = "description";
          field.Type = TType.Map;
          field.ID = 12;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, Description.Count));
            foreach (string _iter16 in Description.Keys)
            {
              oprot.WriteString(_iter16);
              oprot.WriteString(Description[_iter16]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (CustomData != null && __isset.customData) {
          field.Name = "customData";
          field.Type = TType.Map;
          field.ID = 13;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, CustomData.Count));
            foreach (string _iter17 in CustomData.Keys)
            {
              oprot.WriteString(_iter17);
              oprot.WriteString(CustomData[_iter17]);
            }
            oprot.WriteMapEnd();
          }
          oprot.WriteFieldEnd();
        }
        if (__isset.updatedAt) {
          field.Name = "updatedAt";
          field.Type = TType.I64;
          field.ID = 14;
          oprot.WriteFieldBegin(field);
          oprot.WriteI64(UpdatedAt);
          oprot.WriteFieldEnd();
        }
        if (Title != null && __isset.title) {
          field.Name = "title";
          field.Type = TType.Map;
          field.ID = 15;
          oprot.WriteFieldBegin(field);
          {
            oprot.WriteMapBegin(new TMap(TType.String, TType.String, Title.Count));
            foreach (string _iter18 in Title.Keys)
            {
              oprot.WriteString(_iter18);
              oprot.WriteString(Title[_iter18]);
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
      StringBuilder __sb = new StringBuilder("MarketingLink(");
      bool __first = true;
      if (Id != null && __isset.id) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Id: ");
        __sb.Append(Id);
      }
      if (CampaignId != null && __isset.campaignId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CampaignId: ");
        __sb.Append(CampaignId);
      }
      if (AppId != null && __isset.appId) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("AppId: ");
        __sb.Append(AppId);
      }
      if (Name != null && __isset.name) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Name: ");
        __sb.Append(Name);
      }
      if (Token != null && __isset.token) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Token: ");
        __sb.Append(Token);
      }
      if (Channel != null && __isset.channel) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Channel: ");
        __sb.Append(Channel);
      }
      if (Medium != null && __isset.medium) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Medium: ");
        __sb.Append(Medium);
      }
      if (Image != null && __isset.image) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Image: ");
        __sb.Append(Image);
      }
      if (FallbackUrl != null && __isset.fallbackUrl) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("FallbackUrl: ");
        __sb.Append(FallbackUrl);
      }
      if (LinkUrl != null && __isset.linkUrl) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("LinkUrl: ");
        __sb.Append(LinkUrl);
      }
      if (__isset.status) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Status: ");
        __sb.Append(Status);
      }
      if (Description != null && __isset.description) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Description: ");
        __sb.Append(Description.ToDebugString());
      }
      if (CustomData != null && __isset.customData) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("CustomData: ");
        __sb.Append(CustomData.ToDebugString());
      }
      if (__isset.updatedAt) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("UpdatedAt: ");
        __sb.Append(UpdatedAt);
      }
      if (Title != null && __isset.title) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Title: ");
        __sb.Append(Title.ToDebugString());
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}
#endif
