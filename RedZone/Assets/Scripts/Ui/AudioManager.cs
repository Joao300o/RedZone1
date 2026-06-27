using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [Header("Áudios do jogo")]
    public AudioSource audioSource;
    public AudioSource audioSourceSecundario;
    public AudioSource audioSourcePassos;
    public AudioClip coletavel;

    public void MudarVolume(float valor)
    {
        AudioListener.volume = valor;


    }

    private void Awake()
    {
        AudioSource[] sources = GetComponents<AudioSource>();
        audioSource = sources[0];
        audioSourcePassos = sources[1];
        audioSourceSecundario = sources[2];
    }

    public void TocarSom(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        if (clip != null)
        {
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(clip, volume);
        }
    }
        public void TocarSomSecundarios(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        if (clip != null)
        {
            audioSourceSecundario.pitch = pitch;
            audioSourceSecundario.PlayOneShot(clip, volume);
        }
    }

    public void TocarPassos(AudioClip clip, float volume = 1f, float pitch = 1f)
    {
        if (clip != null && !audioSourcePassos.isPlaying)
        {
            audioSourcePassos.clip = clip;
            audioSourcePassos.volume = volume;
            audioSourcePassos.pitch = pitch;
            audioSourcePassos.loop = true;
            audioSourcePassos.Play();

        }
    }
    public void PararPassos()
    {
        audioSourcePassos.Stop();
    }
}
