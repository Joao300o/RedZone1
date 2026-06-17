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
    public int municaoReserva = 30;

    [Header("Tempo")]
    public float cooldown = 0.5f;
    public float tempoRecarga = 2f;

    public float rangeMax = 100f;

    float proximoTiro;
    bool recarregando = false;

    public TMP_Text meuTexto;
    public TMP_Text municaoAviso;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Atualiza HUD
        meuTexto.text = municaoAtual + " / " + municaoReserva;

        // Recarregar manual
        if (Input.GetKeyDown(KeyCode.R) &&
            municaoAtual < municaoMax &&
            municaoReserva > 0 &&
            !recarregando)
        {
            StartCoroutine(Recarregar());
        }

        // Se estiver recarregando, não pode atirar
        if (recarregando) return;

        // Atirar
        if (Input.GetMouseButtonDown(0) && Time.time >= proximoTiro)
        {
            if (municaoAtual > 0)
            {
                Atirar();
                municaoAtual--;

                proximoTiro = Time.time + cooldown;
            }
            else if (municaoReserva > 0 && !recarregando)
            {
                StartCoroutine(Recarregar());
            }
            else
            {
                StartCoroutine(MostrarAviso("Sem munição!", 2.5f));
            }

            IEnumerator MostrarAviso(string msg, float duracao)
            {
                municaoAviso.text = msg;
                municaoAviso.gameObject.SetActive(true);

                yield return new WaitForSeconds(duracao);

                municaoAviso.gameObject.SetActive(false);
            }
        }
    }

    void Atirar()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        int layerMask = LayerMask.GetMask("inimigo");

        if (Physics.Raycast(ray, out hit, rangeMax, layerMask))
        {
            Debug.Log(hit.transform.name);

            VidaInimigo inimigo = hit.transform.GetComponentInParent<VidaInimigo>();

            if (inimigo != null)
            {
                inimigo.TomarDano(dano);
            }
        }
        animator.SetBool("atirando", true);

        Invoke("PararTiro", 0.3f);
    }

    void PararTiro()
    {
        animator.SetBool("atirando", false);
    }

    IEnumerator Recarregar()
    {
        recarregando = true;
        Debug.Log("Recarregando...");

        yield return new WaitForSeconds(tempoRecarga);

        int balasNecessarias = municaoMax - municaoAtual;

        if (municaoReserva >= balasNecessarias)
        {
            municaoAtual = municaoMax;
            municaoReserva -= balasNecessarias;
        }
        else
        {
            municaoAtual += municaoReserva;
            municaoReserva = 0;
        }

        recarregando = false;
    }

    public void Municao(int municao)
    {
        municaoReserva += municao;
    }
}