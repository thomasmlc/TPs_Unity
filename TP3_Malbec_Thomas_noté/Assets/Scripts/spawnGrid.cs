using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class spawnGrid : MonoBehaviour
{
    //Grid size
    public float width;
    public float height;
    public float numberOfWinPoint;
    
    //Element To Spawn
    public Object gridElement;
    public Object winElement;
    public Object blockingWall;
    public Object movingBlock;

    //Undo
    public List<string> lastMovedObject;
    
    //Private variable for elements
    private GameObject movingBlockGameObject;
    
    void Start()
    {
        numberOfWinPoint = 0;
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                if (x == 7 && z == 4)
                {
                    var spawnedElement = Instantiate(winElement, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedElement.name = $"GridElementWin {x} {z}";
                    numberOfWinPoint++;
                }else if (x == 2 && z == 12)
                {
                    var spawnedElement = Instantiate(winElement, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedElement.name = $"GridElementWin {x} {z}";
                    numberOfWinPoint++;
                }else if(x == 11 && z == 9){
                    
                    var spawnedElement = Instantiate(gridElement, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedElement.name = $"GridElement {x} {z}";
                    
                    var spawnedInteractiveElement = Instantiate(movingBlock, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedInteractiveElement.name = $"GridElementMove {x} {z}";
                    movingBlockScript script = GameObject.Find($"GridElementMove {x} {z}").GetComponent<movingBlockScript>();
                    script.x = x;
                    script.z = z;

                }else if(x == 12 && z == 2){
                    
                    var spawnedElement = Instantiate(gridElement, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedElement.name = $"GridElement {x} {z}";
                    
                    var spawnedInteractiveElement = Instantiate(movingBlock, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedInteractiveElement.name = $"GridElementMove {x} {z}";
                    movingBlockScript script = GameObject.Find($"GridElementMove {x} {z}").GetComponent<movingBlockScript>();
                    script.x = x;
                    script.z = z;

                }else if(x == 10 && z == 7){
                    var spawnedInteractiveElement = Instantiate(blockingWall, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedInteractiveElement.name = $"GridElementBlock {x} {z}";
                }else if(x == 9 && z == 7){
                    var spawnedInteractiveElement = Instantiate(blockingWall, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedInteractiveElement.name = $"GridElementBlock {x} {z}";
                }else if(x == 8 && z == 7){
                    var spawnedInteractiveElement = Instantiate(blockingWall, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedInteractiveElement.name = $"GridElementBlock {x} {z}";
                }else if(x == 10 && z == 5){
                    var spawnedInteractiveElement = Instantiate(blockingWall, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedInteractiveElement.name = $"GridElementBlock {x} {z}";
                }else if(x == 10 && z == 4){
                    var spawnedInteractiveElement = Instantiate(blockingWall, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedInteractiveElement.name = $"GridElementBlock {x} {z}";
                }
                else
                {
                    var spawnedElement = Instantiate(gridElement, new Vector3(transform.position.x + x, transform.position.y, transform.position.z - z), Quaternion.identity);
                    spawnedElement.name = $"GridElement {x} {z}";
                }
                
            }
        }
    }

    private void Update()
    {
        if (numberOfWinPoint == 0)
        {
            Debug.Log("FIN");
            EditorApplication.isPlaying = false;
            Application.Quit();
        }
    }

    public void Undo()
    {
       
        if (lastMovedObject.Count != 0 && GameObject.Find(lastMovedObject[lastMovedObject.Count - 1]) != null )
        {
            movingBlockScript script = GameObject.Find(lastMovedObject[lastMovedObject.Count - 1]).GetComponent<movingBlockScript>();
            
            float x = script.previousPlace[script.previousPlace.Count - 1][0];
            Debug.Log(x);
            float z = script.previousPlace[script.previousPlace.Count - 1][1];
            Debug.Log(z);

            script.previousPlace.RemoveAt(script.previousPlace.Count - 1);
            
            Debug.Log(lastMovedObject);
            GameObject.Find(lastMovedObject[lastMovedObject.Count - 1]).transform.position =  GameObject.Find($"GridElement {x} {z}").transform.position;
            GameObject.Find(lastMovedObject[lastMovedObject.Count - 1]).name = $"GridElementMove {x} {z}";
            script.x = x;
            script.z = z;

            lastMovedObject.RemoveAt(lastMovedObject.Count - 1);
        }
        else
        {
            Debug.Log("Nothing to undo");
        }
    } 
}

