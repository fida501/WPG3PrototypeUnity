using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool IsTriggered { get; set; }
    void SetTriggerStatus(bool isTriggered);
    
    bool IsChased { get; set; }
    void SetChaseStatus(bool isChased);
    
    
}
