using UnityEngine;

public class NumberControl : MonoBehaviour
{
    public bool isNumber;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isNumber = true;
        FindObjectOfType<SpawnManager>().wayPointList.Remove(gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        isNumber = false;
        FindObjectOfType<SpawnManager>().wayPointList.Add(gameObject);
   
    }

}
