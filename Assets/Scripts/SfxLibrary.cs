using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct SoundEffectGroup
{
    public string name;
    public List<AudioClip> clips;
}

public class SfxLibrary : MonoBehaviour
{
    [SerializeField] private SoundEffectGroup[] soundEffectGroups;

    private Dictionary<string, List<AudioClip>> soundDictionary = new();

    private void Awake()
    {
        foreach (var soundEffectGroup in soundEffectGroups)
        {
            soundDictionary[soundEffectGroup.name] = soundEffectGroup.clips;
        }
    }

    public AudioClip GetClip(string name)
    {
        if (soundDictionary.ContainsKey(name))
        {
            var audioClips = soundDictionary[name];
            
            if (audioClips.Count > 0)
            {
                return audioClips[Random.Range(0, audioClips.Count)];
            }
        }
        return null;
    }
}
