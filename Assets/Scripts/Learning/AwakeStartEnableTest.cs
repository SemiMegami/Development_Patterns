using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeStartEnableTest : MonoBehaviour
{

    void Awake()
    {
        Debug.Log("PrintAwake: script was awaken");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("PrintStart: script was started");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        Debug.Log("PrintOnDisable: script was disabled");
    }

    void OnEnable()
    {
        Debug.Log("PrintOnEnable: script was enabled");
    }
}
