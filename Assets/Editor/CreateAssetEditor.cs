using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEditor;

public class CreateAssetEditor : MonoBehaviour
{

    const int Samples = 10000;
    [MenuItem("Assets/Create/SampleObjects")]
    static void CreateSampleAsset()
    {
        var simples = new int[Samples].Select(_ => new SimpleParams()
        {
            Message = "TestMessage",
            X = Random.Range(0, 10000),
            Y = Random.Range(0, 1f)
        }).ToArray();
        var nests = simples.Select(s => new NestParams() {Message = "NestParam", Params = s}).ToArray();

        var sa = ScriptableObject.CreateInstance<SimpleObject>();
        sa.SimpleParamses = simples;
        AssetDatabase.CreateAsset(sa,"Assets/Resources/simples.asset");

        var na = ScriptableObject.CreateInstance<NestObject>();
        na.NestParams = nests;
        AssetDatabase.CreateAsset(na, "Assets/Resources/nests.asset");

        AssetDatabase.SaveAssets();
    }
}
