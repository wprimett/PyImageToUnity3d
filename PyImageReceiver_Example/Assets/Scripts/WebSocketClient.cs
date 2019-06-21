using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;
using WebSocketSharp;
using System.IO;

//client
public class WebSocketClient : MonoBehaviour
{
    public GameObject UnityGameObject;
    TextureUpdater modelController;
    WebSocket MyWebSocket;
    [SerializeField] int PortNumber = 7777;
    [SerializeField] string IPAddressString = "127.0.0.1";

    private byte[] ws_data;
	// Use this for initialization
	void Start ()
    {
        InitAndConnectWebSocket();
        //test send message
        SendMessageToSocket("CONNECTING");
	   }

    /// <summary>
    /// Getter for the combined websocket creation string
    /// </summary>
    /// <returns>The web socket string.</returns>
    string GetWebSocketString()
    {
        return "ws://" + IPAddressString + ":" + PortNumber;
    }

    /// <summary>
    /// Inits the Websocket, initiates a connection to it, and adds callback events
    /// Presumeably the callbacks happen on the main thread?
    /// </summary>
    void InitAndConnectWebSocket()
    {
        Debug.Log("Starting websocket client...");
        MyWebSocket = new WebSocket(GetWebSocketString());
        MyWebSocket.EmitOnPing = true;
        MyWebSocket.OnError += WebSocketError;
        MyWebSocket.OnMessage += WebSocketMessageReceived;
        MyWebSocket.OnOpen += WebSocketOpened;
        MyWebSocket.OnClose += WebSocketOnClose;
        MyWebSocket.Connect();
        Debug.Log("...Done starting websocket client = " + GetWebSocketString());
    }


    /// <summary>
    /// Callback when socket is closed
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    void WebSocketOnClose(object sender, CloseEventArgs e)
    {
        Debug.Log("WebSocketClient OnClose: " + e.Reason);
    }


    /// <summary>
    /// Callback when errors are received
    /// </summary>
    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    void WebSocketError(object sender, WebSocketSharp.ErrorEventArgs e)
    {
        Debug.LogError("WebSocketClient OnError: " + e.Message);
    }

    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    void WebSocketMessageReceived(object sender, MessageEventArgs e)
    {
      if (e.IsBinary) {
        ws_data = e.RawData;
      }
        // Debug.Log("WebSocketClient OnMessage: " + e.Data);
    }

    /// <param name="sender">Sender.</param>
    /// <param name="e">E.</param>
    void WebSocketOpened(object sender, System.EventArgs e)
    {
        Debug.Log("WebSocketClient OnOpen: " + e.ToString());
    }

    /// <param name="message">Message.</param>
    void SendMessageToSocket(string message)
    {
        if (MyWebSocket != null &&  MyWebSocket.IsAlive)
        {
            Debug.Log("WebSocketClient Sending msg:" +  message);
        }
    }
    private void OnDestroy()
    {
        Debug.Log("Closing WebSocketClient: " + GetWebSocketString());
        MyWebSocket.Close();
    }

    void Update() {
      if (ws_data.Length > 0){
        // Debug.Log(ws_data);
        modelController = UnityGameObject.GetComponent<TextureUpdater>();
        modelController.UpdateTexture(ws_data);
      }
    }
}
