using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageMenuFinal : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
