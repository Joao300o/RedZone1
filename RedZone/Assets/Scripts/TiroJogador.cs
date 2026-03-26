using UnityEngine;
using System.Collections;
using TMPro;

public class TiroJogador : MonoBehaviour
{
    RaycastHit hit;

    [Header("Dano")]
    public int dano = 10;

    [Header("Munição")]
    public int municaoAtual = 10;
    public int municaoMax = 10;

    [Header("Tempo")]
    public float cooldown = 0.5f;     // tempo entre tiros
    public float tempoRecarga = 2f;   // tempo de reload

    float proximoTiro;
    bool recarregando = false;

    public TMP_Text meuTexto;

    void Update()
    {
    if (Input.GetKeyDown(KeyCode.R) && municaoAtual < municaoMax && !recarregando)
        {
            StartCoroutine(Recarregar());
        }
        // se estiver recarregando, não faz nada
        if (recarregando) return;

        if (Input.GetMouseButtonDown(0) && Time.time >= proximoTiro)
        {
            if (municaoAtual > 0)
            {
                Atirar();
                municaoAtual--;

                proximoTiro = Time.time + cooldown;
            }
            else
            {
                StartCoroutine(Recarregar());
            }
        }

        meuTexto.text = municaoAtual.ToString();
    }

    void Atirar()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 100f))
        {
            Debug.Log(hit.transform.name);

            VidaInimigo inimigo = hit.transform.GetComponent<VidaInimigo>();

            if (inimigo != null)
            {
                inimigo.TomarDano(dano);
            }
        }
    }

    IEnumerator Recarregar()
    {
        recarregando = true;
        Debug.Log("Recarregando...");

        yield return new WaitForSeconds(tempoRecarga);

        municaoAtual = municaoMax;
        recarregando = false;
    }

    public void Municao(int municao)
    {
        municaoAtual += municao;
        if (municaoAtual > municaoMax)
            municaoAtual = municaoMax;
    }
}