using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class RobotMessaging : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject chatBoxPar;

    [SerializeField] private float typingSpeed = 0.04f;
    public string response;


    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>(true);
        //chatBoxPar = transform.parent.parent;
    }

    private IEnumerator DisplayLine(string line)
    {
        text.text = " ";
        text.gameObject.SetActive(true);
        foreach (char letter in line.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(2f);
        text.gameObject.SetActive(false);
    }

    public void RobotSpeakResource(ItemObject io)
    {
        print(io.UIimage.name);
        if (io.UIimage.name.Contains("WiresWeakTT_UI") || io.UIimage.name.Contains("WiresStrongTT_UI"))
        {
            //print("in");
            response = "So that’s how you reconnect an electric flow.";
            StartCoroutine(DisplayLine(response));
        }
        if (io.UIimage.name.Contains("TiresTT_UI"))
        {
            response = "Why does rubber have to be so resistant? This would be so much easier with the help from mothership.";
            StartCoroutine(DisplayLine(response));
        }
        if (io.UIimage.name.Contains("SolarPanelsTT_UI"))
        {
            response = "Can that star recharge my battery already?";
            StartCoroutine(DisplayLine(response));
        }
        if (io.UIimage.name.Contains("FasterAbility_UI"))
        {
            response = "Ooo this looks like one of our old functions to help us go faster.";
            StartCoroutine(DisplayLine(response));
        }

    }

    public void RobotHold(GameObject go)
    {

        if (go.name.Contains("Window"))
        {
            //print("in");
            response = "Wait I think this is the window from our dorm room.";
            StartCoroutine(DisplayLine(response));
        }
        if (go.name.Contains("Battery")) 
        {
            response = "I think this use to be one of my chores, I don't know if I want to return this actually.";
            StartCoroutine(DisplayLine(response));
        }
        if (go.name.Contains("InhalerT"))
        {
            response = "This looks like it activates something if I push the big button.";
            StartCoroutine(DisplayLine(response));
        }
        if (go.name.Contains("InhalerR"))
        {
            response = "I need another Robot to activate the transmitter.";
            StartCoroutine(DisplayLine(response));
        }
        if (go.name.Contains("Paper"))
        {
            response = "Hmm this seems familiar lets try adding it to this big stucture.";
            StartCoroutine(DisplayLine(response));
        }

    }


    public void TowerRobotSpeak(string response)
    {
        StopCoroutine("DisplayLine");
        StartCoroutine(DisplayLine(response));
    }

    public void MotherRobotSpeak(string response)
    {
        StopCoroutine("DisplayLine");
        StartCoroutine(DisplayLine(response));
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
