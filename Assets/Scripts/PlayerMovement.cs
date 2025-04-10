using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private new AudioSource audio;
    private int coletaveisRestantes;
    public TextMeshProUGUI bananaText;


    //public Text textTempo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();

        coletaveisRestantes = GameObject.FindGameObjectsWithTag("Coletavel").Length;
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coletavel"))
        {
            audio.Play();
            Destroy(other.gameObject);

            coletaveisRestantes--;

            bananaText.text = "Bananas Restantes: " + Mathf.CeilToInt(coletaveisRestantes).ToString();

            if (coletaveisRestantes <= 0)
            {
                // Troca para a cena 2 (tela de vitória)
                SceneManager.LoadScene(2);
            }

        }
        else if (other.CompareTag("Inimigo"))
        {
            SceneManager.LoadScene(3); // Cena de derrota
        }

    }
}
