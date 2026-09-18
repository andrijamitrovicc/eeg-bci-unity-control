using UnityEngine;

public class TextPulse : MonoBehaviour
{
    public float speed = 2f;
    public float amount = 0.1f;

    private Vector3 startScale;

    void Start()
    {
        startScale = transform.localScale;
    }

    void Update()
    {
        float scale =
            1f + Mathf.Sin(Time.time * speed) * amount;

        transform.localScale =
            startScale * scale;
    }
}