using System.Collections;
using UnityEngine;

public class PlayerMagnet : MonoBehaviour
{
    public float magnetDuration = 5f;
    public float magnetRadius = 8f;
    public float magnetForce = 12f;

    private bool magnetActive = false;

    public void ActivateMagnet()
    {
        StopAllCoroutines();
        StartCoroutine(MagnetRoutine());
    }

    IEnumerator MagnetRoutine()
    {
        magnetActive = true;

        yield return new WaitForSeconds(magnetDuration);

        magnetActive = false;
    }

    void Update()
    {
        if (!magnetActive)
            return;

        Collider[] nearbyObjects = Physics.OverlapSphere(
            transform.position,
            magnetRadius
        );

        foreach (Collider col in nearbyObjects)
        {
            if (col.CompareTag("Collectible"))
            {
                col.transform.position = Vector3.MoveTowards(
                    col.transform.position,
                    transform.position,
                    magnetForce * Time.deltaTime
                );
            }
        }
    }
}