using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    //public GameManager gameManager;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") 
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }

        //if (collisionInfo.collider.tag == "EndLevel")
        //{
        //    movement.enabled = false;
        //    gameManager.CompleteLevel();
        //    Debug.Log("THIS IS IT!");
        //}
    }
}
