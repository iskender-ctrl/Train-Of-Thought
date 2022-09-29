using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> locomotive;
    public GameObject target, locomotiveParent;
    public GameObject[] locomotiveObj;
    void Start()
    {
        for (int i = 0; i < locomotiveObj.Length; i++)
        {
            GameObject tmp = Instantiate(locomotiveObj[i].gameObject, target.transform.position, target.transform.rotation, locomotiveParent.transform);
            locomotive.Add(tmp);
            tmp.SetActive(false);
            StartCoroutine(ActiveLocomotive(tmp));
        }
    }
    IEnumerator ActiveLocomotive(GameObject tmp)
    {
        for (int i = 0; i < locomotive.Count; i++)
        {
            yield return new WaitForSeconds(3);
            locomotive[i].gameObject.SetActive(true);
        }
    }
}
