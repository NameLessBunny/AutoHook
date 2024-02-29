﻿using System.Collections.Generic;
using AutoHook.Enums;
using AutoHook.Spearfishing.Enums;
using AutoHook.Utils;

namespace AutoHook.Classes;

public class Fish
{
    public int ItemId { get; set; }
    public HookType HookType { get; set; }
    public BiteType BiteType { get; set; }
    public int InitialBait { get; set; }
    public List<int> Mooches { get; set; } = new();
    public List<int> Predators { get; set; } = new();
    public List<int> Nodes { get; set; } = new();
    public bool IsSpearFish { get; set; } = new();
    public SpearfishSize Size { get; set; } = new();
    public SpearfishSpeed Speed { get; set; } = new();
    public int SurfaceSlap { get; set; } = new();
    public bool OceanFish { get; set; } = new();
    public FishInterval Interval { get; set; } = new();
    
    public string Name => MultiString.GetItemName((uint)ItemId);
 
    public class FishInterval 
    { 
        public int OnTime { get; set; }
        public int OffTime { get; set; }
        public int ShiftTime { get; set; }
    } 
}