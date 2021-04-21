using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cubes;
    [SerializeField]
    private Transform[] points;
    [SerializeField]
    private float beat = 60 / 130;
    private float timer;
    public float timerScene = 10f;
    public float TimeToLoadScene;
 

    void Update()
    {
        if (timer>beat)
        {
            GameObject cube = Instantiate(cubes[Random.Range(0,3)], points[Random.Range(0, 3)]);
            cube.transform.localPosition = Vector3.zero;
            cube.transform.Rotate(transform.forward, 90 * Random.Range(0, 4));
            timer -= beat;

        }
        timer += Time.deltaTime;
        timerScene += Time.deltaTime;
        if (TimeToLoadScene <= timerScene)
        {
            Invoke("GoToScene", timerScene);
            GoToScene();

        }
    }
    void GoToScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}
