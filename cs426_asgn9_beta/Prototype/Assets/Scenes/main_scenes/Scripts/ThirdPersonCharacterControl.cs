using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public Transform camPivot;
    private GameObject Manager;
    private GameManager GM;
    private Inventory inventory;
    private GameObject InventoryCanvas;
    private GameObject flashlight;
    float heading = 0;
    public Transform cam;
    public GameObject spawnpoint;

    //Lives Mechanic - Requires 6 UI images to be set and Audio


    Vector3 camF;
    Vector3 camR;
    Vector2 input;

    public GameObject PromptPanel;
    public GameObject other;  //this needs to be public so another script could access it.
    
    private void Start()
    {
        flashlight = GameObject.Find("Flashlight");
        Manager = GameObject.Find("GameManager");
        GM = Manager.GetComponent<GameManager>();
        inventory = GM.GetComponent<Inventory>(); 
        other = null;
    }
    void Update()
    {
        //Lives Mechanic
        //If CurrentLives = 0 kick to GameOver


        if (Input.GetKeyDown(KeyCode.I))
        {
            //open/close inventory will pause game. So we handle this in GameManager
            GM.Menu();
        }


                                //If the PrompPanel is active, then the user is in interacting range with an interactable object(see interactable script)
        if (Input.anyKeyDown){ //if user presses E, or 1-4. Any sort of interaction, where they are prompted first
            handleInteraction();
        }


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S)) //include space for jump, later. 
        {
            playerMovement();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            JumpCat();
        }
        else
        {
            GetComponent<Animator>().CrossFade("Idle", 0f);
        }

        basicState();

        if (Input.GetKeyDown(KeyCode.R)) {
            clickFlashLight();
        }

    }



    //------------------Interacting code, player with objects is below. Two methods. handleInteraction() and interact();



    void handleInteraction()
    {
         
        //in this state, we are in "OnTriggerEnter" and have not yet gotten to "OnTriggerExit"
        if (Input.GetKeyDown(KeyCode.E) && PromptPanel.activeInHierarchy)
        { 
            Interact();
        }

        //if any of the below are true, then the user is trying to use an item in his bag.
        //if user presses numbers 1-4 then overide the method with the value. 
        if (Input.GetKeyDown(KeyCode.Alpha1))   Interact(1);
        if (Input.GetKeyDown(KeyCode.Alpha2))   Interact(2);
        if (Input.GetKeyDown(KeyCode.Alpha3))   Interact(3);        
        if (Input.GetKeyDown(KeyCode.Alpha4))   Interact(4);
    }


    void Interact(int item = -1) //After we collide with an interactable object, the other script sets the current "other" gameobject equal to the collided object. 
                                 //depending on the tag of the collided object we could open the door or pick up the item or use a bagged item on another object(like a key to a door.) 
    {
        if (other == null) return;

        if (item == -1) // if the user presses E then we dont override the 'item' parameter
        {

            if(other.name == "Gate")
            {
                PromptPanel.GetComponentInChildren<Text>().text = "Locked by some contraption.";
                return;

            }

            if(other.name == "Door1")
            {
                PromptPanel.GetComponentInChildren<Text>().text = "Need key.";
                return;
            }

            if(other.name == "GlassDoor")
            {
                //call for the prompt for the pass code. 
                GM.PassCode(other);
                PromptPanel.SetActive(false);
                return;
            }

            if (other.tag == "Door")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene
            }
            if (other.tag == "PickUp") //if I could pick up the object. Update my inventory as such. 
            {
                inventory.addItem(other);
            }
            if (other.tag == "Open") //here we are opening something to access the elements inside. 
            {                       //this code send each of the boxes items and adds them... each one. So we use a for each loop
                int count = other.transform.childCount;
                if(count == 0)
                {
                    other.GetComponent<Interactable>().FollowUpMessage();
                }
                
                for (int i = 0; i < count; ++i)
                {
                    inventory.addItem(other.transform.GetChild(i).gameObject);
                    //as I add items to my inventory, I will remove them from the box, but keep them in the scene... so i could clone them later
                    //this is so we could empty out the box/containers                     
                }

                for(int i = 0; i<count; ++i)
                {
                    GM.hide(other.transform.GetChild(0).gameObject);
                }
                

            }

            return;
        }


        //here the value of item is not -1, meaning the user pressed 1-4. He is using an item on an interactable object. 
        // remember the 'other' game object had been overwritten, so we can check if user's bagged object will affect the other object we are colliding with
        //is the item I am trying to use throwable or not. 

        --item; //reduce the number to an index


        if (inventory.throwables[item] != null) //if this isnt null then the item here is either empty or not throwable. 
        {
            if(inventory.throwables[item].name == "Key1")
            {
                if(other.name == "Door1")
                {
                    PromptPanel.SetActive(false);
                    other.GetComponentInChildren<Animation>().Play();
                    other.GetComponent<BoxCollider>().enabled = false;
                    other.transform.GetChild(0).gameObject.GetComponent<Collider>().enabled = false;
                    inventory.removeItem(item);
                }
                else
                {
                    PromptPanel.GetComponentInChildren<Text>().text = "Does not work here";
                }

                return;
            }

            shoot(item);
            inventory.removeItem(item); //after we use the object, we could remove it from the bag. 
        }
        else
        {
            if(PromptPanel.activeInHierarchy)
                inventory.removeItem(item);
        }

          
        
    }


    void shoot(int item){
        if(inventory.throwables[item] != null)
        {
            GameObject t = Instantiate(inventory.throwables[item]);

            if (!t.GetComponent<Collider>().enabled)
                t.GetComponent<Collider>().enabled = true;

            t.transform.position = flashlight.transform.position;

            t.GetComponent<Rigidbody>().isKinematic = false;
            t.GetComponent<Rigidbody>().useGravity = true;
            t.GetComponent<Collider>().isTrigger = false;

            //t.GetComponent<Rigidbody>().AddForce(camF * 10f * Time.deltaTime, ForceMode.Impulse);

            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            t.GetComponent<Rigidbody>().velocity = camF * 17f;
        }

    }


    //------------------------------------- Player movement plus camera is below. 

    void JumpCat()
    {
        GetComponent<Animator>().SetTrigger("JumpTrigger");
        GetComponent<Rigidbody>().AddForce(cam.forward * 7f, ForceMode.Impulse);
    }


    void clickFlashLight(){

        FindObjectOfType<Flashlight_PRO>().Switch();
        flashlight.GetComponent<Collider>().enabled = !flashlight.GetComponent<Collider>().enabled;
    }

    void playerMovement()
    {

        transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
        // GetComponent<Animation>().Play("Walk");
        
        GetComponent<Animator>().SetTrigger("WalkTrigger");
        // transform.rotation = Quaternion.LookRotation(new Vector3(transform.position.x, 0,0));

    }

    void basicState()
    {
        cameraAdjustments();
        
    }
    void cameraAdjustments()
    {
        heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;

        camPivot.rotation = Quaternion.Euler(0, heading, 0);
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input = Vector2.ClampMagnitude(input, 1);

        camF = cam.forward;
        camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "Door" && Input.GetKey(KeyCode.E))
        {
            Debug.Log("called next");
            FindObjectOfType<GameManager>().nextScene();
        }

        if (collision.gameObject.tag == "Trap")
        {
            Debug.Log("Player Loses a Life!");
            transform.position = spawnpoint.transform.position; 
        }
    }



}
/*
public float Speed = 5f;

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;

        transform.rotation = Quaternion.LookRotation(playerMovement);

        // transform.position = transform.position + Camera.main.transform.forward * 5f * Time.deltaTime;

        transform.Translate(playerMovement, Space.World);
    }


*/


/*
 * 
 * 
 * 
 * 
 public Transform camPivot;
float heading = 0;
public Transform cam;

Vector2 input;
void Update()
{
    playerMovement();
}



void playerMovement()
{
    heading += Input.GetAxis("Mouse X") * Time.deltaTime * 180;

    camPivot.rotation = Quaternion.Euler(0, heading, 0);
    input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    input = Vector2.ClampMagnitude(input, 1);

    Vector3 camF = cam.forward;
    Vector3 camR = cam.right;

    camF.y = 0;
    camR.y = 0;
    camF = camF.normalized;
    camR = camR.normalized;

    //transform.position += new Vector3(input.x,0,input.y) *Time.deltaTime”S5;
    transform.position += (camF * input.y + camR * input.x) * Time.deltaTime * 5;
    // transform.rotation = Quaternion.LookRotation(new Vector3(transform.position.x, 0,0));

}

*/
