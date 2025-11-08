using UnityEngine;

public class BlueGoalScript : MonoBehaviour
{
    public PuckMovement gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Puck"))
        {
            Debug.Log("Hit Goal Post");
            gameManager.BlueRestart();
        }
    }
}
