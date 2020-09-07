using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public GameObject player;
    public GameObject restartButton;
    public GameObject gameOverText;
    //reload scene
    private void Start()
    {
        //restartButton.SetActive(true);
        //gameOverText.SetActive(true);
    }
    public void LoadMainScene() {
        SceneManager.LoadScene("Main");
    }
    private void Update()
    {
        if (player == null)
        {

            restartButton.SetActive(true);
            gameOverText.SetActive(true);

        }
    }


}
