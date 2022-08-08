using UnityEngine;
using System.Collections;

public class StagitDemoScene2 : MonoBehaviour
{


	void Start ()
	{
		
		StartCoroutine (routineMoveShowCity ());

	}

	IEnumerator routineMoveShowCity() {
		EarthEngineCity earthEngineCity = EarthEngineCityController.Instance.getCity ("London","GBR");
		moveCameraToObject (earthEngineCity.gameObject);
		yield return new WaitForSeconds (10f);
		EarthEngineCityController.Instance.showCity ("London","GBR");
		yield return new WaitForSeconds (5f);
		earthEngineCity.hideCity ();
	}

	void moveCameraToObject(GameObject obj) {
		StagitSmoothFollow smoothfollow = Camera.main.GetComponent<StagitSmoothFollow> ();
		smoothfollow.enabled = false;
		smoothfollow.distance = 24f;
		smoothfollow.height = -29f;
		smoothfollow.damping = 0.4f;
		smoothfollow.smoothRotation = true;
		smoothfollow.followBehind = true;
		smoothfollow.rotationDamping = 0.8f;
		smoothfollow.wantedPosition = 0f;
		smoothfollow.target = obj.transform;
		smoothfollow.enabled = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

