using UnityEngine;

public class InimigoPerseguidor : MonoBehaviour
{
    private Transform alvo; // Referência ao macaco

    public float velocidadeMin = 1f; // velocidade quando o tempo está cheio
    public float velocidadeMax = 8f; // velocidade quando o tempo está no fim

    private GameManager gameManager;


    void Start()
    {
        // Procurar o objeto com a tag Player
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void Update()
    {
        if (alvo != null && gameManager != null)
        {
            float tempoRestante = gameManager.TempoRestante();
            float tempoTotal = gameManager.tempoLimite;

            float velocidadeAtual = Mathf.Lerp(velocidadeMax, velocidadeMin, tempoRestante / tempoTotal);

            Vector3 direcao = (alvo.position - transform.position).normalized;
            transform.position += direcao * velocidadeAtual * Time.deltaTime;
        }
    }

}
