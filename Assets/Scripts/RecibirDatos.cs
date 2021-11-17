using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class RecibirDatos : MonoBehaviour
{
    SerialPort myPort = new SerialPort("\\\\.\\COM5", 9600);
    // Use this for initialization
    void Start()
    {
        myPort.Open();
        myPort.ReadTimeout = 100;

    }

    // Update is called once per frame
    void Update () {
        try
        {
            if (myPort.IsOpen)
            {
                print(myPort.ReadLine());
            }
        }catch(System.Exception ex)
        {
            ex = new System.Exception() ;
        }
    }
}
