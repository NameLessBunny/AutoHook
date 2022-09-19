﻿using AutoHook.Configurations;
using AutoHook.Data;
using AutoHook.Utils;
using FFXIVClientStructs.FFXIV.Client.Game;
using System;

namespace AutoHook.Classes;

#region AutoMakeShiftBait
public sealed class AutoMakeShiftBait : BaseActionCast
{
    public int MakeshiftBaitStacks = 5;

    public AutoMakeShiftBait() : base("MakeShift Bait", IDs.Actions.MakeshiftBait, ActionType.Spell)
    {

    }
    public override bool CastCondition()
    {
        if (!Enabled)
            return false;

        if (PlayerResources.HasStatus(IDs.Status.MakeshiftBait))
            return false;

        if (PlayerResources.HasStatus(IDs.Status.PrizeCatch))
            return false;

        if (PlayerResources.HasStatus(IDs.Status.AnglersFortune))
            return false;


        bool available = PlayerResources.ActionAvailable(IDs.Actions.MakeshiftBait);
        bool hasStacks = PlayerResources.HasAnglersArtStacks(MakeshiftBaitStacks);

        return hasStacks && available;
    }
}
#endregion

#region AutoThaliaksFavor
public sealed class AutoThaliaksFavor : BaseActionCast
{
    public int ThaliaksFavorStacks = 3;
    public int ThaliaksFavorRecover = 150;

    public AutoThaliaksFavor() : base("Thaliak's Favor", IDs.Actions.ThaliaksFavor, ActionType.Spell)
    {

    }

    public override bool CastCondition()
    {

        bool available = PlayerResources.ActionAvailable(IDs.Actions.ThaliaksFavor);
        bool hasStacks = PlayerResources.HasAnglersArtStacks(ThaliaksFavorStacks);
        bool notOvercaped = (PlayerResources.GetCurrentGP() + ThaliaksFavorRecover) < PlayerResources.GetMaxGP();

        return available && hasStacks && notOvercaped; // dont use if its going to overcap gp
    }
}
#endregion

#region AutoChum
public sealed class AutoChum : BaseActionCast
{
    public AutoChum() : base("Chum", IDs.Actions.Chum, ActionType.Spell)
    {
        DoesCancelMooch = true;
    }

    public override bool CastCondition()
    {
        return true;
    }
}
#endregion

#region AutoFishEyes
public class AutoFishEyes : BaseActionCast
{

    public AutoFishEyes() : base("Fish Eyes", IDs.Actions.FishEyes, ActionType.Spell)
    {
        DoesCancelMooch = true;
    }

    public override bool CastCondition()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region IdenticalCast
public sealed class AutoIdenticalCast : BaseActionCast
{
    // this option is based on the custom HookConfig, not the AutoCast tab
    public AutoIdenticalCast() : base("Identical Cast", Data.IDs.Actions.IdenticalCast, ActionType.Spell)
    {
        Enabled = true;
    }

    public override bool CastCondition()
    {
        return HookConfig?.UseIdenticalCast ?? false;
    }
}
#endregion

#region AutoSurfaceSlap
public sealed class AutoSurfaceSlap : BaseActionCast
{

    // this option is based on the custom HookConfig, not the AutoCast tab
    public AutoSurfaceSlap() : base("Surface Slap", Data.IDs.Actions.SurfaceSlap, ActionType.Spell)
    {
        Enabled = true;
    }
    public override bool CastCondition()
    {
        return HookConfig?.UseSurfaceSlap ?? false; ;
    }
}
#endregion

#region AutoPrizeCatch
public class AutoPrizeCatch : BaseActionCast
{

    public AutoPrizeCatch() : base("Prize Catch", Data.IDs.Actions.PrizeCatch, ActionType.Spell)
    {
        DoesCancelMooch = true;
    }

    public override bool CastCondition()
    {
        if (!Enabled)
            return false;

        if (PlayerResources.HasStatus(IDs.Status.MakeshiftBait))
            return false;

        if (PlayerResources.HasStatus(IDs.Status.PrizeCatch))
            return false;

        if (PlayerResources.HasStatus(IDs.Status.AnglersFortune))
            return false;

        return PlayerResources.ActionAvailable(IDs.Actions.PrizeCatch);
    }
}
#endregion

#region AutoPatienceI
public class AutoPatienceI : BaseActionCast
{
    public AutoPatienceI() : base("Patience I", Data.IDs.Actions.Patience, ActionType.Spell)
    {
        DoesCancelMooch = true;
    }

    public override bool CastCondition()
    {
        throw new NotImplementedException();
    }
}
#endregion

#region AutoPatienceII
public class AutoPatienceII : BaseActionCast
{

    public AutoPatienceII() : base("Patience II", Data.IDs.Actions.Patience2, ActionType.Spell)
    {
        DoesCancelMooch = true;
    }

    public override bool CastCondition()
    {
        throw new NotImplementedException();
    }
}
#endregion


#region AutoDoubleHook
public sealed class AutoDoubleHook : BaseActionCast
{
    public AutoDoubleHook() : base("Double Hook", Data.IDs.Actions.DoubleHook, ActionType.Spell)
    {

    }
    public override bool CastCondition()
    {
        return false;
    }
}
#endregion

#region AutoTripleHook
public sealed class AutoTripleHook : BaseActionCast
{
    public AutoTripleHook() : base("Triple Hook", Data.IDs.Actions.TripleHook, ActionType.Spell)
    {

    }
    public override bool CastCondition()
    {
        return false;
    }
}
#endregion


#region HICordial
public class AutoHICordial : BaseActionCast
{
    readonly uint itemGPRecovery = 400;
    public AutoHICordial() : base("Hi-Cordial", Data.IDs.Item.HiCordial, ActionType.Item)
    {
        GPThreshold = itemGPRecovery;
    }

    public override bool CastCondition()
    {
        throw new NotImplementedException();
    }

    public override void SetThreshold(uint newcost)
    {
        if (newcost < itemGPRecovery)
            GPThreshold = itemGPRecovery;
        else
            GPThreshold = newcost;
    }
}
#endregion

#region Cordial
public class AutoCordial : BaseActionCast
{
    readonly uint itemGPRecovery = 300;
    public AutoCordial() : base("Cordial", Data.IDs.Item.HiCordial, ActionType.Item)
    {
        GPThreshold = itemGPRecovery;
    }

    public override bool CastCondition()
    {
        throw new NotImplementedException();
    }

    public override void SetThreshold(uint newcost)
    {
        if (newcost < itemGPRecovery)
            GPThreshold = itemGPRecovery;
        else
            GPThreshold = newcost;
    }
}
#endregion

#region HQCordial
public class AutoHQCordial : BaseActionCast
{

    readonly uint itemGPRecovery = 350;
    public AutoHQCordial() : base("HQ Cordial", Data.IDs.Item.HQCordial, ActionType.Item)
    {
        GPThreshold = itemGPRecovery;
    }

    public override bool CastCondition()
    {
        throw new NotImplementedException();
    }

    public override void SetThreshold(uint newcost)
    {
        if (newcost < itemGPRecovery)
            GPThreshold = itemGPRecovery;
        else
            GPThreshold = newcost;
    }
}
#endregion