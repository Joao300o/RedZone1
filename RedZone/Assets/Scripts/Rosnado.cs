using UnityEngine;
using System.Collections;

public class RosnادoMonstro : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip rosnado;

    public float tempoMin = 5f;
    public float tempoMax = 10f;

    void Start()
    {
        StartCoroutine(RosnarAleatorio());
    }

    IEnumerator RosnarAleatorio()
    {
        while (true)
        {
            float tempo = Random.Range(tempoMin, tempoMax);
            yield return new WaitForSeconds(tempo);
            
            if (rosnado != null)
                audioSource.PlayOneShot(rosnado);
        }
    }
}