using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.AI;

public class Sample : MonoBehaviour
{
    public static Sample sample;
    bool isLocked;
    public NavMeshAgent agent;
    public InputField username;
    public InputField password;
    public int score;
    public int level;
    private void Awake() {
        sample = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("IncreasePoint",5f,5f);
        isLocked = PlayerPrefs.GetInt("Locked")==0?false:true;
        City city1 = new City(2000,"Birjand","IRAN");
        City city2 = new City(1000000,"NewYork","USA");
        city1.MyCity();
        city2.MyCity();
        agent = GetComponent<NavMeshAgent>();
        
    }
    public void IncreasePoint()
    {
        score++;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit,100))
            {
                agent.destination = hit.point;
            }
        }
        if(Input.touchCount>0)
        {
            Touch t = Input.GetTouch(0);
            float midScreen = Screen.width/2;
            if(t.phase == TouchPhase.Began && t.position.x <midScreen)
            {
                transform.Translate(0,2,2);
            }
            if(t.phase ==TouchPhase.Stationary && t.position.x >midScreen)
            {
                transform.Translate(0,-2,1);
            }
        }
    
        
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
public class City
    {
        public int population;
        public string name;
        public string country;

        public City(int mypopulation, string myname, string mycountry)
        {
            population = mypopulation;
            name = myname;
            country = mycountry;
        }
        public void MyCity()
        {
            Debug.Log($"{name} is a city in {country} with {population}");
        }
    }
    

