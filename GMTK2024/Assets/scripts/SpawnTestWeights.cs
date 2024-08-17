using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTestWeights : MonoBehaviour
{
    public GameObject weightPrefab;
    
    public GameObject spawnPointLeft;
    public GameObject spawnPointRight;
    public Scales_Balance_Calc scales_Balance_Calc;
    public enum SpawnPlace
    {
        Left,
        Right,
    }


    public void SpawnObjRight(float weight)
    {
        SpawnObj(weight, SpawnPlace.Right);
    }

    public void SpawnObjLeft(float weight)
    {
        SpawnObj(weight, SpawnPlace.Left);
    }
    void SpawnObj(float weight, SpawnPlace spawnPlace)
    {
        if (spawnPlace == SpawnPlace.Left)
        {
            GameObject instantiatedWeight = Instantiate(weightPrefab, spawnPointLeft.transform.position, Quaternion.identity);
           
            
           
            DeleteOnClick thisInstantiatedObjScript = instantiatedWeight.GetComponent<DeleteOnClick>();
            thisInstantiatedObjScript.SetWeightAndSpawnPlace(weight, spawnPlace);
            scales_Balance_Calc.AddWeight(weight, spawnPlace);
        }

        if (spawnPlace == SpawnPlace.Right)
        {
            GameObject instantiatedWeight = Instantiate(weightPrefab, spawnPointRight.transform.position, Quaternion.identity);


            DeleteOnClick thisInstantiatedObjScript = instantiatedWeight.GetComponent<DeleteOnClick>();
            thisInstantiatedObjScript.SetWeightAndSpawnPlace(weight, spawnPlace);
            scales_Balance_Calc.AddWeight(weight, spawnPlace);

        }
    }
}
