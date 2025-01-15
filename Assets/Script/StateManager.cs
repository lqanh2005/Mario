using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject smallCharacter;
    public GameObject bigCharacter;
    public GameObject specialCharacter;

    private CharacterBase currentState;
    private void Start()
    {
        SetState(bigCharacter);
    }
    public void SetState(GameObject prefab)
    {
        if (currentState != null)
        {
            Destroy(currentState.gameObject);
        }
        GameObject newState = Instantiate(prefab, transform.position, Quaternion.identity);
        currentState = newState.GetComponent<CharacterBase>();
        if (currentState != null)
        {
            currentState.Init();
        }
        else
        {
            Debug.LogError("None");
        }
    }
    private void Update()
    {
        if (currentState != null)
        {
            this.transform.position = currentState.transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mushroom"))
        {
            SetState(smallCharacter);
        }
        else if (other.gameObject.CompareTag("Heart"))
        {
            SetState(specialCharacter);
        }
    }
}
