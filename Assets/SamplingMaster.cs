using System;
using UnityEngine;
using System.Collections;
using System.Linq;

public class SamplingMaster : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
        //ScriptableObjectだけ
	    var start = Environment.TickCount;
	    var simples = new SimpleArray() {SimpleParams = Resources.Load<SimpleObject>("simples").SimpleParamses};
	    var sl = Environment.TickCount - start;

        start = Environment.TickCount;
	    var nest = new NestArray() {NestParams = Resources.Load<NestObject>("nests").NestParams};
	    var nl = Environment.TickCount - start;
	    OutputData(typeof (ScriptableObject), sl, nl, 0, 0);

        
	    var parsers = GetComponents<IParser>();
	    foreach (var parser in parsers)
	    {
	        var sText = parser.Serialize(simples);

	        var nText = parser.Serialize(nest);

	        var sObj = parser.Deserialize<SimpleArray>(sText);

	        var nObj = parser.Deserialize<NestArray>(nText);

	        OutputData(parser.GetType(), parser.DeserializeTimeList[0], parser.DeserializeTimeList[1], parser.SerializeTimeList[0], parser.SerializeTimeList[1]);
            ValidSimpleParams(simples,sObj);
            ValidNestParams(nest,nObj);
	    }
	}

    void OutputData(Type parserType, int simpleLoadTime, int nestLoadTime, int simpleWriteTime, int nestWriteTime)
    {
        Debug.LogFormat("{0} \r\n シリアライズ\r\n  Simple:{1}ms \r\n  Nest:{2}ms \r\n デシリアライズ\r\n  Simple:{3}ms \r\n  Nest:{4}ms",
            parserType, simpleWriteTime, nestWriteTime, simpleLoadTime, nestLoadTime);
    }

    void ValidSimpleParams(SimpleArray expect,SimpleArray actual)
    {
        var err = expect.SimpleParams.Select((e, n) => new {E = e, A = actual.SimpleParams[n],N = n}).FirstOrDefault(p => !p.E.Equals(p.A));
        if (err == null)
        {
            Debug.Log("Valid OK[Simple]");
        }
        else
        {
            Debug.Log("Error");
        }
    }


    void ValidNestParams(NestArray expect, NestArray actual)
    {
        var err = expect.NestParams.Select((e, n) => new { E = e, A = actual.NestParams[n], N = n }).FirstOrDefault(p => !p.E.Equals(p.A));
        if (err == null)
        {
            Debug.Log("Valid OK[Nest]");
        }
        else
        {
            Debug.Log("Error");
        }
    }

}
