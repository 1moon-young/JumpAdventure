using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;


    private void Awake()
    {
        // instance ��ü�� �ΰ��̻� �������� �ʰ� ��.
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }


    private void Start()
    {
        
    }


}
