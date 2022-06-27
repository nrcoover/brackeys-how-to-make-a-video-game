using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;
    public void EndGame()
    {
        if (gameHasEnded == false) 
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER!");
            Invoke("RestartGame", restartDelay);
        }
    }

    void RestartGame()
    {
        if (gameHasEnded)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
