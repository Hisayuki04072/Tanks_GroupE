using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using WebSocketSharp;
using UnityEditor.PackageManager;
public class RankingDialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Top_Info;//Top10�̏���\��
    [SerializeField] private TextMeshProUGUI My_Info;//�����̏���\��
    private string currentUsername;
    private string currentUserID;

    private WebSocket ws;
    // Start is called before the first frame update
    void Start()
    {
        ws = new WebSocket("ws://localhost:8765");//�ύX�\��A�قȂ�f�o�C�X����ł��T�[�o�ɒʐM�ł���悤�ɂ�����
        ws.OnMessage += OnMessageReceived;//OnMessageReceived���\�b�h���C�x���g�n���h���Ƃ��ēo�^�A���b�Z�[�W��M������
        ws.OnError += OnError;
        ws.Connect();

        currentUserID = PlayerPrefs.GetString("UserID");
        Update_Win_Lose();//�������񓯊��Ȃ̂ł����ő��v���H
    }
    private void Update_Win_Lose()
    { 
    
    }

    private void Print_Top10_MY()
    { 
        
    }
    private void OnMessageReceived(object sender, MessageEventArgs e)//���X�g�^���Ńf�[�^�������Ă���̂œK�X�C��
    {
        var response = JsonUtility.FromJson<ResponseData>(e.Data);
        Debug.Log("In OnMessageReceived function display status:" + response.status);
        Debug.Log("In OnMessageReceived function display user_id:" + response.user_id);
    }
    private void OnError(object sender, WebSocketSharp.ErrorEventArgs e)//�G���[�n���h���[
    {
        Debug.LogError("WebSocket Error: " + e.Message);
        if (e.Exception != null)
        {
            Debug.LogError("Exception details: " + e.Exception.ToString());
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
