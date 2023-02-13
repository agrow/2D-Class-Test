using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueUI : MonoBehaviour
{

    public Transform transformToFollow;

    VisualElement root;
    Label dialogue;
    Camera cam;
    private void OnEnable(){

        cam = Camera.main;
        root = GetComponent<UIDocument>().rootVisualElement;
        root = root.Q<VisualElement>("RealRoot");

        dialogue = root.Q<Label>("Dialogue");

        HideDialogue();
    }

    public void ShowDialogue(){
        root.style.visibility = Visibility.Visible;
        Debug.Log("Setting root dialogue visbility to true");
    }
    public void HideDialogue(){
        root.style.visibility = Visibility.Hidden;
        Debug.Log("Setting root dialogue visbility to false");
    }
    public void SetDialogue(string str){
        Debug.Log("Setting dialogue to str: " + str);
        dialogue.text = str;
    }

    public void SetBubblePosition(){
        Vector2 newPosition = RuntimePanelUtils.CameraTransformWorldToPanel(root.panel, transformToFollow.position, cam);
        //Vector2 newPosition = cam.WorldToScreenPoint(transformToFollow.position);
        //Vector2 newPosition = transformToFollow.position;
        //Vector2 newPosition = new Vector2(0,0); //- root.layout.width/2
        root.transform.position = new Vector2(newPosition.x - root.layout.width/2, newPosition.y);
        //Debug.Log("WTF is width " + root.layout.width);
        //Debug.Log("Following " + transformToFollow.position + " Setting bubble position to " + root.transform.position);
    }

    private void Start(){
        Debug.Log("Starting position " + root.transform.position);
        SetBubblePosition();
    }

    private void LateUpdate(){
        SetBubblePosition();
    }
}
