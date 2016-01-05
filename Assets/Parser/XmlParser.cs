using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Serialization;
using YamlDotNet.Serialization;

public class XmlParser : ParserBase {

    public override string Serialize<T>(T obj)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
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
        var xmlSerializer = new XmlSerializer(typeof(T));
        using (var r = new StringReader(text))
        {
            var s = Environment.TickCount;
            var ret = (T)xmlSerializer.Deserialize(r);
            DeserializeTimeList.Add(Environment.TickCount - s);
            return ret;
        }


    }
}
