using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotateSpeed = 80f;
    public int scoreValue = 1;
    public GameObject pickupEffect;

    private bool collected = false;
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);

        float yOffset = Mathf.Sin(Time.time * 3f) * 0.2f;

        transform.position = new Vector3(
            transform.position.x,
            startY + yOffset,
            transform.position.z
        );
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected)
            return;

        if (other.CompareTag("Player"))
        {
            collected = true;

            GameManager gameManager = FindAnyObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.AddScore(scoreValue);
            }

            if (pickupEffect != null)
            {
                Instantiate(
                    pickupEffect,
                    transform.position,
                    Quaternion.identity
                );
            }

            Destroy(gameObject);
        }
    }
}