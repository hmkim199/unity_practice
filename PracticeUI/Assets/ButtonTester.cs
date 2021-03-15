using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonTester : MonoBehaviour
{
    Button button;
    public void OnClickButton() {
        Debug.Log("Button is CLicked!");
    }
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
