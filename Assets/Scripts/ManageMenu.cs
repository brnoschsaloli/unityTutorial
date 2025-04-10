using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ManageMenuFinal : MonoBehaviour
{

    public TextMeshProUGUI tempoText;
    public static float tempoFinal;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (tempoText != null)
        {
            tempoText.text = "Tempo: " + Mathf.CeilToInt(tempoFinal).ToString() + "s";
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void Instructions()
    {
        SceneManager.LoadSceneAsync(4);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
