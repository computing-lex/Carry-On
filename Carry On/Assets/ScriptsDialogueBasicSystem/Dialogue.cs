using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textspeed;
    public float bufferSpeed;
    private int index;
    private AudioSource blip;

    [SerializeField]
    private TextAsset textDialogue;
    public string[] lines;

    // Start is called before the first frame update
    void Start()
    {
        ReadText();
        blip = GetComponent<AudioSource>();
        textComponent.text = string.Empty;
        startDialogue();

    }
    void ReadText()
    {
        lines = textDialogue.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
    }
// Update is called once per frame
void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (textComponent.text == lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void startDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
           
        //    yield return new WaitForSeconds(bufferSpeed);
            textComponent.text += c;
            blip.Play();
            yield return new WaitForSeconds(textspeed);
        }
    }
}
