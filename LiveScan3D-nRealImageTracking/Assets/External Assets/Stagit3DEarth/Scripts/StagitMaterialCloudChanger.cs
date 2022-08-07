using UnityEngine;
using System.Collections;

public class StagitMaterialCloudChanger : MonoBehaviour
{

	public float normal_strength = 0.5f;
	public float smoothness_specular = 0.5f;
	public float light_scale = 0.5f;
	public float reflection_shine = 0.22f;
	public float main_brightness = 0.5f;
	public Color32 albedo_color = Color.white;
	private Color32 specular_color = Color.black;


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

			thismaterials[i].SetFloat("_SmoothnessTextureChannel",smoothness_specular);

			thismaterials[i].SetFloat("_Brightness",main_brightness);
			thismaterials[i].SetFloat("_Shininess",reflection_shine);
			thismaterials[i].SetFloat("_NormalStrength",normal_strength);

			thismaterials[i].SetColor("_SpecColor",specular_color);

			thismaterials[i].SetColor("_Color",albedo_color);



			//UnityEditor.AssetDatabase.CreateAsset(thismaterials [i], "Assets/Stagit3DEarth/Objects/Clouds/Materials/" + thismaterials [i].name + ".mat");
		}
	}

}

