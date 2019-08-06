using System.Collections;
using TMPro;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    private int Collected = 0; //Set up a variable to store how many you've collected
    public AudioClip CollectedClip;     //This is the sound that will play after you collect one
    public AudioClip EnemyClip;
    public AudioSource PlayerSource;     
    public AudioSource EnemySource;
    public int deathCount;

    public float Volume = 1.0f;
    public float CanvasX = 10f;
    public float CanvasY = 10f;
    public float CanvasWidth = 100f; //NOT smaller than 100 or the score wont show
    public float CanvasHeight = 20f;

    public GameObject CanvasCamera;
    public GameObject PlayerCamera;
    public GameObject CanvasMenu;
    public TextMeshProUGUI ResultText;
    ChasePlayer chase_player = null;

    public GameObject Enemy;

    float DeathTimer=0f;

    private void Start()
    {
        GameObject tempObj = GameObject.Find("Hapineko(All)");
        chase_player = tempObj.GetComponent<ChasePlayer>();

        CanvasMenu.SetActive(false);
        CanvasCamera.SetActive(false);
        PlayerCamera.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    { //Checks to see if you've collided with another object

        if (other.CompareTag("Collectable"))
        { //checks to see if this object is tagged with "collectable"
            PlayerSource.PlayOneShot(CollectedClip); //plays the sound assigned to collected
            Collected++; //adds a count of +1 to the collected variable
            Destroy(other.gameObject); //destroy's the collectable

            chase_player.MoveSpeed+=3;

            if (Collected >= 3)
            {
                ChangeState("Win");
            }
        }

        if (other.CompareTag("Enemy"))
        { //checks to see if this object is tagged with "Enemy"
            DeathTimer = 0f;
            EnemySource.PlayOneShot(EnemyClip); //plays the sound assigned to enemy

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DeathTimer += Time.deltaTime;
            
            if (DeathTimer >= deathCount)
            {
                ChangeState("Lose");
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            DeathTimer= 0f;
        }
    }

    public void ChangeState(string NewState)
    {
        CanvasMenu.SetActive(true);
        CanvasCamera.SetActive(true);
        PlayerCamera.SetActive(false);

        if (NewState=="Win")
        {
            ResultText.text = "You win";
        }

        else if (NewState=="Lose")
        {
            ResultText.text = "You lose";
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(CanvasX, CanvasY, CanvasWidth, CanvasHeight), "Collected:" + Collected);
    }
   
}