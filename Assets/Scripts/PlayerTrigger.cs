using TMPro;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private int Collected = 0; //Set up a variable to store how many you've collected
    public AudioClip CollectedClip;     //This is the sound that will play after you collect one
    public AudioClip EnemyClip;
    public AudioSource PlayerSource;     //This is the sound that
    public AudioSource EnemySource;

    public float Volume = 1.0f;
    public float CanvasX = 10f;
    public float CanvasY = 10f;
    public float CanvasWidth = 100f; //NOT smaller than 100 or the score wont show
    public float CanvasHeight = 20f;

    public GameObject CanvasCamera;
    public GameObject PlayerCamera;
    public GameObject CanvasMenu;
    public TextMeshProUGUI ResultText;


    //This is the text that displayed how many you've collected in the top left corner
    private void Start()
    {
        CanvasMenu.SetActive(false);
        CanvasCamera.SetActive(false);
        PlayerCamera.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    { //Checks to see if you've collided with another object

        if (other.CompareTag("Collectable"))
        { //checks to see if this object is tagged with "collectable"
            PlayerSource.PlayOneShot(CollectedClip); //plays the sound assigned to collectedSound
            Collected++; //adds a count of +1 to the collected variable
            Destroy(other.gameObject); //destroy's the collectable
            if (Collected >= 3)
            {
                ChangeState("Win");
            }
        }

        if (other.CompareTag("Enemy"))
        { //checks to see if this object is tagged with "collectable"
            EnemySource.PlayOneShot(EnemyClip); //plays the sound assigned to collectedSound
            ChangeState("Lose");
        }
    }

    public void ChangeState(string NewState)
    {
        CanvasMenu.SetActive(true);
        CanvasCamera.SetActive(true);
        PlayerCamera.SetActive(false);

        if (NewState=="Win")
        {
            ResultText.text = "You are winner";
        }

        else if (NewState=="Lose")
        {
            ResultText.text = "lose";
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(CanvasX, CanvasY, CanvasWidth, CanvasHeight), "Collected:" + Collected);
    }
}