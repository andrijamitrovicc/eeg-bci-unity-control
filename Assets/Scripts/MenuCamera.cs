using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    private Vector3 startPos;

    public float moveAmount = 0.5f;
    public float moveSpeed = 0.5f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position =
            startPos +
            new Vector3(
                Mathf.Sin(Time.time * moveSpeed) * moveAmount,
                0f,
                0f
            );
    }
}