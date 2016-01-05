using UnityEngine;
using System.Collections;

public class SimpleObject : ScriptableObject
{
    public SimpleParams[] SimpleParamses;
}

public class SimpleArray
{
    public SimpleParams[] SimpleParams;

    public SimpleParams[] SimpleParamsProperty
    {
        get { return SimpleParams; }
        set { SimpleParams = value; }
    }
}
