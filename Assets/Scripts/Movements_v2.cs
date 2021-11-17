using UnityEngine;

public class Movements_v2 : MonoBehaviour
{
    public GameObject walkButton;
    public GameObject runButton;
    public GameObject atackButton;
    public GameObject jumpButton;

    private GameObject actualButton;

    private string[] actions = {"Walk", "Run", "Attack", "Jump", "Die"};
    private int index;
    private string nameAction;

    // Start is called before the first frame update
    void Start()
    {
        //Init all values in 0
        for (int i=0 ; i<4; i++)
        {
            this.GetComponent<Animator>().SetBool(actions[i],false);
        }
    }

    // Detects if the shift key was pressed
    void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent("a")))
        {
            if (walkButton.activeSelf)
            {
                Debug.Log("a key pressed");
                walkButton.SetActive(false);
                this.GetComponent<Animator>().SetBool("Walk",true);
            }
        }
        else if(Event.current.Equals(Event.KeyboardEvent("s")))
        {
            if (runButton.activeSelf)
            {
                this.GetComponent<Animator>().SetBool("Run",true);
                runButton.SetActive(false);
            }
        }
        else if(Event.current.Equals(Event.KeyboardEvent("d")))
        {
            if (atackButton.activeSelf)
            {
                this.GetComponent<Animator>().SetBool("Attack",true);
                atackButton.SetActive(false);
            }
        }
        else if(Event.current.Equals(Event.KeyboardEvent("f")))
        {
            if (jumpButton.activeSelf)
            {
                this.GetComponent<Animator>().SetBool("Jump",true);
                jumpButton.SetActive(false);
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        /*
        incorrectButton.GetComponent<GameObject>().onClick.AddListener(Die);

        if (actualButton != null)
        {
            // OnClick function
            actualButton.GetComponent<GameObject>().onClick.AddListener(TaskOnClick);
        }
        else
        {
            */
            
            //Random number
            index = UnityEngine.Random.Range(0,4);

            nameAction = actions[index];

            switch(index)
            {
                case 0:
                {
                    actualButton = walkButton;
                    break;
                }
                case 1:
                {
                    actualButton = runButton;
                    break;
                }
                case 2:
                {
                    actualButton = atackButton;
                    break;
                }
                case 3:
                {
                    actualButton = jumpButton;
                    break;
                }
            }

            if (!actualButton.activeSelf && !(isMoreThanOneElementActive()) && !isAnimationInProgress())
            {
                actualButton.SetActive(true);
            }
        //}
    }


    private bool isMoreThanOneElementActive(){
        if (walkButton.activeSelf || runButton.activeSelf || atackButton.activeSelf || jumpButton.activeSelf) return true;
        else return false;
    }

    private bool isAnimationInProgress(){
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fox_Run_InPlace") || 
            this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fox_Attack_Paws") || 
            this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fox_Jump") || 
            this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fox_Walk_InPlace")) return true;
        else return false;
    }

/*    private void TaskOnClick()
    {
        
        actualButton.SetActive(false);
    }
*/
}
