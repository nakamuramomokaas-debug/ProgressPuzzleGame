using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] ColorSettings.ColorType colorType;
    public ColorSettings.ColorType ColorType(){return colorType;}
}
