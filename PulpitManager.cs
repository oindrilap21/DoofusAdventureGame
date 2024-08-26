using System.Collections;
using UnityEngine;

public class PulpitManager : MonoBehaviour
{
    public GameObject pulpitPrefab;
    public Transform doofus;
    public float minPulpitDestroyTime;
    public float maxPulpitDestroyTime;
    public float pulpitSpawnTime;

    private GameObject currentPulpit;
    private GameObject nextPulpit;

    private void Start()
    {
        StartCoroutine(SpawnPulpit());
    }

    private IEnumerator SpawnPulpit()
    {
        while (true)
        {
            if (nextPulpit == null)
            {
                nextPulpit = Instantiate(pulpitPrefab, GetNewPulpitPosition(), Quaternion.identity);
                nextPulpit.tag = "Pulpit";
                Destroy(nextPulpit, Random.Range(minPulpitDestroyTime, maxPulpitDestroyTime));
            }
            
            if (currentPulpit == null || currentPulpit.transform.position == doofus.position)
            {
                currentPulpit = nextPulpit;
                nextPulpit = null;
            }

            yield return new WaitForSeconds(pulpitSpawnTime);
        }
    }

    private Vector3 GetNewPulpitPosition()
    {
        Vector3 offset = new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9));
        return currentPulpit != null ? currentPulpit.transform.position + offset : Vector3.zero;
    }
}
