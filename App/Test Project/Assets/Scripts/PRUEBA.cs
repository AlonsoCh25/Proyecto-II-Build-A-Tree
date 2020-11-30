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
        // Inicia el cliente
        client.Connect();
        Thread t_client = new Thread(new ThreadStart(client.ReceiveMessage));
        t_client.Start();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
