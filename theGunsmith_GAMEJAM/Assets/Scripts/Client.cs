using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Net;
using System.Net.Sockets;

public class Client : MonoBehaviour
{
    public static Client instance;
    public static int dataBufferSize = 4096;

    public string ip = "127.0.0.1";
    public int port = 26950;
    public int myId = 0;
    public TCP tcp;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, NUKED");
            Destroy(this);
        }
    }

    private void Start()
    {
        tcp = new TCP();
    }

    public void ConnectToServer()
    {
        tcp.Connect();
    }

    public class TCP
    {
        public TcpClient socket;
        private NetworkStream stream;
        private byte[] reciveBuffer;

        public void Connect()
        {
            socket = new TcpClient
            { 
                ReceiveBufferSize = dataBufferSize,
                SendBufferSize = dataBufferSize
            };

            reciveBuffer = new byte[dataBufferSize];
            socket.BeginConnect(instance.ip, instance.port, connectCallback, socket);
        }

        private void connectCallback(IAsyncResult _result)
        {
            socket.EndConnect(_result);

            if (!socket.Connected)
            {
                return;
            }

            stream.BeginRead(reciveBuffer, 0, dataBufferSize, reciveCallback, null);
        }

        private void reciveCallback(IAsyncResult _result)
        {
            try
            {
                int _byteLength = stream.EndRead(_result);
                if (_byteLength <= 0)
                {
                    // TODO: disconnect
                    return;
                }

                byte[] _data = new byte[_byteLength];
                Array.Copy(reciveBuffer, _data, _byteLength);

                // TODO: handle data
                stream.BeginRead(reciveBuffer, 0, dataBufferSize, reciveCallback, null);
            }
            catch
            {

            }
        }
    }


}
