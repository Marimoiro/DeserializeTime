using System;
using UnityEngine;
using System.Collections;

public class UnityJsonParser : ParserBase {
    public override string Serialize<T>(T obj)
    {
        var s = Environment.TickCount;
        var r = JsonUtility.ToJson(obj);
        SerializeTimeList.Add(Environment.TickCount - s);
        return r;
    }

    public override T Deserialize<T>(string text)
    {
        var s = Environment.TickCount;
        var r = JsonUtility.FromJson<T>(text);
        DeserializeTimeList.Add(Environment.TickCount - s);
        return r;
    }
}
