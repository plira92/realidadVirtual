using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movements : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject canvasParent;
    public GameObject buttonIncorrect;

    private string[] actions = {"Saltar", "Caminar", "Correr", "Atacar", "Morir"};
    private int index;
    private string nameAction;
    private GameObject actualButton;



    // Start is called before the first frame update
    void Start()
    {
        //Init all values in 0
        for (int i=0 ; i<4; i++)
        {
            this.GetComponent<Animator>().SetBool(actions[i],false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        buttonIncorrect.GetComponent<Button>().onClick.AddListener(Morir);

        if(actualButton != null)
        {
            //OnClick function
            actualButton.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        }        
        else
        {
            //Random number
            index = UnityEngine.Random.Range(0,4);

            //Action name
            nameAction = actions[index];

            //Instance of a button object
            actualButton = Instantiate(buttonPrefab);

            InstantiatePrefab(nameAction, actualButton);
        }
    }

    void InstantiatePrefab(string action, GameObject button)
    {
        button.transform.SetParent(canvasParent.transform, false);

        button.GetComponentInChildren<Text>().text = action;
    }

    private void TaskOnClick()
    {
        this.GetComponent<Animator>().SetBool(nameAction, true);
        Destroy(actualButton, 1.0f);
    }

    private void Morir()
    {
        this.GetComponent<Animator>().SetBool("Morir", true);
    }
}
