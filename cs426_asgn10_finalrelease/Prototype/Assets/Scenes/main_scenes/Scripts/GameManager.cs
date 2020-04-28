using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



//this script will handle switching scenes and pausing the game. 
// its best to keep things organized. 


public class GameManager : MonoBehaviour
{

    public int currLives;
    public int numOfLives;
    public Image[] lives;
    public Sprite fullLife;
    public Sprite emptyLife;
    public AudioSource lostLife_sfx;

    public GameObject EnterPass;
    public bool GameisPaused = false;
    public GameObject InventoryCanvas;
    private GameObject TRASH;

    public Text Answer;

    private string ans = "";

    private GameObject holder;
    private GameObject spawn;
    private GameObject player;
    private GameObject Gate;
    private GameObject PullingCage;
    private GameObject TickTock;
    private GameObject RotateChain, MyChains, CeilingCage;
    private void Start()
    {
        currLives = 6;
        lostLife_sfx = GetComponent<AudioSource>();
        TRASH = GameObject.Find("TRASH");
        holder = null;

        player = GameObject.Find("LightCatCurrent");
        spawn = GameObject.Find("Spawnpoint_1");
        Gate = GameObject.Find("Gate");
        PullingCage = GameObject.Find("PullingCage");
        TickTock = GameObject.Find("TickTock");
        RotateChain = GameObject.Find("RotateChain");
        MyChains = GameObject.Find("MyChains");
        CeilingCage = GameObject.Find("CeilingCage");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void Update()
    {
        if (currLives == 0)
        {
            Debug.Log("End the Game Here...");
            SceneManager.LoadScene("GameOver");
        }
        // Attempts to get more Lives

        if (currLives > numOfLives)
        {
            currLives = numOfLives;
        }
        //Update Lives UI
        for (int i = 0; i < lives.Length; i++)
        {
            if (i < currLives)
            {
                lives[i].sprite = fullLife;
            }
            else
            {
                lives[i].sprite = emptyLife;
            }

            if (i < numOfLives)
            {
                lives[i].enabled = true;
            }
            else
            {
                lives[i].enabled = false;
            }


        }

    }


    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void prevScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void pause() {

        if(!EnterPass.activeInHierarchy)
            InventoryCanvas.SetActive(true);


        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void resume(){

        if (!EnterPass.activeInHierarchy)
            InventoryCanvas.SetActive(false);


        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GameisPaused = false;
    }

    public void Menu(string menu = "") //if paused, resume and vice versa. 
    {
        if(menu == "door")
        {
            if (GameisPaused) resume();
            else pause();
            return;
        }

        if (!EnterPass.activeInHierarchy)
        {
            if (GameisPaused) resume();
            else pause();
        }
    }

    public void hide(GameObject original)
    {
        //original.transform.parent = TRASH.transform;
        original.transform.SetParent(TRASH.transform);
        original.transform.position = TRASH.transform.position;
    }


    public void PassCode(GameObject door)
    {
        if (EnterPass.activeInHierarchy)
            return;

        EnterPass.SetActive(true);
        Menu("door"); //first pause the game. 
        holder = door;

    }

    public void CatchAnswer(string a){
        if(a == "Exit")
        {
            ans = "";
            Answer.text = "Enter pass code";
            EnterPass.SetActive(false);
            Menu();
            return;
        }

        Answer.text = "";
        ans += a;
        Answer.text += ans;

        if(ans.Length == 5)
        {
            checkAnswer();
        }
  
    }

    void checkAnswer()
    {
        if(ans == "22120")
        {
            holder.GetComponentInChildren<Animation>().Play();
            holder.tag = "Untagged";
            holder.transform.GetChild(0).gameObject.GetComponent<Collider>().enabled = false;
            CatchAnswer("Exit");
        }
        else
        {
            Answer.text = "Try Again";
            ans = "";
        }

    }


    //Counter for Lives Mechanic
    public void loseLife()
    {
        if (currLives == 0)
        {
            Debug.Log("End the Game Here... (Should not Reach Here Check in Update First)");
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            lostLife_sfx.Play();
            currLives--;
        }
    }

    public void addLife()
    {
        currLives++;
    }

    public void kill() {

        player.transform.position = spawn.transform.position;
    }




    public void GateRoutine()
    {
        PullingCage.GetComponent<Animation>().Play();
        Gate.GetComponent<Animation>().Play();
        TickTock.GetComponent<AudioSource>().Play();
    }

    public void GateRoutineOver()
    {
        TickTock.GetComponent<AudioSource>().Stop();
    }

    public void CutRoutine() //start rotate on top chain. Drop bottom chain. // drop cage
    {
        RotateChain.GetComponent<Animation>().Play();
        
        MyChains.GetComponent<Rigidbody>().useGravity = true;
        MyChains.GetComponent<BoxCollider>().enabled = true;

        CeilingCage.GetComponent<Rigidbody>().useGravity = true;
        CeilingCage.GetComponent<BoxCollider>().enabled = true;

    }


    /*  
     *  The below code is given by unity. Here as a reminder incase we decide to implement them. 
      private void OnApplicationPause(bool pause)
      { a message sent to all game objects when the game pauses

      }
      private void OnApplicationQuit()
      { a message sent to all game objects right before the game quits. 

      }

      */
}
