using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TerminalInfo", menuName = "TerminalInfo")]
public class TerminalInfo : ScriptableObject
{
    public Material currentScreenMaterial = null;
    public Material currentLeft = null;
    public Material currentRight = null;
}
