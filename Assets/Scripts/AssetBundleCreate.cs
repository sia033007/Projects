using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetBundleCreate : Editor
{
    [MenuItem("Assets/Create AssetBundle")]
    static void CreateAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(@"C:\Users\amink\Desktop\AssetBundle",BuildAssetBundleOptions.ChunkBasedCompression,BuildTarget.StandaloneWindows64);
    }
}
