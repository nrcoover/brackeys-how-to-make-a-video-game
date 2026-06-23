using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movement;
    [SerializeField] private GameObject player;
    //public GameManager gameManager;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle") 
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
            player.SetActive(false);
        }

        //if (collisionInfo.collider.tag == "EndLevel")
        //{
        //    movement.enabled = false;
        //    gameManager.CompleteLevel();
        //    Debug.Log("THIS IS IT!");
        //}
    }
}
