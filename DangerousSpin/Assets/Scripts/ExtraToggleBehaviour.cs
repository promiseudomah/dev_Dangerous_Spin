using UnityEngine;
using UnityEngine.UI;

public class ExtraToggleBehaviour : MonoBehaviour
{

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    public void UpdateUIBehaviour(Toggle toggle)
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
