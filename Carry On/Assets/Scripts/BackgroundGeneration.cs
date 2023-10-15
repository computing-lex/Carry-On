using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGeneration : MonoBehaviour
{
    [SerializeField] private float amplitude;
    [SerializeField] private float offset;
    [SerializeField] private GameObject obj;
    [SerializeField] private float zOffset;
    [SerializeField] private int[] sinAlt = new int[4];


    public GameObject spawnPoint;
    public GameObject killPoint;

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
        float trashHeight = WaveformGeneration(x);
        int numObjects = Mathf.RoundToInt(trashHeight * 5);
        for (int i=0; i<numObjects; i++)
        {
            float trashX = Random.Range(x - (generationSpacing / 2), x + (generationSpacing / 2));
            float trashY = Random.Range(0, trashHeight);
            Vector3 location = new Vector3(trashX, trashY, Random.Range(0f + zOffset, -2f + zOffset));
            var newObj = Instantiate<GameObject>(obj, location, Quaternion.identity);
            newObj.tag = "bg";
        }
    }

    float WaveformGeneration(float x)
    {
        float y = Mathf.Sin(x/sinAlt[0]) + Mathf.Sin(x / sinAlt[1]) + Mathf.Sin(x / sinAlt[2]) + Mathf.Sin(x / sinAlt[3]);
        y += offset;
        y /= amplitude;

        return y;
    }
}
