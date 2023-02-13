using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuCode : MonoBehaviour
{
    public string SceneNameToChangeTo;

    private void OnEnable() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        Button startButton = root.Q<Button>("StartButton");

        if(startButton == null){
            Debug.Log("NULL BUTTON");
        }

        startButton.RegisterCallback<ClickEvent>(OnStartButtonClick);
    }

    public void OnStartButtonClick(ClickEvent evt){
        Debug.Log("BUTTON CLICKED " + evt);
        SceneManager.LoadScene(SceneNameToChangeTo);
    }
    
}
