using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

public class YamlParser : ParserBase {

    public override string Serialize<T>(T obj)
    {
        Serializer serializer = new YamlDotNet.Serialization.Serializer();
        using (var r = new StringWriter())
        {
            var s = Environment.TickCount;
            serializer.Serialize(r, obj);
            SerializeTimeList.Add(Environment.TickCount - s);
            return r.GetStringBuilder().ToString();
        }
    }

    public override T Deserialize<T>(string text)
    {
        Deserializer deserializer = new Deserializer();
        using (var r = new StringReader(text))
        {
            var s = Environment.TickCount;
            T ret = deserializer.Deserialize<T>(r);
            DeserializeTimeList.Add(Environment.TickCount - s);
            return ret;
        }
    }
}
