using UnityEngine;

public class PlayerControllerBlue : MonoBehaviour
{
    public float verticalInput;
    public float speed = 10.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        verticalInput = Input.GetAxis("VerticalBlue");
        transform.Translate(Vector3.up * Time.deltaTime * speed * verticalInput);
        
    }
}
