using UnityEngine;

public class AudioManager : MonoBehaviour
{
public void MudarVolume(float valor)
    {
        AudioListener.volume = valor;
    }
}
