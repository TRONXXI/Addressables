using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement. AsyncOperations;
[System.Serializable]

public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid) : base(guid)
    {
    }
}


public class AddressableInstantiator : MonoBehaviour
{
    [SerializeField] AssetReferenceGameObject _environment;
    [SerializeField] AssetReferenceSprite _sprite;
    [SerializeField] AssetReferenceAudioClip _clip;

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {
            _environment.InstantiateAsync();
        }

        void OnAddressableLoaded(AsyncOperationHandle<GameObject> handle)
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
                Instantiate(handle.Result);
            else
                Debug.LogError("Loading Asset Failed!");
        }
    }
}