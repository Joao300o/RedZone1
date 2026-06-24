using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [Header("Áudios do jogo")]
    public AudioSource audioSource;
    public AudioClip coletavel;

    public void MudarVolume(float valor)
    {
        AudioListener.volume = valor;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TocarSom(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        if (clip != null)
        {
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
