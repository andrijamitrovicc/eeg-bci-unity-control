using UnityEngine;
using LSL;

public class LSLBallInput : MonoBehaviour
{
    [Header("LSL Stream Settings")]
    public string streamName = "NeuroDriveCommand";

    [Header("References")]
    public PlayerController playerController;

    [Header("Command Settings")]
    [Range(0f, 1f)]
    public float threshold = 0.5f;

    private StreamInlet inlet;
    private float[] sample;

    void Start()
    {
        if (playerController == null)
        {
            playerController = FindAnyObjectByType<PlayerController>();
        }

        if (playerController == null)
        {
            Debug.LogError("PlayerController nije pronađen.");
            return;
        }

        playerController.useLSLInput = true;

        Debug.Log("Searching for LSL stream: " + streamName);

        StreamInfo[] results =
            LSL.LSL.resolve_stream("name", streamName, 1, 2.0);

        if (results.Length > 0)
        {
            inlet = new StreamInlet(results[0]);

            int channelCount = inlet.info().channel_count();
            sample = new float[channelCount];

            Debug.Log("LSL stream connected: " + streamName);
            Debug.Log("LSL channel count: " + channelCount);
        }
        else
        {
            Debug.LogWarning("LSL stream not found: " + streamName);
        }
    }

    void Update()
    {
        if (inlet == null || playerController == null || sample == null)
        {
            return;
        }

        double timestamp = inlet.pull_sample(sample, 0.0);

        if (timestamp == 0.0)
        {
            return;
        }

        // Koristimo prvi kanal iz OpenViBE LSL stream-a.
        float value = sample[0];

        Debug.Log("LSL received value: " + value);

        float horizontalValue;

        if (value < threshold)
        {
            horizontalValue = -1f;
            Debug.Log("LSL command: LEFT");
        }
        else
        {
            horizontalValue = 1f;
            Debug.Log("LSL command: RIGHT");
        }

        playerController.SetLSLInput(horizontalValue);
    }

    void OnDestroy()
    {
        if (inlet != null)
        {
            inlet.close_stream();
            inlet = null;
        }
    }
}