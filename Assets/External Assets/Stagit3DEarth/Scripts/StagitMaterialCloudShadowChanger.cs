using UnityEngine;
using System.Collections;

public class StagitMaterialCloudShadowChanger : MonoBehaviour
{
	public float main_brightness = 0.5f;
	public bool SetMaterial = false;

	void OnDrawGizmos() {
		if (SetMaterial) {
			SetMaterial = false;
			Debug.Log ("Setting Material");
			changeMaterials ();
		}
	}

	private void changeMaterials() {
		Material[] thismaterials;
		thismaterials = this.GetComponent<Renderer> ().sharedMaterials;
		for (int i = 0; i < thismaterials.Length; i++) {
			thismaterials [i].name = thismaterials [i].name.Replace (" (Instance)", "");
			thismaterials[i].SetFloat("_ShadowsLight",main_brightness);
			//UnityEditor.AssetDatabase.CreateAsset(thismaterials [i], "Assets/Stagit3DEarth/Objects/Clouds/ShadowMaterials/" + thismaterials [i].name + ".mat");
		}
	}
}

