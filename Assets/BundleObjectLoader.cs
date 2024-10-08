using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundleObjectLoader : MonoBehaviour
{
    public string assetName = "BundledSpriteObject";
    public string bundleName = "testbundle";

    void Start()
    {
        AssetBundle localAssetBundle = AssetBundle.LoadFromFile(
            Path.Combine(Application.streamingAssetsPath, bundleName));
        if (localAssetBundle == null)
        {
            Debug.LogError("Failed to load AssetBundle");
            return;
        }
        GameObject asset = localAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
        localAssetBundle.Unload(false);
    }
}
