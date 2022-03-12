using System.Collections;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{
    public GameObject[] cars;
    public GameObject[] Vodomet;
    public GameObject[] _zabor;
    public GameObject[] _boxMolotov;


    private float[] positions = { -3.11f, -1.63f, -0.4f, 1f };
    void Start()
    {
        StartCoroutine(spawn());
        StartCoroutine(spawn_voda());
        StartCoroutine(spawn_prigrada());
        StartCoroutine(spawn_Molotov());
        


    }
    IEnumerator spawn()
    {
        while (true)
        {
            Instantiate(cars[Random.Range(0, cars.Length)],
               new Vector3(17,positions[Random.Range(0,positions.Length)], 0),
               Quaternion.Euler(new Vector3(0,0,0))
                );
            yield return new WaitForSeconds(2.5f);

        }

    }


    IEnumerator spawn_voda()
    {
        while (true)
        {
            Instantiate(Vodomet[Random.Range(0, Vodomet.Length)],
                          new Vector3(17, positions[Random.Range(0, positions.Length)], 0),
                          Quaternion.Euler(new Vector3(0, 0, 0))
                           );
            yield return new WaitForSeconds(20f);

        }

    }

    IEnumerator spawn_prigrada()
    {
        while (true)
        {
            Instantiate(_zabor[Random.Range(0, _zabor.Length)],
              new Vector3(17, positions[Random.Range(0, positions.Length)], 0),
              Quaternion.Euler(new Vector3(0, 0, 0))
               );
            yield return new WaitForSeconds(8f);
        }

    }

    IEnumerator spawn_Molotov()
    {
        while (true)
        {
            Instantiate(_boxMolotov[Random.Range(0, _boxMolotov.Length)],
              new Vector3(17, positions[Random.Range(0, positions.Length)], 0),
              Quaternion.Euler(new Vector3(0, 0, 0))
               );
            yield return new WaitForSeconds(10f);
        }

    }

}
