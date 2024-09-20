using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BundledLoaderAsync : MonoBehaviour
{
    public string bundleName;
    public string assetName;
    IEnumerator Start()
    {
        AssetBundleCreateRequest asyncBundleRequest = AssetBundle.LoadFromFileAsync(
            Path.Combine(Application.streamingAssetsPath, bundleName));
        yield return asyncBundleRequest;

        AssetBundle localAssetBundle = asyncBundleRequest.assetBundle;

        if (localAssetBundle == null)
        {
            Debug.LogError("failed to load AssetBundle!");
            yield break;
        }
        AssetBundleRequest assetRequest =
            localAssetBundle.LoadAssetAsync<GameObject>(assetName);
        yield return assetRequest;

        GameObject prefab = localAssetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(prefab);
        localAssetBundle.Unload(false);
    }

}
