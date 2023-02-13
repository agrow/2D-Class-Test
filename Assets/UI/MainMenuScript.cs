using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string gameStartSceneName;

    private void OnEnable(){
        // Script is on the Game Object with UIDocument on it
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        if(root == null){
            Debug.LogError("No UIDocument Root Found");
        }

        // Q queries the children of the root for the matching name
        Button startButton = root.Q<Button>("StartGame");
        Button settingsButton = root.Q<Button>("Settings");
        Button creditsButton = root.Q<Button>("Credits");
        Button quitButton = root.Q<Button>("Quit");

        // Register callback functions for each button
        startButton.RegisterCallback<ClickEvent>(OnStartButtonClick);
        // Alternative way to register a callback
        settingsButton.clicked += () => OnSettingsButtonClick();

    }

    public void OnStartButtonClick(ClickEvent evt)
    {
        Debug.Log("start button clicked");
        // Loads the main game scene
        SceneManager.LoadScene(gameStartSceneName);
    }

    public void OnSettingsButtonClick()
    {
        Debug.Log("Settings button clicked");
    }
}
