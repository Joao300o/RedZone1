using UnityEngine;
using System.Collections;

public class LuzPisca : MonoBehaviour
{
    public GameObject[] luzes;

    void Start()
    {
        StartCoroutine(Piscar());
    }

    IEnumerator Piscar()
    {
        while (true)
        {
            foreach (GameObject luz in luzes)
            {
                luz.SetActive(!luz.activeSelf);

            }

            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }


    }
}
