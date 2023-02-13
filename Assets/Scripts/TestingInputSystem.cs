using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody2D circleRigidBody;
    private InputAction.CallbackContext context;
    public AudioSource bouncePlayer;
    public GameObject healthbarUI;
    public GameObject dialogueUI;

    public float displayDialogueTimerMax = 1f;
    private bool dialogueTimerActive = false;
    private float dialogueTimer = 0f;
    private int bounceCounter = 0;

    private void Awake(){
        circleRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        Vector2 inputVector = context.ReadValue<Vector2>();
        float speed = 5f;
        //circleRigidBody.AddForce(inputVector * speed, ForceMode2D.Force);
        circleRigidBody.AddForce(new Vector2(inputVector.x, 0) * speed, ForceMode2D.Force);

        if(dialogueTimerActive){
            dialogueTimer -= Time.deltaTime;
            // Turn off the dialogue
            if(dialogueTimer <= 0){
                dialogueTimerActive = false;
                dialogueUI.GetComponent<DialogueUI>().HideDialogue();
            }
        }
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
        

        float currentHealth = healthbarUI.GetComponent<HealthBar>().getHealth();
        healthbarUI.GetComponent<HealthBar>().setHealth(currentHealth/2);

        // Turn on the timer & dialogue box
        bounceCounter++;
        dialogueTimerActive = true;
        dialogueTimer = displayDialogueTimerMax;
        dialogueUI.GetComponent<DialogueUI>().ShowDialogue();
        dialogueUI.GetComponent<DialogueUI>().SetDialogue("Ouch #" + bounceCounter);
        
    }
}
