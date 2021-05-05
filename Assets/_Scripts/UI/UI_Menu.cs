using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        
    }
    public void Play(){

        Loader.Load(Loader.Scene.Level1);

        
    }
}
