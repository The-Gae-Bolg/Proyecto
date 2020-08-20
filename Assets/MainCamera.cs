using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Transform target;
    float tLX, tLY, bRX, bRY;

    void Awake(){
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Mathf.Clamp(target.position.x,tLX,bRX),
            Mathf.Clamp(target.position.y,bRY,tLY),
            transform.position.z
        );
    }
    //Obtiene el tamaño de los tiles del mapa
    public void SetBound (GameObject map) {
        Tiled2Unity.TiledMap config = map.GetComponent<Tiled2Unity.TiledMap>();
        float cameraSize = Camera.main.orthographicSize;

        //La camara se centra al entrar a la casa
        if(map.tag == "Mini_Zonas"){
            tLX = map.transform.position.x + cameraSize + 1;
            tLY = map.transform.position.y - cameraSize;
            bRX = map.transform.position.x + config.NumTilesWide - cameraSize - 1;
            bRY = map.transform.position.y - config.NumTilesHigh + cameraSize;
        }else{
            tLX = map.transform.position.x + cameraSize + 4;
            tLY = map.transform.position.y - cameraSize;
            bRX = map.transform.position.x + config.NumTilesWide - cameraSize - 4;
            bRY = map.transform.position.y - config.NumTilesHigh + cameraSize;
        }


    }
}
