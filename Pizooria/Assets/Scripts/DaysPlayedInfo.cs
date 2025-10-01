using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaysPlayedInfo : IGameoverInfo
{
    
    private int days;
    public DaysPlayedInfo(int days)
    {
        this.days = days;
    }
    public string GetLabel() => "Days";
    public string GetValue() => days.ToString();
    
}
