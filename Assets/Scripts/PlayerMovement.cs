using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private new AudioSource audio;
    private int coletaveisRestantes;

    public float tempoLimite = 10f; // tempo em segundos
    private float tempoRestante;

    //public Text tempoText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

        coletaveisRestantes = GameObject.FindGameObjectsWithTag("Coletavel").Length;
        tempoRestante = tempoLimite;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }

    void Update()
    {
        // Atualiza o tempo restante
        tempoRestante -= Time.deltaTime;

        //tempoText.text = "Tempo: " + Mathf.CeilToInt(tempoRestante).ToString();

        if (tempoRestante <= 0f)
        {
            SceneManager.LoadScene(3); // Cena de DERROTA (3)
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            audio.Play();
            Destroy(other.gameObject);

            coletaveisRestantes--;

            if (coletaveisRestantes <= 0)
            {
                // Troca para a cena 2 (tela de vitória)
                SceneManager.LoadScene(2);
            }

        }
}
}
