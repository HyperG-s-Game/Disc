using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SetUpCurve : MonoBehaviour {
    
    private void Start(){
        GetComponent<MeshRenderer>().material.EnableKeyword("_CuveEnable");
    }
}
