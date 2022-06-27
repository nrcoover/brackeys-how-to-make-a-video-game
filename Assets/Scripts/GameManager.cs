using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;
    public void EndGame()
    {
        if (gameHasEnded == false) 
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER!");
            Invoke("RestartGame", restartDelay);
        }
    }

    public void CompleteLevel()
    {
        completeLevelUI.SetActive(true);
        Debug.Log("hahahah");
    }

    void RestartGame()
    {
        if (gameHasEnded)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
