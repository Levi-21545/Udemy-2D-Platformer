using System.Numerics;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;

    private Checkpoint[] checkpoints;

    public UnityEngine.Vector3 spawnPoint;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkpoints = FindObjectsByType(typeof(Checkpoint), FindObjectsSortMode.None) as Checkpoint[];
        spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DeactivateCheckpoints()
    {
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i].ResetCheckpoint();
        }
    }

    public void SetSpawnPoint(UnityEngine.Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }
}
