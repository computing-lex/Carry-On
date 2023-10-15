using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandom : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private float minRot;
    [SerializeField] private float maxRot;
   

    void Awake()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[Mathf.FloorToInt(Random.Range(0,sprites.Count))];

        transform.Rotate(transform.rotation.x, transform.rotation.y, Random.Range(minRot, maxRot));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
