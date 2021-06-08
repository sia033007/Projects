using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.AI;

public class Sample : MonoBehaviour
{
    public NavMeshAgent agent;
    public InputField username;
    public InputField password;
    public int score;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        City city1 = new City(2000,"Birjand","Iran");
        City city2 = new City(1000000,"NewYork","USA");
        city1.MyCity();
        city2.MyCity();
        agent = GetComponent<NavMeshAgent>();
        
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
}
