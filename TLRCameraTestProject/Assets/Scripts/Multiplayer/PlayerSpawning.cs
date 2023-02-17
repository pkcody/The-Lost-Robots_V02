using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Cinemachine;

//Spawns the player in different locations
public class PlayerSpawning : MonoBehaviour
{
    public static PlayerSpawning instance;

    public GameObject[] players = new GameObject[4];
    public Transform[] hoverInfo = new Transform[4];
    public Material[] mats = new Material[4];
    public Material[] personalityMats = new Material[4];
    public InventoryObject[] inv = new InventoryObject[4];

    public Transform[] JoinSpawnPos = new Transform[4];
    public Transform[] MenuSpawnPos = new Transform[4];
    public Transform[] GameSpawnPos = new Transform[4];

    public bool lockedIn = false;

    public CinemachineTargetGroup targetbrain;

    //Ready UP
    public bool readyUpCheck;
    public GameObject[] allReady = new GameObject[4];

    //tutorial
    public bool tutorialON = true;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        
     
    }

    public void ChangePlayerInput()
    {
        foreach(GameObject go in players)
        {
            if (go != null)
            {
                int Index = System.Array.IndexOf(players, go);

                // Different spawns for each scene
                if (SceneManager.GetActiveScene().name == "Join")
                {
                    go.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
                    print("calling");
                    go.GetComponent<PlayerInput>().defaultActionMap = "UI";
                }
                else if (SceneManager.GetActiveScene().name == "MainMenu")
                {
                    go.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
                    print("calling");
                    go.GetComponent<PlayerInput>().defaultActionMap = "UI";
                }
                else if (tutorialON && SceneManager.GetActiveScene().name == "Game")
                {
                    go.GetComponent<PlayerInput>().SwitchCurrentActionMap("TutorialMap");
                    go.GetComponent<PlayerInput>().defaultActionMap = "TutorialMap";
                    go.GetComponent<PlayerPainting>().enabled = false;
                }
                else if (!tutorialON && SceneManager.GetActiveScene().name == "Game")
                {
                    go.GetComponent<PlayerInput>().SwitchCurrentActionMap("Player");
                    go.GetComponent<PlayerInput>().defaultActionMap = "Player";
                    go.GetComponent<PlayerPainting>().enabled = false;
                }
                else if (SceneManager.GetActiveScene().name == "Credits")
                {
                    go.GetComponent<PlayerInput>().SwitchCurrentActionMap("UI");
                    print("calling");
                    go.GetComponent<PlayerInput>().defaultActionMap = "UI";
                }
            }
        }
    }

    public void StartingPositions()
    {
        foreach (GameObject go in players)
        {
            if (go != null)
            {
                int Index = System.Array.IndexOf(players, go);
                


                if (SceneManager.GetActiveScene().name == "Game")
                {
                    
                    targetbrain = FindObjectOfType<CinemachineTargetGroup>();

                    go.transform.position = GameSpawnPos[Index].position;
                    go.GetComponent<CharacterMovement>().enabled = true;
                    go.GetComponent<CharacterMovement>().cinemachineTargetGroup = targetbrain;

                    go.GetComponent<CharacterMovement>().BeginGame();

                    //cam
                    targetbrain.AddMember(go.transform, 1f, 5f);

                    //inv
                    print(inv[Index]);
                    go.GetComponent<DisplayingInventory>().enabled = true;
                    go.GetComponent<DisplayingInventory>().inventoryObj = inv[Index];

                }
            }
        }
    }

    public void SetInitialPlayerValues()
    {
        foreach(GameObject go in players)
        {
            if (go != null)
            {
                int Index = System.Array.IndexOf(players, go);
                go.transform.position = JoinSpawnPos[Index].position;

                readyUpCheck = false;

                go.transform.eulerAngles = Vector3.zero;
                print("hi");

                if(Index == 0)
                {
                    MotherShipStory.instance.MSTalk("Intro_" + PlayerInputManager.instance.playerCount);
                }


                go.GetComponent<JoinFunctionality>().personalityMats = personalityMats;
                

                foreach (var mr in go.GetComponentsInChildren<SkinnedMeshRenderer>())
                {
                    //print(mr.gameObject.name);
                    if (mr.material.name.Contains("ReplaceMe"))
                    {
                        mr.material = mats[Index];

                    }
                }



                //go.transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material = mats[Index];
                //go.GetComponent<DisplayingInventory>().inventoryObj = inv[Index];

                
            }

        }
        FindObjectOfType<PauseHunter>().PauseHunt();
    }

}
