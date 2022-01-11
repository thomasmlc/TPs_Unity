using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnPlayer : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GameObject instanciatedPlayer = Instantiate(player);
        instanciatedPlayer.transform.position = GameObject.Find("SpawnPoint").transform.position;
    }

}
