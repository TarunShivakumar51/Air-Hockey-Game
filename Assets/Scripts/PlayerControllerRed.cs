using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControllerRed : MonoBehaviour
{
    // public float verticalInput;
    public float speed = 10.0f;
    public GameObject puck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        float puckPos = puck.transform.position.y;

        float currectPos = transform.position.y;

        float newY = currectPos + (puckPos - currectPos) * (speed * Time.deltaTime);

        
        float num = 1.94f;
        float num2 = -3.072263f;

        if (transform.position.y > num)
        {
            transform.position = new Vector2(transform.position.x, num);
        }
        if (transform.position.y < num2)
        {
            transform.position = new Vector2(transform.position.x, num2);
        }

        // verticalInput = Input.GetAxis("VerticalRed");
          transform.position = new Vector3(9.78f, newY, 0);
        
    }
}
