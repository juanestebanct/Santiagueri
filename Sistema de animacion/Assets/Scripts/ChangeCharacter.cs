using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class ChangeCharacter : MonoBehaviour
{
    public GameObject[] Character;
    public GameObject PlayerInScene;
    public int CharacterId;
    void Start()
    {
        CharacterId = PlayerPrefs.GetInt("Character");
        if (CharacterId== null)
        {
            CharacterId = 1;
        }
        SpawnCharacter(CharacterId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnCharacter(int character)
    {
        Destroy(PlayerInScene);
        PlayerInScene = Instantiate(Character[character]);
        Debug.Log("personaje instantiado ");
        PlayerPrefs.SetInt("Character", character);
    }
}
