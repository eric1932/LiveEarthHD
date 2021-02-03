using UnityEngine;
using System.Collections;

public class EarthEngineCountryController : MonoBehaviour
{

	private static EarthEngineCountryController _instance;

	public GameObject countries;

	void Awake () {
		_instance = this;
	}


	public static EarthEngineCountryController Instance {
		get { return _instance; }
	}


	public EarthEngineCountry[] searchCountryByName(string countryName) {
		EarthEngineCountryData earthEngineCountryData = new EarthEngineCountryData ();

		string adm3Country = earthEngineCountryData.searchAdmin3FromCountry (countryName);
		if (adm3Country != "") {
			Debug.Log ("FOUND ADM3:" + adm3Country);
			return getCountryByADM3 (adm3Country);
		}
		return null;
	}

	public EarthEngineCountry[] getCountryByADM3(string ADM3) {
		foreach(Transform child in transform)
		{
			if (child.name.ToLower() == ADM3.ToLower()) {
				EarthEngineSovCountry earthEngineCountry = child.GetComponent<EarthEngineSovCountry> () as EarthEngineSovCountry;
				Debug.Log ("FOUND SovCountry:" + earthEngineCountry.name);
				return earthEngineCountry.earthEngineCountry;
			}
		}
		foreach(Transform child in countries.transform)
		{
			if (child.name.ToLower() == ADM3.ToLower()) {
				EarthEngineCountry earthEngineCountry = child.GetComponent<EarthEngineCountry> () as EarthEngineCountry;
				EarthEngineCountry[] earthEngineCountries = new EarthEngineCountry[1];
				earthEngineCountries [0] = earthEngineCountry;
				Debug.Log ("FOUND Country:" + earthEngineCountry.name);
				return earthEngineCountries;
			}
		}
		return null;
	}




}

