using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script has used chatgpt for fixing mistakes
public class tumble : MonoBehaviour
{
    Rigidbody2D rb;
    float xMovement;
    float moveSpeed = 5f;
    public bool continueMoving = true;
    [SerializeField]protected Animator myAnimator;
    private string sound;
    //Sets a delay for 0.2f
    float delay1 = 0.3f;
    float delay2 = 15f;
    [SerializeField] float tiltThreshold = 5f;
    

   // Called when the script instance is being loaded
   void Awake()
    {
        //Gets rigidbody and animator componant
        rb = GetComponent<Rigidbody2D> ();
        myAnimator = gameObject.GetComponent<Animator>();
        //call coroutine to destroy gameobject after delay
        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        //Moves gameobject by tilting device
        if (Mathf.Abs(Input.acceleration.x) > tiltThreshold)
        {
            //Calculates movement based on tilt
            xMovement = Input.acceleration.x * moveSpeed;
            //Prevents movement outside the defined position
            transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -20f, 20f), transform.position.y);
        }
        //Moves gameobject with constant velocity
        else 
        {
           transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); 
        }
    }

    void FixedUpdate()
    {
        //Sets velocity of rigidbody
        rb.velocity = new Vector2 (xMovement, 0f);
    }

    //Coroutine to destroy gameobject after delay
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(delay2);
        Explode();
    }

    private void OnMouseDown()
    {
        //Play tumbleweed sound through audio manager
        AudioManager.Instance.PlayTumbleweedSound();
        //Initiate the Explode() Method
        Explode();
    }

    void Explode()
    {
        //Set the animator to Trigger animation
        myAnimator.SetTrigger("Active");
        //Destroys the gameObject after delay
        Destroy(gameObject,delay1);
    }
}
