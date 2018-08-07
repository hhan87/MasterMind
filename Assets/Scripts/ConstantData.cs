﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class ConstantData
{
    public static ConstantData instance;
    public static ConstantData GetInstance()
    {
        if (instance == null)
        {
            instance = new ConstantData();
        }
        return instance;
    }
    private ConstantData()
    {

    }

    public string[][] GetFacilitiesInfo()
    {
        //pBuildingId, pName,pDisplayStringActivated, pDisplayStringInactivated, pPrice
        return new string[][]
        {//id, Name, ActivatedRequiredResource, ProcessRequiredResource, 
            //ProcessRequiredArmy, ResultResource, ResultArmy
            new string[] {"1","Power Plant",           "1 1 0 0 0", "0 0 0 0 0", "0 0", "3 0 0 0 0", "0 0" },
            new string[] {"1","Ore Mine",              "2 2 0 0 0", "0 0 0 0 0", "0 0", "0 1 0 0 0", "0 0" },
            new string[] {"1","Micro Chips Plant",     "3 3 0 0 0", "0 1 0 0 0", "0 0", "0 0 2 0 0", "0 0" },
            new string[] {"1","Ingot Plant",           "4 4 0 0 0", "0 1 0 0 0", "0 0", "0 0 0 1 0", "0 0" },
            new string[] {"1","Newclear Silo",         "5 5 0 0 0", "3 0 0 2 0", "0 0", "0 0 0 0 1", "0 0" },
            new string[] {"1","Adv Power Plant",       "0 1 0 0 0", "0 0 0 0 0", "0 0", "0 0 0 0 0", "0 0" },
            new string[] {"1","Adv Ore Mine",          "0 1 0 0 0", "0 0 0 0 0", "0 0", "0 0 0 0 0", "0 0" },
            new string[] {"1","Adv Micro Chips Plant", "3 0 0 2 0", "0 0 0 0 0", "0 0", "0 0 0 0 0", "0 0" },
            new string[] {"1","Adv Ingot Plant",       "0 3 0 0 0", "0 0 0 0 0", "0 0", "0 0 0 0 0", "0 0" },
        };
    }

    public LambdaFuncInt[] GetOnClickEvents()
    {
        //pBuildingId, pName,pDisplayStringActivated, pDisplayStringInactivated, pPrice
        LambdaFuncInt type1 = (int id) =>
        {
            Facility fac = DataController_han.GetInstance().GetFacilities()[(id - 1)];
            if (fac.CheckIsActivated())
            {
                DataController_han.GetInstance().FacilityProduce(id);
                Debug.Log(fac.GetName()+" do something!");
                GameManager_han.GetInstance().Refresh();
            }
            else
            {
                DataController_han.GetInstance().ActivateFacility(id);
                GameManager_han.GetInstance().Refresh();
            }
            
        };
        LambdaFuncInt type2 = (int id) =>
        {
            DataController_han.GetInstance().ActivateFacility(id);
            GameManager_han.GetInstance().Refresh();
        };
        return new LambdaFuncInt[]
        {//id, Name, Required
            type1
        };
    }

}
