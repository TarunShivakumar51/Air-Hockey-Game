using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem.Controls; // needed for IEnumerator and WaitForSeconds

public class PuckMovement : MonoBehaviour
{
    [Header("Puck Settings")]
    public float speed = 8.0f;
    public float elapsedTime = 0.0f;
    public float increaseTime = 5.0f;
    public float pauseDuration = 1.5f; // how long to pause before relaunch

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.linearDamping = 0f;
        rb.angularDamping = 0f;
        rb.freezeRotation = true;

        LaunchPuck();
    }

    public void BlueRestart()
    {
        speed = 8.0f;
        elapsedTime = 0.0f;
        increaseTime = 5.0f;

        float x = 1.3f;
        float y = -0.63f;
        transform.position = new Vector3(x, y, 0);

        // Stop current motion
        rb.linearVelocity = Vector2.zero;

        // Wait, then launch
        StartCoroutine(RestartAfterPause(isBlue: true));
    }

    public void RedRestart()
    {
        speed = 8.0f;
        elapsedTime = 0.0f;
        increaseTime = 5.0f;

        float x = 1.3f;
        float y = -0.63f;
        transform.position = new Vector3(x, y, 0);

        // Stop current motion
        rb.linearVelocity = Vector2.zero;

        // Wait, then launch
        StartCoroutine(RestartAfterPause(isBlue: false));
    }

    private IEnumerator RestartAfterPause(bool isBlue)
    {
        yield return new WaitForSeconds(pauseDuration);

        if (isBlue)
            LaunchBluePuck();
        else
            LaunchRedPuck();
    }

    void LaunchBluePuck()
    {
        float angle = Random.Range(135f, 225f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
        rb.linearVelocity = direction * speed;
    }

    void LaunchRedPuck()
    {
        float angle = Random.Range(-45f, 45f);
        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
        rb.linearVelocity = direction * speed;
    }

    void LaunchPuck()
    {
        float angle = Random.Range(-45f, 45f);
        if (Random.value < 0.5f)
            angle += 180f;

        Vector2 direction = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
        rb.linearVelocity = direction * speed;
    }

    void FixedUpdate()
    {

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= increaseTime)
        {
            speed = speed + 0.5f;
            increaseTime = increaseTime + 5;
        }

        if (rb.linearVelocity.sqrMagnitude > 0.001f)
            rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }
}
