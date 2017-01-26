using UnityEngine;

public class TargetObject : MonoBehaviour
{
    private Vector3 targetpos;

    private void Start()
    {
        targetpos = transform.position;
    } 

    void OnMouseDrag()
    {
        Vector3 objectPointInScreen
            = Camera.main.WorldToScreenPoint(this.transform.position);

        Vector3 mousePointInScreen
            = new Vector3(Input.mousePosition.x,
                          Input.mousePosition.y,
                          objectPointInScreen.z);

        Vector3 mousePointInWorld = Camera.main.ScreenToWorldPoint(mousePointInScreen);
		//mousePointInWorld.z = this.transform.position.z;
		mousePointInWorld.y = this.transform.position.y;
        this.transform.position = mousePointInWorld;
    }

    private void Update()
    {
        /*if (Input.GetMouseButtonUp(0))
        {

            transform.position = new Vector3(targetpos.x, targetpos.y, targetpos.z);
            }*/
    } 
}