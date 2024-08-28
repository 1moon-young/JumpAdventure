using System.Collections;
using Unity.Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;

    [Header("Respawn info")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float respawnDelay;

    [SerializeField] private CinemachineCamera cine;

    [Header("Fruits info")]
    public bool fruitsRandomLook;
    public int fruitsCollected;

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

    public void RespawnPlayer() => StartCoroutine(RespawnLogic());

    private IEnumerator RespawnLogic()
    {
        yield return new WaitForSeconds(respawnDelay);

        GameObject newPlayer = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        player = newPlayer.GetComponent<Player>();
        cine.Follow = player.transform;
    }

    // ������ ��ġ ������Ʈ �Լ�
    public void UpdateRespawnPosition(Transform _newRespawnPoint)
    {
        respawnPoint = _newRespawnPoint;
    }

    #region Fruits

    // ���� ���� ���� �Լ�
    public void AddFruit() => fruitsCollected++;

    public bool FruitsRandomLook() => fruitsRandomLook;

    #endregion
}
