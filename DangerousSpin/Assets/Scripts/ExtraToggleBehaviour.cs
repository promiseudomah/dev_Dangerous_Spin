using UnityEngine;
using UnityEngine.UI;

public class ExtraToggleBehaviour : MonoBehaviour
{

    Text text;
    Toggle toggle;

    void Start()
    {
        text = GetComponent<Text>();
        toggle = GetComponent<Toggle>();

        UpdateOptions();
    }

    void UpdateOptions(){

        if(PlayerPrefs.GetInt("LocalKey") == 0 && toggle.gameObject.name.Contains("English"))
        {
            
            toggle.isOn = true;
            UpdateUIBehaviour();
        }

        else if(PlayerPrefs.GetInt("LocalKey") == 1 && toggle.gameObject.name.Contains("Brasil"))
        {
            
            toggle.isOn = true;
            UpdateUIBehaviour();
        }
    }

    public void UpdateUIBehaviour()
    {
        Color currentColor = text.color;

        if (!toggle.isOn)
        {
            
            currentColor.a = 0.45f;
        }
        else
        {

            currentColor.a = 1f;
        }
        
        
        text.color = currentColor;

        
    }

}


