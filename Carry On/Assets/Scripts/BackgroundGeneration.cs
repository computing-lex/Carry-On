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

    private Transform oldLocation;

    // Start is called before the first frame update
    void Start()
    {
        oldLocation = spawnPoint.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if ((spawnPoint.transform.position.x - oldLocation.position.x) == spacing)
        {
            float yLoc = WaveformGeneration(spawnPoint.transform.position.x);

            oldLocation = spawnPoint.transform;
            Vector3 location = new Vector3(oldLocation.position.x, yLoc, oldLocation.position.z);

            Instantiate<GameObject>(obj, location, Quaternion.identity);

            Debug.Log("Point generated!");
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
