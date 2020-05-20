using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class move : MonoBehaviour
{
    //untuk move
    public float jump;
    public float speed;
    float moveVelocity;
    public AudioClip mAudioPoint;
    AudioSource audioSource;

    //untuk berpijak
    bool berpijak = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //jump
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)){
            if(berpijak){
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jump);
            }
        }

        moveVelocity = 0;

        //move
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            moveVelocity = -speed;
        }
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            moveVelocity = speed;
        }
    
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
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
}
