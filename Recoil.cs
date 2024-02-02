using UnityEngine;

public class Recoil : MonoBehaviour
{

    //Rotations
    private Vector3 currentRotation; // current rotation of the object
    private Vector3 targetRotation; // target rotation of the object

    //Hipfire Recoil
    [SerializeField] private float recoilX; // amount of recoil on the X-axis
    [SerializeField] private float recoilY; // amount of recoil on the Y-axis
    [SerializeField] private float recoilZ; // amount of recoil on the Z-axis

    //Settings
    [SerializeField] private float snappiness; // the speed at which the current rotation approaches the target rotation
    [SerializeField] private float returnSpeed; // the speed at which the target rotation returns to zero

    void Update()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime); // gradually moves the target rotation back to zero
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, snappiness * Time.deltaTime); // smoothly interpolates the current rotation towards the target rotation
        transform.localRotation = Quaternion.Euler(currentRotation); // applies the new rotation to the object
    }

    public void RecoilFire()
    {
        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ)); // adds recoil to the target rotation in a random fashion within the specified ranges
    }
}
