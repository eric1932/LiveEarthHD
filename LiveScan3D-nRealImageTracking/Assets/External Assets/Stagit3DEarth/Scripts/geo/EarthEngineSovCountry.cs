using UnityEngine;
using System.Collections;

public class EarthEngineSovCountry : MonoBehaviour
{
	public EarthEngineCountry[] earthEngineCountry;
	public string continent;
	public string region_un;
	public string subregion;
	public string countryName;
	public int population;
	public string adminA3;


	void OnDrawGizmosSelected() {
		GameObject mainEarth = GameObject.Find ("MainEarth");
		StagitMainEarth stagitMainEarth = mainEarth.GetComponent<StagitMainEarth>();

		if (stagitMainEarth.ShowSovCountryBorders) {
			foreach(EarthEngineCountry country in earthEngineCountry) {
				country.drawGizmo ();
			}
		}
	}

}

