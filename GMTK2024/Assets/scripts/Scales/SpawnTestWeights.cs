using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SpawnTestWeights;

public class SpawnTestWeights : MonoBehaviour
{
    public GameObject weightPrefab;
    public GameObject heartPrefab;
    public float lightHeartWeight = 0;
    public float heavyHeartWeight = 5;

    public GameObject spawnPointLeft;
    public GameObject spawnPointRight;
    public Scales_Balance_Calc scales_Balance_Calc;
    public enum SpawnPlace
    {
        Left,
        Right,
    }

    private void Start()
    {
       //  SpawnObjRight(1f); // debug
    }
    public void SpawnObjRight(float weight)
    {
        SpawnObj(weight, SpawnPlace.Right);
    }

    public void SpawnObjLeft(float weight)
    {
        SpawnObj(weight, SpawnPlace.Left);
    }

    public void SpawnHeartLeft(bool isHeavy)
    {
        if (isHeavy)
        {
            GameObject instantiatedWeight = Instantiate(heartPrefab, spawnPointLeft.transform.position, Quaternion.identity);



            DeleteOnClick thisInstantiatedObjScript = instantiatedWeight.GetComponent<DeleteOnClick>();
            thisInstantiatedObjScript.SetWeightAndSpawnPlace(heavyHeartWeight, SpawnPlace.Left);
            scales_Balance_Calc.AddWeight(heavyHeartWeight, SpawnPlace.Left);
        }
        else
        {
            GameObject instantiatedWeight = Instantiate(heartPrefab, spawnPointLeft.transform.position, Quaternion.identity);



            DeleteOnClick thisInstantiatedObjScript = instantiatedWeight.GetComponent<DeleteOnClick>();
            thisInstantiatedObjScript.SetWeightAndSpawnPlace(lightHeartWeight, SpawnPlace.Left);
            scales_Balance_Calc.AddWeight(lightHeartWeight, SpawnPlace.Left);
        }
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
