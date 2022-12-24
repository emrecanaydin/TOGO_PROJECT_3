using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public void RestartGame()
    {
        Scene gameScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(gameScene.name);
        Time.timeScale = 1;
    }
}
