using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{
    // Object to instantiate
    [SerializeField] private GameObject trash;

    // Alter the wave shape
    [SerializeField] private int[] sinAlt = new int[4];
    [SerializeField] private float amplitude;
    [SerializeField] private float offset;

    // Control points
    public GameObject spawnPoint;
    public GameObject killPoint;

    // Randomization control
    [SerializeField] private float zOffset;
    [SerializeField] private float generationSpacing = 1f;

    private float lastGeneration;

    // Start is called before the first frame update
    void Start()
    {
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
        float trashHeight = WaveformGeneration(x);          // Get height from waveform
        int numObjects = Mathf.RoundToInt(trashHeight * 5); // Decide on trash count based on height

        // Iterate through the potential objects
        for (int i=0; i<numObjects; i++)
        {
            float trashX = Random.Range(x - (generationSpacing / 2), x + (generationSpacing / 2));      // Randomize x within the gap
            float trashY = Random.Range(0, trashHeight);                                                // Randomize y below trashHeight

            Vector3 location = new Vector3(trashX, trashY, Random.Range(0f + zOffset, -2f + zOffset));  // Generate a Vector3 
            
            var newObj = Instantiate<GameObject>(trash, location, Quaternion.identity);
            newObj.tag = "bg";
        }
    }

    // Returns y based on a sin function
    float WaveformGeneration(float x)
    {
        float y = Mathf.Sin(x/sinAlt[0]) + Mathf.Sin(x / sinAlt[1]) + Mathf.Sin(x / sinAlt[2]) + Mathf.Sin(x / sinAlt[3]);
        y += offset;
        y /= amplitude;

        return y;
    }
}
