using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    const int StageChipSize = 30;

    int currentChipIndex;

    public Transform character;
    public GameObject[] stageChips;
    public int startChipIndex;
    public int preInstantiate;
    public List<GameObject> generatedStageList = new List<GameObject>();

    private void Start()
    {
        currentChipIndex = startChipIndex - 1;
        UpdateStage(preInstantiate);
    }

    private void Update()
    {
        int charaPositionIndex = (int)(character.position.z / StageChipSize);

        if(charaPositionIndex+preInstantiate>currentChipIndex)
        {
            UpdateStage(charaPositionIndex + preInstantiate);
        }
    }

    void UpdateStage(int toChipIndex)
    {
        if (toChipIndex <= currentChipIndex) return;

        for (int i = currentChipIndex + 1; i <= toChipIndex;i++)
        {
            GameObject stageObject = GenerateStage(i);
            generatedStageList.Add(stageObject);
        }

        while (generatedStageList.Count > preInstantiate + 2) Destroy01destStage();

        currentChipIndex = toChipIndex;
    }

    GameObject GenerateStage(int chipIndex)
    {
        int nextStageChip = Random.Range(0, stageChips. Length);

        GameObject stageObject = (GameObject)Instantiate(stageChips[nextStageChip], new Vector3(0, 0, chipIndex * StageChipSize), Quaternion.identity);

        return stageObject;
    }

    void Destroy01destStage()
    {
        GameObject oldStage = generatedStageList[0];
        generatedStageList.RemoveAt(0);
        Destroy(oldStage);
    }
}
