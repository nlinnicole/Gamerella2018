using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalSelect : MonoBehaviour {

    public static int animalSelection = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void toPiggy()
    {
        animalSelection = 0;
        Debug.Log("changed to piggy");
    }

    public void toBunny()
    {
        animalSelection = 1;
        Debug.Log("changed to bunny");
    }

    public void toMouse()
    {
        animalSelection = 2;
        Debug.Log("changed to mouse");
    }

}
