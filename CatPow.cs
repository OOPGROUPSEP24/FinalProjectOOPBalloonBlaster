Using UnityEngine; //fasya

public class CatPow : MonoBehaviour
{
    public float CatPowDuration = 1f;

    private void Start()
    {
        Debug.Log("CatPow instantiated at position: " + transform.position);


        Destroy(gameObject, CatPowDuration);
    }
}
