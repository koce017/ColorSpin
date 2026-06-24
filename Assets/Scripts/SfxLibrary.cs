using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct SoundEffectGroup
{
    public string name;
    public AudioClip clip;
}

public class SfxLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;

    private Dictionary<string, AudioClip> soundDictionary = new();

    private void Awake()
    {
        foreach (var soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.clip;
        }
    }

    public AudioClip GetClip(string name)
    {
        return soundDictionary.GetValueOrDefault(name);
    }
}
