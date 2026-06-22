using UnityEngine;

public class AudioManager : MonoBehaviour
{
public static AudioManager instancia;
    public AudioSource audioSource;
    public  AudioClip somTiro;

    public void MudarVolume(float valor)
    {
        AudioListener.volume = valor;
    }

    private void Awake()
    {
        instancia = this;
    }

    public void SomTiro(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
