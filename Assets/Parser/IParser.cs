using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

public interface IParser
{
    IList<int> SerializeTimeList { get; }
    IList<int> DeserializeTimeList { get; }

    string Serialize<T>(T obj);
    T Deserialize<T>(string text);
}

public class ParserBase : MonoBehaviour,IParser
{
    private readonly IList<int> serializeTimeList = new List<int>();
    private readonly IList<int> deserializeTimeList = new List<int>();

    public IList<int> SerializeTimeList
    {
        get { return serializeTimeList; }
    }

    public IList<int> DeserializeTimeList
    {
        get { return deserializeTimeList; }
    }

    public virtual string Serialize<T>(T obj)
    {
        throw new System.NotImplementedException();
    }

    public virtual T Deserialize<T>(string text)
    {
        throw new System.NotImplementedException();
    }
}