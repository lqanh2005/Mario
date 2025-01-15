using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;
    [Header("Charector------------------------------------")]
    public CharacterBase currentCharector;
    [SerializeField] private CharacterBase smallCharectorPrefab;
    [SerializeField] private CharacterBase bigCharectorPrefab;
    [SerializeField] private CharacterBase specialCharectorPrefab;
    [Header("------------------------------------")]

    [SerializeField] private Transform firtPost;
    [SerializeField] private ProCamera2D camera2D;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        currentCharector = Instantiate(smallCharectorPrefab);
        currentCharector.transform.position = firtPost.position;
        camera2D.AddCameraTarget(currentCharector.transform);
    }
    public void ChangeCharector(CharectorType charectorType)
    {

        camera2D.RemoveAllCameraTargets();
        var currentPost = currentCharector.transform.position;
        Destroy(currentCharector.gameObject);
        currentCharector = null;

        switch (charectorType)
        {
            case CharectorType.Small:
                currentCharector = Instantiate(smallCharectorPrefab);

                break;
            case CharectorType.Big:
                currentCharector = Instantiate(bigCharectorPrefab);

                break;
            case CharectorType.Special:
                currentCharector = Instantiate(specialCharectorPrefab);

                break;
        }

        currentCharector.transform.position = currentPost;
        camera2D.AddCameraTarget(currentCharector.transform);

    }


    public void HandleSetCurrentToFirstPossition()
    {
        currentCharector.transform.position = firtPost.position;
    }

}
public enum CharectorType
{
    Small,
    Big,
    Special
}