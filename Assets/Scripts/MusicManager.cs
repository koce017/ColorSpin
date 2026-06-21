using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    [SerializeField] private AudioClip[] tracks;

    private int currentSong = -1;
    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
     }

    private void Start()
    {
        PlayNextTrack();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
            PlayNextTrack();
    }

    private void PlayNextTrack()
    {
        currentSong = (currentSong + 1) % tracks.Length;
        audioSource.clip = tracks[currentSong];
        audioSource.Play();
    }
}
