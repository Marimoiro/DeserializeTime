using System;
using UnityEngine;
using System.Collections;

public class JsonFxParser : ParserBase {


    public override string Serialize<T>(T obj)
    {

        var w = new JsonFx.Json.JsonWriter();
        var s = Environment.TickCount;
        var r = w.Write(obj);
        SerializeTimeList.Add(Environment.TickCount - s);
        return r;

    }

    public override T Deserialize<T>(string text)
    {
        var r = new JsonFx.Json.JsonReader();
        var s = Environment.TickCount;
        var ret = r.Read<T>(text);
        DeserializeTimeList.Add(Environment.TickCount - s);
        return ret;
    }
}
