using UnityEngine;
using System.Collections;

public class StagitDemoScene : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (routineShowCities ());
	}

	IEnumerator routineShowCities() {
		// Enable all cities for earth view camera
		for (int i = 0; i <= 8; i++) {
			EarthEngineCityController.Instance.enableAllCitiesWithRank (i);
			yield return new WaitForSeconds (0f);
		}
	}

}

