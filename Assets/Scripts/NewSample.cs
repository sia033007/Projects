using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        City city1 = new City(100,"Tabriz","IRAN");
        City city2 = new City(1000,"Najaf","IRAQ");
        City city3 = new City(500,"Moscow","RUSSIA");

        Debug.Log(city3.name);
        Debug.Log(city2.country);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
