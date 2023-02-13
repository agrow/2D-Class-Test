using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : MonoBehaviour
{
    ProgressBar healthbar;

    private void OnEnable(){
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        healthbar = root.Q<ProgressBar>("HealthBar");

        //Debug.Log("Progress Bar Found?: " + healthbar);
        //Debug.Log("testing getHealth " + getHealth());
    }
    
    public void setHealth(float val){
        if(healthbar == null){
            Debug.LogError("No healthbar to set health to");
        } else {
            Debug.Log("Setting health to " + val);
            healthbar.value = val;
        }
    }

    public float getHealth(){
        if(healthbar == null){
            Debug.LogError("No healthbar to get health from");
            return 0;
        } else {
            return healthbar.value;
        }
    }
}
