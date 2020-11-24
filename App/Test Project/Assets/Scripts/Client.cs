using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
public class Client : MonoBehaviour
{
    // Start is called before the first frame update
    private Socket socket;
    private IPEndPoint direction;
    private string message;

    public Client()
    {
        this.message = null;
        this.socket = null;
        this.direction = null;
    }

    public void setMessage(string message)
    {
        this.message = message;
    }
    public void Connect()
    {
        this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        this.direction = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1000);
        this.socket.Connect(direction);
    }
    public void SendMessage(string message)
    {
        byte [] send = Encoding.Default.GetBytes(message);
        this.socket.Send(send, 0, send.Length, 0);
    }
    public string GetMessage()
    {
        return this.message;
    }
    public void ReceiveMessage()
    {
        while (true)
        {
            byte[] ByRec = new byte[255];
            int a = this.socket.Receive(ByRec, 0, ByRec.Length, 0);
            Array.Resize(ref ByRec, a);
            setMessage(Encoding.Default.GetString(ByRec));
        }
        
    }
}
    
