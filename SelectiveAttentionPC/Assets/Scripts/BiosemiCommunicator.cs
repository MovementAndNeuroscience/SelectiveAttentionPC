using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class BiosemiCommunicator : MonoBehaviour
{
    public string comport = "COM3";
    public int baudrate = 115200;
    private SerialPort serialPort; 

    // Start is called before the first frame update
    void Start()
    {
        comport = GetComponent<BiosemiConfigLoader>().LoadComportFromConfiq();
        serialPort = new SerialPort(comport, baudrate);
        serialPort.Open();
    }

    public void sendTrigger(string trigger)
    {
        try
        {
            serialPort.Write(trigger);
        }
        catch (IOException ex)
        {
            print(ex);
        }
    }
    public void sendTrigger(byte[] trigger)
    {
        try
        {
            serialPort.Write(trigger,0,1);
        }
        catch (IOException ex)
        {
            print(ex);
        }
    }
    public void CloseConnection()
    {
        serialPort.Close();
    }
}
