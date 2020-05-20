using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]


public class moveFinal : MonoBehaviour
{
    // Start is called before the first frame update
   public float jump;
    public float speed;
    float moveVelocity;
    public AudioClip mAudioPoint;
    AudioSource audioSource;
    public float boundY = 2.25f;

     CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;


    //untuk berpijak
    bool berpijak = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocity = 0;

        //move
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            moveVelocity = -speed;
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            moveVelocity = speed;
        }
    
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        var vel = GetComponent<Rigidbody2D>().velocity;
        if (Input.GetKey(KeyCode.UpArrow)) {
            vel.y = speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow)) {
            vel.y = -speed;
        }
        else {
            vel.y = 0;
        }
        GetComponent<Rigidbody2D>().velocity = vel;

        // var pos = transform.position;
        // if (pos.y > boundY) {
        //     pos.y = boundY;
        // }
        // else if (pos.y < -boundY) {
        //     pos.y = -boundY;
        // }
        // transform.position = pos;
    }

    void IyaBerpijak2D(){
        berpijak = true;
    }
    void TidakBerpijak2D(){
        berpijak = false;
    }

    void OnCollisionEnter2D (Collision2D col){
        if(col.gameObject.name == "Cube"){
                Debug.Log("Bola Menyentuh pembatas");
                Application.LoadLevel (Application.loadedLevel);
        }  
    }
    
    void OnTriggerEnter2D (Collider2D other){
            if(other.gameObject.name == "Finish"){
                Debug.Log("Bola Menyentuh Finish");
                audioSource.PlayOneShot(mAudioPoint, 0.7F);
            }
    }
    void OnCollisionStay2D (Collision2D other){
        if(other.gameObject.name == "stopFinishFinal"){
            SceneManager.LoadScene("End");
        }
    }
}
