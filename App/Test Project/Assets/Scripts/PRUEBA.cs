using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
public class PRUEBA : MonoBehaviour
{
    Client client = new Client();
    // Start is called before the first frame update
    void Start()
    {
        client.Connect();
        Thread t = new Thread(new ThreadStart(client.ReceiveMessage));;
        t.Start();
        client.SendMessage("HOLA ALEX");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
