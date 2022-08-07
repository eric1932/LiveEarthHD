using UnityEngine;
using System.Collections;

public class StagitDemoScene3 : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		StartCoroutine (routineMoveShowCountry ());

	}
	
	IEnumerator routineMoveShowCountry() {
		yield return new WaitForSeconds (4f);

		// Search for wales and start highlighting
		EarthEngineCountry[] earthEngineCountry =	EarthEngineCountryController.Instance.searchCountryByName ("Wales");
		for (int i = 0; i < earthEngineCountry.Length; i++) {
			earthEngineCountry [i].startHighLight ();
		}

		yield return new WaitForSeconds (4f);

		// Stop highlighting wales
		for (int i = 0; i < earthEngineCountry.Length; i++) {
			earthEngineCountry [i].stopHighLight ();
		}
		yield return new WaitForSeconds (2f);

		// Start highlighting United Kingdom
		EarthEngineCountry[] earthEngineCountry2 = EarthEngineCountryController.Instance.searchCountryByName ("United Kingdom");
		for (int i = 0; i < earthEngineCountry2.Length; i++) {
			earthEngineCountry2 [i].startHighLight ();
		}

	}
}

