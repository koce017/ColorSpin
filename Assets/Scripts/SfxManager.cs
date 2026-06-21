using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance { get; private set; }

    private SfxLibrary sfxLibrary;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            sfxLibrary = GetComponent<SfxLibrary>();
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(string name)
    {
        var audioClip = sfxLibrary.GetClip(name);
        if (audioClip != null)
            audioSource.PlayOneShot(audioClip);
    }
}
