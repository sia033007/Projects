using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public int score;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Login()
    {
        WWWForm form = new WWWForm();
        form.AddField("Username",username.text);
        form.AddField("Password",password.text);
        UnityWebRequest request = UnityWebRequest.Post("",form);
        yield return request.SendWebRequest();

        if(request.downloadHandler.text[0]=='0')
        {
            Debug.Log("Log in successfully");
            score = int.Parse(request.downloadHandler.text.Split('\t')[1]);
            level = int.Parse(request.downloadHandler.text.Split('\t')[2]);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
        }
    }
}
