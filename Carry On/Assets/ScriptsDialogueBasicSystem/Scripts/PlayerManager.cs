using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Animator myAnimator;
    [SerializeField] private GameObject root;
    [SerializeField] private float speed;

    public int days;
    public bool eventActive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!eventActive)
        {
            root.transform.position = new Vector3(root.transform.position.x + (speed * Time.deltaTime), root.transform.position.y, root.transform.position.z);
        }
    }

   
}
