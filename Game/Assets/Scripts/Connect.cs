using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Connect : MonoBehaviour
{
	public string IPPath = Application.streamingAssetsPath + "/ServerIP.txt";
	public string PortPath = Application.streamingAssetsPath + "/ServerPort.txt";
	public Text ServerIPText;
	public Text ServerPortText;
    public string staInfo = "NULL";							    //状态信息
    public string inputIp;					    				//输入服务端ip地址
    public string inputPort;									//输入服务端端口号
    public string inputMes;										//发送的消息
	public Text SchoolIDText;									//校内学号输入框
	public static string SchoolID;								//校内学号
	public Text NameText;										//名字输入框
	public Text PointText;										//分数显示
    public int recTimes = 0;									//接收到信息的次数
    public string recMes = "NULL";								//接收到的消息
    public Socket socketSend;									//客户端套接字，用来链接远端服务器
    public bool clickSend = false;								//是否点击发送按钮
	public GameObject CannotConnect;
    public float CountTime = 0f;
    public float EndTime = 5f;

    //建立链接
    public void ClickConnect()
    {
        try
        {
            int _port = Convert.ToInt32(inputPort);			//int型端口号
            string _ip = inputIp;                               

            //创建客户端Socket，获得远程服务端ip和端口号
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(_ip);
            IPEndPoint point = new IPEndPoint(ip, _port);
            //连接
            socketSend.Connect(point);
            Debug.Log(" ip = " + ip + " port = " + _port);
            staInfo = ip + ":" + _port + "Connected.";

            Thread r_thread = new Thread(Received);			//开启新的线程，不停的接收服务器发来的消息
            r_thread.IsBackground = true;
            r_thread.Start();

            Thread s_thread = new Thread(SendMessage);		//开启新的线程，不停的给服务器发送消息
            s_thread.IsBackground = true;
            s_thread.Start();
        }
        catch
        {

        }
    }
	
	public void ClickConnectLocal()
    {
        try
        {
            int _port = Convert.ToInt32("35983");			//int型端口号
            string _ip = "127.0.0.1";                               

            //创建客户端Socket，获得远程服务端ip和端口号
            socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(_ip);
            IPEndPoint point = new IPEndPoint(ip, _port);
            //连接
            socketSend.Connect(point);
            Debug.Log(" ip = " + ip + " port = " + _port);
            staInfo = ip + ":" + _port + "Connected.";

            Thread r_thread = new Thread(Received);			//开启新的线程，不停的接收服务器发来的消息
            r_thread.IsBackground = true;
            r_thread.Start();

            Thread s_thread = new Thread(SendMessage);		//开启新的线程，不停的给服务器发送消息
            s_thread.IsBackground = true;
            s_thread.Start();
        }
        catch
        {
            
        }
    }
    /// <summary>
    /// 接收服务端返回的消息
    /// </summary>
    public void Received()
    {
        while (true)
        {
            try
            {
                byte[] buffer = new byte[1024 * 6];
                int len = socketSend.Receive(buffer);
                if (len == 0)
                {
                    break;
                }

                recMes = Encoding.UTF8.GetString(buffer, 0, len);

                Debug.Log("接收:" + recMes);

                recTimes ++;
                staInfo = "接收到一次数据，接收次数为:" + recTimes;
                Debug.Log("接收次数为:" + recTimes);
                CountTime = 0f;
            }
            catch
            {

            }
        }
    }

    /// <summary>
    /// 向服务器发送消息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SendMessage()
    {
        try
        {
            while (true)
            {
                if (clickSend)							//如果点击了发送按钮
                {
                    clickSend = false;
                    string msg = inputMes;
                    byte[] buffer = new byte[1024 * 6];
                    buffer = Encoding.UTF8.GetBytes(msg);
                    socketSend.Send(buffer);
                    Debug.Log("Send:" + msg);
                }
            }
        }
        catch { }
    }

    public void IsServerOnline()
	{
		inputMes = "IsServerOnline";
		string msg = inputMes;
        byte[] buffer = new byte[1024 * 6];
        buffer = Encoding.UTF8.GetBytes(msg);
        socketSend.Send(buffer);
	}

    /*private void OnDisable()
    {
        Debug.Log("begin OnDisable()");

        if (socketSend.Connected)
        {
            try
            {
                socketSend.Shutdown(SocketShutdown.Both);	//禁用Socket的发送和接收功能
                socketSend.Close();							//关闭Socket连接并释放所有相关资源
            }
            catch (Exception e)
            {
                print(e.Message);
            }
        }

        Debug.Log("end OnDisable()");
    }*/
	
	public void Connected()
	{
		CannotConnect.SetActive(false);
	}

    public void NoConnect()
    {
        CannotConnect.SetActive(true);
    }
	
	public void Start()
    {
		//inputIp = File.ReadAllText(IPPath);
		//inputPort = File.ReadAllText(PortPath);
		inputIp = ServerSettings.ServerIP;
		inputPort = ServerSettings.ServerPort;
		if (!Directory.Exists(Application.streamingAssetsPath))//如果没有这个文件夹，就创建
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
		//Check Online
		ClickConnect();
		if (staInfo == "NULL")
		{
            NoConnect();
        }
		else
		{
			Connected();
		}
		IsServerOnline();
		if (recMes == "Online")
		{
			if (staInfo == "NULL")
			{
                NoConnect();
            }
			else
			{
				Connected();
			}
		}
    }
	
    void Update()
    {
		
	}
	
	public void SendSID()
	{
		inputMes = "SID" + SchoolIDText.text + NameText.text;
		string msg = inputMes;
        byte[] buffer = new byte[1024 * 6];
        buffer = Encoding.UTF8.GetBytes(msg);
        socketSend.Send(buffer);
		File.WriteAllText(Application.streamingAssetsPath + "/" + "SchoolID.txt", SchoolIDText.text);
		SchoolID = SchoolIDText.text;
	}
	
	public void SendPoint()
	{
		inputMes = "Point" + SchoolID + PointText.text;
		string msg = inputMes;
        byte[] buffer = new byte[1024 * 6];
        buffer = Encoding.UTF8.GetBytes(msg);
        socketSend.Send(buffer);
	}
	
	public void SetServer()
	{
		ServerSettings.ServerIP = ServerIPText.text;
		ServerSettings.ServerPort = ServerPortText.text;
	}
}