using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Assist {
    public float cooldown {get;}
    public float duration {get;}
    public bool active {get; set;} = false;
    public AssistTypes assistType {get;}

    public GameObject obj {get; set;}

    public bool cooldownComplete {get; set;} = true;
    
    public Assist(float cooldown, float duration, bool active, AssistTypes assistType) {
        this.cooldown = cooldown;
        this.duration = duration;
        this.active = active;
        this.assistType = assistType;
    }
}