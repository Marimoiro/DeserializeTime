using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class NestParams
{
    public SimpleParams Params;
    public SimpleParams SimpleProperty {get { return Params; }set { Params = value; } }

    public string Message;
    public string MessageProperty { get { return Message; } set { Message = value; } }

    public override bool Equals(object obj)
    {
        return Equals(obj as NestParams);
    }

    protected bool Equals(NestParams other)
    {
        if (other == null) return false;
        return Equals(Params, other.Params) && string.Equals(Message, other.Message);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return ((Params != null ? Params.GetHashCode() : 0)*397) ^ (Message != null ? Message.GetHashCode() : 0);
        }
    }
}


public class NestArray
{
    public NestParams[] NestParams;

    public NestParams[] NestParamsProperty
    {
        get { return NestParams; }
        set { NestParams = value; }
    }
}

