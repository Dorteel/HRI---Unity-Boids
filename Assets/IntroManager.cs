using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class IntroManager : MonoBehaviour {

    public Button button;
    public RawImage firstImg;
    public Text textForm;
    public InputField yourName;
    public Dropdown dropdown;
    public InputField yourAge;

    public int stage = 0;

    // Use this for initialization
    void Start () {
        button.onClick.AddListener(stageManager);
        firstImg.GetComponent<RawImage>().enabled = true;
        ShowForm(false);
    }

    // Update is called once per frame
    void Update () {

    }




    void stageManager()
    {
        stage++;
        if(stage == 1)
        {
            firstImg.GetComponent<RawImage>().enabled = false;
            ShowForm(true);
            button.transform.GetChild(0).GetComponent<Text>().text = "submit";
        }
        if (stage == 2)
        {
            string textToLog = "Name: ";
            textToLog = textToLog + yourName.transform.GetChild(2).GetComponent<Text>().text;
            textToLog = textToLog + "\nAge: " + yourAge.transform.GetChild(2).GetComponent<Text>().text;


            button.transform.GetChild(0).GetComponent<Text>().text = textToLog;

        }
        if(stage == 3)
        {
            SceneManager.LoadScene("Scenes/SampleScene", LoadSceneMode.Single);
        }

    }

    void ShowForm(bool state)
    {
        textForm.gameObject.SetActive(state);
        yourName.gameObject.SetActive(state);
        dropdown.gameObject.SetActive(state);
        yourAge.gameObject.SetActive(state);
}


    
}
