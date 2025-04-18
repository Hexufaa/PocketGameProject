using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArtManager : Singleton<ArtManager>
{
 
    public enum ArtType
    {
        TYPE_01,
        TYPE_02,
        TYPE_03,
        TYPE_04,
    }
    public List<ArtSetup> artSetups;
}

[System.Serializable]
public class ArtSetup
{

    public ArtManager.ArtType artType;
    public GameObject gameObject;

}