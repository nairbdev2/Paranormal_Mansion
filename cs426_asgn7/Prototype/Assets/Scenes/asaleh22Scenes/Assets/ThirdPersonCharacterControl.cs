using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public Transform camPivot;
    float heading = 0;
    public Transform cam;
    public GameObject spawnpoint;

    Vector3 camF;
    Vector3 camR;

    Vector2 input;

    public GameObject canvas;
    private void Start()
    {
       // GetComponent<Animation>().Play("Idle");
       //will no longer use animation. Instead switching over to Animator, commented out for now. 

    }
    void Update()
    {
        if(Input.GetKey(KeyCode.E) && canvas.activeInHierarchy){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene
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

        if (Input.GetKeyDown(KeyCode.R)){
            clickFlashLight();
        }

    }

    void JumpCat()
    {
        GetComponent<Animator>().SetTrigger("JumpTrigger");
        GetComponent<Rigidbody>().AddForce(cam.forward * 8f, ForceMode.Impulse);
    }


    void clickFlashLight(){

        FindObjectOfType<Flashlight_PRO>().Switch();
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
