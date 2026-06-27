using UnityEngine;

public class ConfiguracaoJogo : MonoBehaviour
{
    public static void SalvarVolume(float valor)
    {
        PlayerPrefs.SetFloat("volume", valor);
        PlayerPrefs.Save();
    }

    public static void SalvarSensi(float valor)
    {
        PlayerPrefs.SetFloat("sensi", valor);
        PlayerPrefs.Save();
    }

    public static float CarregarVolume()
    {
        return PlayerPrefs.GetFloat("volume", 100f); // 100 é o valor padrão
    }

    public static float CarregarSensi()
    {
        return PlayerPrefs.GetFloat("sensi", 2f); // 2 é o valor padrão
    }
}