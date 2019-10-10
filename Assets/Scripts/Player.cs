using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public List<Tool> tools;
    public TextMeshProUGUI useText;
    private string readyToUse = "Use(E)";
    private string notReadyToUse = "You need a tool";
    private bool inPostion = false;
    private bool useTool = false;
    private SmashBox sBox;
    [SerializeField] Transform ToolPosition;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        useText.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer != 0)
        {
            ToolTimer();
        }
        useTool = Input.GetKeyDown(KeyCode.E);
        if (useTool && timer == 0f)
        {
            UseFix();
        }
    }
    private void ToolTimer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (timer < 0)
        {
            timer = 0;
            GameObject currentTool = tools[0].gameObject;
            tools.RemoveAt(0);
            Destroy(currentTool, 0f);
            sBox.Trigger();
        }
    }

    private void UseFix()
    {
        tools[0].transform.position = ToolPosition.position;
        timer = 2f;
        
    }

    public void CollectTools(Tool tool)
    {
        tools.Add(tool);
    }

    internal void smash(bool touching, SmashBox smashBox)
    {
        if (touching)
        {

            if (tools.Count != 0)
            {
                useText.text = readyToUse;
                sBox = smashBox;
            }
            else
            {
                useText.text = notReadyToUse;
            }
            useText.enabled = true;
            inPostion = true;
        } else
        {
            sBox = null;
            useText.enabled = false;
            inPostion = false;
        }

    }
}
