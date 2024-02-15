using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Start() {
        CardDatabase.self.LoadCardData();
        foreach (var item in CardDatabase.self.cardDatabase)
        {
            Debug.Log(item.ToString());
        }
        CardHandler.newMonth(1);
    }
}
