using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float tempoLimite = 30f;
    private float tempoRestante;

    public TextMeshProUGUI tempoText;

    void Start()
    {
        tempoRestante = tempoLimite;
    }

    public float TempoRestante()
    {
        return tempoRestante;
    }

    void Update()
    {
        ManageMenuFinal.tempoFinal = 30 - tempoRestante;
        if (tempoRestante > 0f)
        {
            tempoRestante -= Time.deltaTime;
            tempoText.text = "Tempo: " + Mathf.CeilToInt(tempoRestante).ToString();

            if (tempoRestante <= 0f)
            {

                // Exemplo: mudar para a cena de derrota
                SceneManager.LoadScene(3); // Troque pelo índice correto da sua cena
            }
        }
    }
}
