using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CloudSystem : MonoBehaviour
    {
        public Vector3 windDirection = Vector2.left;
        public float windSpeed = 0.002f;
        public float minSpeed = 0.001f;
        public float resetRadius = 10;
        Transform[] clouds;
        float[] speeds;


        void Start()
        {
            clouds = new Transform[transform.childCount];
            speeds = new float[transform.childCount];
            for (var i = 0; i < transform.childCount; i++)
            {
                clouds[i] = transform.GetChild(i);
                speeds[i] = Random.value;
            }
        }

        void Update()
        {   //Se generan las nubes con velocidad random 
            for (var i = 0; i < speeds.Length; i++)
            {
                var cloud = clouds[i];
                var speed = Mathf.Lerp(minSpeed, windSpeed, speeds[i]);
                cloud.position += windDirection * speed;
                if (cloud.localPosition.x < -resetRadius - 1)//Verifica que la nube en X este fuera del radio
                {
                    cloud.position = new Vector3 (transform.position.x + resetRadius, Random.Range(-resetRadius+1, resetRadius-1), 0);
                }   //La nueva posicion X de la nube se calcula sumando el radio al centro
            }       //Para la posicion Y se genera un numero random entre el radio negativo +1 y positivo -1 
        }

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, resetRadius);// Se genera un circulo
        }
    }
