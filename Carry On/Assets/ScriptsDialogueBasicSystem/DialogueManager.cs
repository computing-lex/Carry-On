using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using Ink.UnityIntegration;
using UnityEngine.EventSystems;
using UnityEditor;

public class DialogueManager : MonoBehaviour
{

    private static DialogueManager instance;

    [Header("Globals Ink File")]
    [SerializeField] private InkFile globalsInkFile;

    [SerializeField] private float typingSpeed = 0.04f;
    [SerializeField] private AudioSource blip;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;

    private DialogueVariables dialogueVariables;


    private Story currentStory;

    [SerializeField] public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("more then 1");
        }
        instance = this;

        dialogueVariables = new DialogueVariables(globalsInkFile.filePath);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            Debug.Log("Bruh");

        }

        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 &&
            Input.GetKeyDown(KeyCode.Space))
        {
            //InputManager.GetInstance().GetSubmitPressed()
            ContinueStory();
        }

        StartCoroutine(ChooseChoice());

    }

    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        Debug.Log("BruhTest");
        ContinueStory();

        dialogueVariables.StartListening(currentStory);
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

        dialogueVariables.StopListening(currentStory);

    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {

            StartCoroutine(TypeLine(currentStory.Continue()));

            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }


    private IEnumerator TypeLine(string line)
    {
        dialogueText.text = "";


        foreach (char c in line.ToCharArray())
        {

            dialogueText.text += c;
            blip.Play();
            yield return new WaitForSeconds(typingSpeed);

            canContinueToNextLine = false;
        }

        canContinueToNextLine = true;
    }


    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices then UI has: " + currentChoices.Count);
        }

        int index = 0;
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }


    }

    private IEnumerator ChooseChoice()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(SelectFirstChoice(0));
            yield return new WaitForSeconds(.05f);
            MakeChoice(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(SelectFirstChoice(1));
            yield return new WaitForSeconds(.05f);
            MakeChoice(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(SelectFirstChoice(2));
            yield return new WaitForSeconds(.05f);
            MakeChoice(2);
        }
    }

    private IEnumerator SelectFirstChoice(int index)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        
        EventSystem.current.SetSelectedGameObject(choices[index].gameObject);


    }


    public void MakeChoice(int choiceIndex)
    {

        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);

            ContinueStory();
        }
    }

}
