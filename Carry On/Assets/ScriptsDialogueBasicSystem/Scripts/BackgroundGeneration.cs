using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float offset;
    [SerializeField] private float spacing;
    [SerializeField] private GameObject obj;

    public GameObject spawnPoint;
    public GameObject killPoint;

    [SerializeField] private const float generationSpacing = 1f;
    private float lastGeneration;

    private Transform oldLocation;
    private Vector3[] positions;
    private LineRenderer path;
    [SerializeField] private int count;
    [SerializeField] private int maxCount;

    // Start is called before the first frame update
    void Start()
    {
        oldLocation = spawnPoint.transform;
        lastGeneration = killPoint.transform.position.x;
    }


    // Update is called once per frame
    void Update()
    {
        while (lastGeneration + generationSpacing < spawnPoint.transform.position.x)
        {
            generateObjects(lastGeneration + generationSpacing);
            lastGeneration += generationSpacing;
        }
    }

    void generateObjects(float x)
    {
        float trashHeight = WaveformGeneration(x);
        int numObjects = Mathf.RoundToInt(trashHeight * 5);
        for (int i=0; i<numObjects; i++)
        {
            float trashX = Random.Range(x - (generationSpacing / 2), x + (generationSpacing / 2));
            float trashY = Random.Range(0, trashHeight);
            Vector3 location = new Vector3(trashX, trashY, spawnPoint.transform.position.z);
            Instantiate<GameObject>(obj, location, Quaternion.identity);
        }
    }

    float WaveformGeneration(float x)
    {
        float y = Mathf.Sin(x/3) + Mathf.Sin(x / 5) + Mathf.Sin(x / 7) + Mathf.Sin(x / 9);
        y += offset;
        y /= amplitude;

        return y;
    }
}
