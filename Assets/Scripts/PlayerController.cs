using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public float sideSpeed = 6f;
    public float forwardSpeed = 3f;
    public float maxXPosition = 8f;

    public bool useLSLInput = false;
    public float lslHorizontalInput = 0f;

    public GameObject destroyEffect;

    private Rigidbody rb;
    private bool gameActive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        useLSLInput = false;
    }

    void FixedUpdate()
    {
        if (!gameActive)
            return;

        float horizontalInput;

        if (useLSLInput)
            horizontalInput = lslHorizontalInput;
        else
            horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(
            horizontalInput * sideSpeed,
            0f,
            forwardSpeed
        );

        rb.AddForce(movement, ForceMode.Force);

        rb.linearVelocity = Vector3.ClampMagnitude(
            rb.linearVelocity,
            8f
        );

        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(
            clampedPosition.x,
            -maxXPosition,
            maxXPosition
        );

        transform.position = clampedPosition;
    }

    public void SetLSLInput(float value)
    {
        lslHorizontalInput = Mathf.Clamp(value, -1f, 1f);
    }

    public void ToggleInputMode()
    {
        useLSLInput = !useLSLInput;

        if (useLSLInput)
            Debug.Log("Input Mode: LSL");
        else
            Debug.Log("Input Mode: Keyboard");
    }

    public void StopPlayer()
    {
        gameActive = false;

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    public void DestroyPlayer()
{
    StartCoroutine(DestroyAnimation());
}

IEnumerator DestroyAnimation()
{
    gameActive = false;

    if (destroyEffect != null)
    {
        Instantiate(
            destroyEffect,
            transform.position,
            Quaternion.identity
        );
    }

    rb.linearVelocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;

    Vector3 startScale = transform.localScale;
    Vector3 endScale = Vector3.zero;

    float duration = 0.7f;
    float timer = 0f;

    Renderer rend = GetComponent<Renderer>();

    Color originalColor = Color.green;

    if (rend != null)
    {
        originalColor = rend.material.color;
    }

    while (timer < duration)
    {
        timer += Time.deltaTime;

        float t = timer / duration;

        transform.localScale =
            Vector3.Lerp(startScale, endScale, t);

        if (rend != null)
        {
            rend.material.color =
                Color.Lerp(originalColor, Color.red, t);
        }

        yield return null;
    }

    gameObject.SetActive(false);
}
}