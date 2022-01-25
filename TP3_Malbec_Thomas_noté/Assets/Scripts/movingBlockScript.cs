using System.Collections.Generic;
using UnityEngine;

public class movingBlockScript : MonoBehaviour
{
    public float x;
    public float z;

    public List<float[]> previousPlace = new List<float[]>();
    
    void OnCollisionEnter(Collision collision)
    {
        Vector3 hit = collision.contacts[0].normal;
        float angle = Vector3.Angle(hit, Vector3.forward);
        
        if (Mathf.Approximately(angle, 0))
        {
            //FRONT
            if (GameObject.Find($"GridElement {x} {z - 1}"))
            {
                transform.position = GameObject.Find($"GridElement {x} {z - 1}").transform.position;
                previousPlace.Add(new []{x, z});
                z -= 1;
                this.name = $"GridElementMove {x} {z}";
                spawnGrid spawnGridScript = GameObject.Find($"GridSpawner").GetComponent<spawnGrid>();
                spawnGridScript.lastMovedObject.Add(this.name);
                
            }else if (GameObject.Find($"GridElementWin {x} {z - 1}"))
            {
                transform.position = GameObject.Find($"GridElementWin {x} {z - 1}").transform.position;
                GameObject.Find($"GridElementWin {x} {z - 1}").name = "GridElementWinValid";
                previousPlace.Add(new []{x, z});
                x = 99999;
                z = 99999;
                this.name = $"GridElementMove {x} {z}";
                
                spawnGrid spawnGridScript = GameObject.Find($"GridSpawner").GetComponent<spawnGrid>();
                spawnGridScript.lastMovedObject.Add(this.name);
                spawnGridScript.numberOfWinPoint--;
                
            }
        };
        
        if(Mathf.Approximately(angle, 180))
        {
            //BACK
            if (GameObject.Find($"GridElement {x} {z + 1}"))
            {
                transform.position = GameObject.Find($"GridElement {x} {z + 1}").transform.position;
                z += 1;
                this.name = $"GridElementMove {x} {z}";
                spawnGrid spawnGridScript = GameObject.Find($"GridSpawner").GetComponent<spawnGrid>();
                spawnGridScript.lastMovedObject.Add(this.name);
            }else if(GameObject.Find($"GridElementWin {x} {z + 1}"))
            {
                transform.position = GameObject.Find($"GridElementWin {x} {z + 1}").transform.position;
                GameObject.Find($"GridElementWin {x} {z + 1}").name = "GridElementWinValid";
                previousPlace.Add(new []{x, z});
                x = 99999;
                z = 99999;
                this.name = $"GridElementMove {x} {z}";
                spawnGrid spawnGridScript = GameObject.Find($"GridSpawner").GetComponent<spawnGrid>();
                spawnGridScript.lastMovedObject.Add(this.name);
                spawnGridScript.numberOfWinPoint--;
            }
        };
        
        if(Mathf.Approximately(angle, 90))
        {
            Vector3 cross = Vector3.Cross(Vector3.forward,hit);
            if (cross.y > 0)
            {
                //RIGHT
                if (GameObject.Find($"GridElement {x + 1} {z}"))
                {
                    transform.position = GameObject.Find($"GridElement {x + 1} {z}").transform.position;
                    previousPlace.Add(new []{x, z});
                    x += 1;
                    this.name = $"GridElementMove {x} {z}";
                    spawnGrid spawnGridScript = GameObject.Find($"GridSpawner").GetComponent<spawnGrid>();
                    spawnGridScript.lastMovedObject.Add(this.name);
                }else if(GameObject.Find($"GridElementWin {x + 1} {z}"))
                {
                    transform.position = GameObject.Find($"GridElementWin {x + 1} {z}").transform.position;
                    GameObject.Find($"GridElementWin {x + 1} {z}").name = "GridElementWinValid";
                    previousPlace.Add(new []{x, z});
                    x = 99999;
                    z = 99999;
                    this.name = $"GridElementMove {x} {z}";
                    spawnGrid spawnGridScript = GameObject.Find($"GridSpawner").GetComponent<spawnGrid>();
                    spawnGridScript.lastMovedObject.Add(this.name);
                    spawnGridScript.numberOfWinPoint--;
                }
            }
            else
            {
                //LEFT
                if (GameObject.Find($"GridElement {x - 1} {z}"))
                {
                    transform.position = GameObject.Find($"GridElement {x - 1} {z}").transform.position;
                    this.previousPlace.Add(new []{x, z});
                    x -= 1;
                    this.name = $"GridElementMove {x} {z}";
                    spawnGrid spawnGridScript = GameObject.Find($"GridSpawner").GetComponent<spawnGrid>();
                    spawnGridScript.lastMovedObject.Add(this.name);
                }else if(GameObject.Find($"GridElementWin {x - 1} {z}"))
                {
                    transform.position = GameObject.Find($"GridElementWin {x - 1} {z}").transform.position;
                    GameObject.Find($"GridElementWin {x - 1} {z}").name = "GridElementWinValid";
                    previousPlace.Add(new []{x, z});
                    x = 99999;
                    z = 99999;
                    this.name = $"GridElementMove {x} {z}";
                    spawnGrid spawnGridScript = GameObject.Find($"GridSpawner").GetComponent<spawnGrid>();
                    spawnGridScript.lastMovedObject.Add(this.name);
                    spawnGridScript.numberOfWinPoint--;
                }
            }
        }
    }
}