using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class GenerateOfInteractiveObjects : MonoBehaviour
{
    [SerializeField, Range(1, 20)]
    private int amountOfInteractiveObject;

    public GameObject[] InteractiveObjects;
    public Vector3[] InteractiveObjectsPositions;
    public GameObject[] VariantInteractiveObjects;
    public int[] VariantInteractiveObject;
    private int _quantityVariantInteractiveObject = 5;
    public SaveData SaveDatas;

    public void RandomInitializeInteractiveObjects()
    {
        InteractiveObjects = new GameObject[amountOfInteractiveObject];
        InteractiveObjectsPositions = new Vector3[amountOfInteractiveObject];
        VariantInteractiveObject = new int[amountOfInteractiveObject];
        
        for (int i=0; i < amountOfInteractiveObject; i++)
        {
            InteractiveObjectsPositions[i] = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
            VariantInteractiveObject[i] = Random.Range(0, _quantityVariantInteractiveObject);
            InteractiveObjects[i] = Instantiate(VariantInteractiveObjects[VariantInteractiveObject[i]], InteractiveObjectsPositions[i], Quaternion.identity);
        }
    }
    public void LoadInitializeInteractiveObjects ()
    {
        InteractiveObjects = new GameObject[amountOfInteractiveObject];
        InteractiveObjectsPositions = new Vector3[amountOfInteractiveObject];
        VariantInteractiveObject = new int[amountOfInteractiveObject];
        string json = "";
        using (var reader = new StreamReader("Assets//SaveData/Save.json"))
        {
            string line;
            for (int i = 0; i < amountOfInteractiveObject; i++)
            {
                line = reader.ReadLine();
                json += line;
                SaveDatas = JsonUtility.FromJson<SaveData>(line);
                InteractiveObjectsPositions[i] = SaveDatas.InteractiveObjectsPosition;
                VariantInteractiveObject[i] = SaveDatas.QuantityVariantInteractiveObject;          
            }
        }
        for (int i = 0; i < amountOfInteractiveObject; i++)
        {
            InteractiveObjects[i] = Instantiate(VariantInteractiveObjects[VariantInteractiveObject[i]], InteractiveObjectsPositions[i], Quaternion.identity);
        }
    }
    public void SaveInteractiveObjects()
    {
        using (var writer = new StreamWriter("Assets//SaveData/Save.json", false))
        {
            for (int i = 0; i < amountOfInteractiveObject; i++)
            {
                SaveDatas.QuantityVariantInteractiveObject = VariantInteractiveObject[i];
                SaveDatas.InteractiveObjectsPosition = InteractiveObjectsPositions[i];
                var json = JsonUtility.ToJson(SaveDatas);
                writer.WriteLine(json);
                Debug.Log(json);
            }
        }
        
    }
    public void ClearInteractiveObjects()
    {
        for (int i = 0; i < amountOfInteractiveObject; i++)
        {
            Destroy(InteractiveObjects[i]);
        }
    }

}
[System.Serializable]
public class SaveData
{
    public int QuantityVariantInteractiveObject;
    public Vector3 InteractiveObjectsPosition;
}
