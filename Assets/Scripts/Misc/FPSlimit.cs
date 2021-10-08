using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSlimit : MonoBehaviour
{
    // Start is called before the first frame update

    void Awake()
    {
#if UNITY_EDITOR
     QualitySettings.vSyncCount = 0;  // VSync must be disabled
     Application.targetFrameRate = 60;
#endif
    }
}
