using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public List<Tool> tools;
    public TextMeshProUGUI useText;
    public TextMeshProUGUI UserHudMessage;
    private float hudTimer = 3f;

    private string readyToUse = "Use(E)";
    private string notReadyToUse = "You need a tool";
    private bool inPostion = false;
    private bool useTool = false;
    private SmashBox sBox;
    [SerializeField] Transform ToolPosition;
    private float timer;
    public Vector3 startingLocation;
    private MachineButton machineButton;
    public bool UsingTool = false;

    private void Awake()
    {
        startingLocation = transform.position;
        UsingTool = false;
    }

    internal void Hurt(string impactMessage, Tool tool)
    {
        if (!tools.Contains(tool))
        {
            transform.position = startingLocation;
            UserHudMessage.text = impactMessage;
            UserHudMessage.enabled = true;
        } 

    }

    // Start is called before the first frame update
    void Start()
    {
        useText.enabled = false;
        UserHudMessage.enabled = false;

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
            if (sBox != null)
            {
                UseFix();
            }
            else if(machineButton != null)
            {
                ToggleMachine();
            }
        }
        if (UserHudMessage.enabled)
        {
            hudTimer -= Time.deltaTime;
            if (hudTimer <= 0f)
            {
                UserHudMessage.enabled = false;
                hudTimer = 3f;
            }
        }
    }

    private void ToggleMachine()
    {
        machineButton.Toggle();
    }

    private void ToolTimer()
    {
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            UsingTool = true;
        }
        else if (timer < 0)
        {
            timer = 0;
            GameObject currentTool = tools[0].gameObject;
            tools.RemoveAt(0);
            Destroy(currentTool, 0f);
            sBox.Trigger();
            UsingTool = false;
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
    public void SetMachine(bool onOff, MachineButton mb)
    {
        if (onOff)
        {
            useText.text = readyToUse;
        }
        
            machineButton = mb;
        
            useText.enabled = onOff;

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
