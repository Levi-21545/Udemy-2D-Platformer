using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;
    private int currentPoint;

    public Transform platform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < points.Length; i++)
        {
            points[i].parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(platform.position, points[currentPoint].position) < .05f)
        {
            currentPoint++;

            if (currentPoint >= points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
