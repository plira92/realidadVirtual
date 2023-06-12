using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;
using System;

public class BTCommunication : MonoBehaviour
{
    private BluetoothHelper helper;
    private string[] actions = { "Walk", "Run", "Attack", "Jump", "Die" };
    public GameObject walkButton;
    public GameObject runButton;
    public GameObject atackButton;
    public GameObject jumpButton;

    private GameObject actualButton;
    private int index;
    private string nameAction;

    private string deviceName;

    // Start is called before the first frame update
    void Start()
    {
        //Init all values in 0
        for (int i = 0; i < 4; i++)
        {
            this.GetComponent<Animator>().SetBool(actions[i], false);
        }

        deviceName = "HC-05";
        try
        {
            helper = BluetoothHelper.GetInstance(deviceName);
            helper.OnConnected += OnConnected;
            helper.OnConnectionFailed += OnConnFailed;
            helper.OnDataReceived += OnDataReceived;

            helper.setTerminatorBasedStream("\n");

            //or
            //helper.setLengthBasedStream();

            if (helper.isDevicePaired())
            {
                helper.Connect();
            }

        }
        catch (BluetoothHelper.BlueToothNotEnabledException ex) 
        {
            
        }
        catch(BluetoothHelper.BlueToothPermissionNotGrantedException ex)
        {

        }
        catch(BluetoothHelper.BlueToothNotSupportedException ex)
        {

        }
        catch(BluetoothHelper.BlueToothNotReadyException ex)
        {

        }

    }


    // Update is called once per frame
    void Update()
    {
        if(helper.Available)
        {
            string msg = helper.Read();
            print(msg);

            if (msg == "WALK")
            {
                if (walkButton.activeSelf)
                {
                    walkButton.SetActive(false);
                    this.GetComponent<Animator>().SetBool("Walk", true);
                }
            }
            else if(msg == "RUN")
            {
                if (runButton.activeSelf)
                {
                    this.GetComponent<Animator>().SetBool("Run", true);
                    runButton.SetActive(false);
                }
            }
            else if (msg == "ATTACK")
            {
                if (atackButton.activeSelf)
                {
                    this.GetComponent<Animator>().SetBool("Attack", true);
                    atackButton.SetActive(false);
                }
            }
            else if (msg == "JUMP")
            {
                if (jumpButton.activeSelf)
                {
                    this.GetComponent<Animator>().SetBool("Jump", true);
                    jumpButton.SetActive(false);
                }
            }
        }

        //Random number
        index = UnityEngine.Random.Range(0, 4);

        nameAction = actions[index];

        switch (index)
        {
            case 0:
                {
                    actualButton = walkButton;
                    break;
                }
            case 1:
                {
                    actualButton = runButton;
                    break;
                }
            case 2:
                {
                    actualButton = atackButton;
                    break;
                }
            case 3:
                {
                    actualButton = jumpButton;
                    break;
                }
        }

        if (!actualButton.activeSelf && !(isMoreThanOneElementActive()) && !isAnimationInProgress())
        {
            actualButton.SetActive(true);
        }
    }

    private bool isMoreThanOneElementActive()
    {
        if (walkButton.activeSelf || runButton.activeSelf || atackButton.activeSelf || jumpButton.activeSelf) return true;
        else return false;
    }

    private bool isAnimationInProgress()
    {
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fox_Run_InPlace") ||
            this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fox_Attack_Paws") ||
            this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fox_Jump") ||
            this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Fox_Walk_InPlace")) return true;
        else return false;
    }

    private void OnDataReceived()
    {
    }

    private void OnConnected()
    {
        helper.StartListening();

        helper.SendData("HELLO ARDUINO!!");
    }

    private void OnConnFailed()
    {

    }

    private void OnDestroy()
    {
        helper.Disconnect();
    }
}
