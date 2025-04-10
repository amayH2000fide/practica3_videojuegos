using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que entra en contacto es el jugador
        if (other.CompareTag("Player"))
        {
            // Accedemos al script del jugador y sumamos 1 al contador
            PlayerCollector collector = GetComponentInParent<PlayerCollector>();

            if (collector != null)
            {
                collector.AddCollectible();
                Destroy(gameObject);
            } else
            {
                Debug.LogError("¡collectibleText no está asignado en el Inspector!");
            }
          
        }
    }
}
