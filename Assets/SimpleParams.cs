using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class SimpleParams
{ 
    public int X;

    public int XProperty
    {
        get { return X; }
        set { X = value; }
    }


    public double Y;
    public double YProperty
    {
        get { return Y; }
        set { Y = value; }
    }

    public string Message;

    public string MessageProperty
    {
        get { return Message; }
        set { Message = value; }
    }

    public override bool Equals(object obj)
    {
        var o = obj as SimpleParams;
        if (o == null) return false;
        return Equals(o);
    }

    protected bool Equals(SimpleParams other)
    {
        return X == other.X && Math.Abs(Y - other.Y) < 0.001 && string.Equals(Message, other.Message);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = X;
            hashCode = (hashCode*397) ^ (Message != null ? Message.Length : 0);
            return hashCode;
        }
    }
}
