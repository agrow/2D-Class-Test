using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody2D circleRigidBody;
    private InputAction.CallbackContext context;
    public AudioSource bouncePlayer;

    private void Awake(){
        circleRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 5f;
        //circleRigidBody.AddForce(inputVector * speed, ForceMode2D.Force);
        circleRigidBody.AddForce(new Vector2(inputVector.x, 0) * speed, ForceMode2D.Force);
    }

    public void Move(InputAction.CallbackContext contextSet){
        context = contextSet;
        Debug.Log(context);
        if(context.performed){
            Vector2 inputVector = context.ReadValue<Vector2>();
            float speed = 5f;
            circleRigidBody.AddForce(inputVector * speed, ForceMode2D.Force);
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        bouncePlayer.Play();
    }
}
