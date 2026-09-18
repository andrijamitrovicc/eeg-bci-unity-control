using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotateSpeed = 20f;

    void Update()
    {
        transform.Rotate(
            0f,
            rotateSpeed * Time.deltaTime,
            0f
        );
    }
}