using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour {

	[Header("Title")]
	public string titleText;
	public int titleFontSize = 24;

	[Header("Bullets")]
	public List<string> bullets = new List<string> ();
	public int bodyFontSize = 16;
	public string bulletPointSymbol = "• ";
	public int indentation = -1;			// How much to indent bullet points (as much as the bullet symbol if negative)

	[Header("Positioning")]
	public float titleY = -0.25f;		// Title text y position (from top of slide)
	public float bodyX = 0.75f;			// Distance from left side of slide to body
	public float bodyY = -0.5f;			// Distance from bottom of title to top of first bullet
	public float bodyDeltaY = 0.25f;	// Distance between bullet points bottoms and tops

	void Start(){
		float y = bodyY;

		//==============================================================================================================
		#region Title
		//==============================================================================================================

		// Create title
		GameObject titleGO = new GameObject (gameObject.name + " Title");
		titleGO.transform.parent = transform;
		titleGO.transform.position = (transform.position.z - 1f) * Vector3.forward;
		titleGO.transform.rotation = Quaternion.identity;
		titleGO.transform.localScale = Vector3.one;

		// Title text mesh
		TextMesh tm = titleGO.AddComponent<TextMesh> ();
		tm.characterSize = 0.03f;
		tm.anchor = TextAnchor.UpperCenter;
		tm.alignment = TextAlignment.Center;
		tm.fontSize = titleFontSize * 12;
		float h=0;
		tm.text = WrapText (titleText, tm, out h);
		y-=h;

		// Title rect transform
		RectTransform rt = titleGO.AddComponent<RectTransform> ();
		rt.anchorMax = new Vector2 (0.5f, 1f);
		rt.anchorMin = new Vector2 (0.5f, 1f);

		// Finally position it
		rt.anchoredPosition = new Vector3 (
			0,
			titleY,
			transform.position.z - 1f
		);
		#endregion
			
		//==============================================================================================================
		#region Body
		//==============================================================================================================

		float lineHeight;
		for(int i=0; i<bullets.Count; i++){
			lineHeight=0;

			// GameObject
			GameObject bulletGO = new GameObject(gameObject.name+" bullet"+ i.ToString ());
			bulletGO.transform.parent = transform;
			bulletGO.transform.position = (transform.position.z - 1f) * Vector3.forward;
			bulletGO.transform.rotation = Quaternion.identity;
			bulletGO.transform.localScale = Vector3.one;

			// TextMesh
			TextMesh tmb = bulletGO.AddComponent<TextMesh> ();
			tmb.characterSize = 0.03f;
			tmb.anchor = TextAnchor.UpperLeft;
			tmb.alignment = TextAlignment.Left;
			if (gameObject.name=="Slide"){
				tmb.anchor=TextAnchor.MiddleCenter;
				tmb.alignment=TextAlignment.Center;
			}
			tmb.fontSize = bodyFontSize * 12;
			tmb.text = bulletPointSymbol + WrapText(bullets[i], tmb, out lineHeight);

			// RectTransform
			RectTransform rtb = bulletGO.AddComponent<RectTransform> ();
			rtb.anchorMax = new Vector2 (0, 1f);
			rtb.anchorMin = new Vector2 (0, 1f);
			if (gameObject.name=="Slide"){
				rtb.anchorMax = new Vector2 (0.5f, 0.5f);
				rtb.anchorMin = new Vector2 (0.5f, 0.5f);
			}

			// Position
			rtb.anchoredPosition = new Vector3 (
				bodyX,
				y,
				transform.position.z - 1f
			);
			y-=lineHeight+bodyDeltaY;
		}
			
		#endregion
	}
		
	string WrapText(string text, TextMesh tm, out float height){
		height = 0;
		string builder = "";
		float rowLimit = 4.3f; //find the sweet spot    
		string[] parts = text.Split(' ');
		for (int i = 0; i < parts.Length; i++){
			tm.text += parts[i] + " ";
			if (tm.GetComponent<Renderer> ().bounds.extents.x > rowLimit){
				height += tm.GetComponent<Renderer> ().bounds.size.y;
				string indentationFiller = "";
				float indentationAmount = 0;
				if (indentation < 0) {
					indentationAmount = bulletPointSymbol.Length;
				} else {
					indentationAmount = indentation;
				}
				for (int j = 0; j < indentationAmount; j++) {
					indentationFiller += " ";
				}
				tm.text = builder.TrimEnd() + System.Environment.NewLine + indentationFiller + parts[i] + " ";
			}
			builder = tm.text;
		}
		tm.text = "";
		height += tm.GetComponent<Renderer> ().bounds.size.y;
		return builder;
	}

	string WrapText(string text, TextMesh tm){
		float height = 0;
		return WrapText (text, tm, out height);
	}

}
