using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotion : MonoBehaviour
{
    // Animation du personnage 
    public Animation animations;
  // Vitesse de déplacement du personnage
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    public float turnSpeed = 200f;


    // Inputs du joueur
    public KeyCode inputFront = KeyCode.W;
    public KeyCode inputBack = KeyCode.S;
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputRun = KeyCode.LeftShift;
    public KeyCode inputJump = KeyCode.Space;
    public Vector3 jumpSpeed;
    private CapsuleCollider playerCollider;
    // si notre personnage est mort 
    public bool isDead = false;
    // Vérifie si le personnage est au sol (LayerMask 3)
    bool IsGrounded()
    {
        return Physics.CheckCapsule(
            playerCollider.bounds.center,
            new Vector3(playerCollider.bounds.center.x, playerCollider.bounds.min.y - 0.1f, playerCollider.bounds.center.z),
            0.08f,
            3 // Layer 3 uniquement
        );
    }
    void Start()
    {
        animations = gameObject.GetComponent<Animation>();
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
       
    }

    void Update()
    {
       if(!isDead)
       {
             if (Input.GetKey(inputFront) && Input.GetKey(inputRun))
        {
            transform.Translate(0,0,runSpeed *Time.deltaTime);
            animations.Play("run");
        }
        //Marcher-----------------------------------------------------------------------
        if (Input.GetKey(inputFront) && !Input.GetKey(inputRun))
        {
            transform.Translate(0,0,walkSpeed *Time.deltaTime);
            animations.Play("walk");
        }
        //-----------------------------------------------------------------------
        if (Input.GetKey(inputBack))
        {
            transform.Translate(0,0,-(walkSpeed/2) *Time.deltaTime);
            animations.Play("walk");
        }
        //Rotation_Gauche-----------------------------------------------------------------------
        if (Input.GetKey(inputLeft))
        {
            transform.Rotate(0, -turnSpeed * Time.deltaTime, 0);
        }
        //Rotation_Droite-----------------------------------------------------------------------
        if (Input.GetKey(inputRight))
        {
            transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
        }
        // si on ne fais rien :----------------------------------------------------------------------------
        if (!Input.GetKey(inputFront) && !Input.GetKey(inputBack))
        {
           animations.Play("idle");
        }
                //-----------------------------------------------------------------------
        // Saut
        if (Input.GetKeyDown(inputJump) && IsGrounded())
        {
            // preparation du saut 
            Vector3 v =  gameObject.GetComponent<Rigidbody>().velocity;
            v.y = jumpSpeed.y;  
            // le saut:
            gameObject.GetComponent<Rigidbody>().velocity = jumpSpeed;
          
        }
       }

       
    }
    

}
