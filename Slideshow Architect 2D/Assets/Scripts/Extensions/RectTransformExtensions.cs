// Class to handle rect transforms easier. Credit to http://orbcreation.com/orbcreation/page.orb?1099 (no name found).

using UnityEngine;
using System;
using System.Collections;

public static class RectTransformExtensions
{
	public static void SetDefaultScale(this RectTransform trans) {
		trans.localScale = new Vector3(1, 1, 1);
	}
	public static void SetPivotAndAnchors(this RectTransform trans, Vector2 aVec) {
		trans.pivot = aVec;
		trans.anchorMin = aVec;
		trans.anchorMax = aVec;
	}

	public static Vector2 GetSize(this RectTransform trans) {
		return trans.rect.size;
	}
	public static float GetWidth(this RectTransform trans) {
		return trans.rect.width;
	}
	public static float GetHeight(this RectTransform trans) {
		return trans.rect.height;
	}

	public static void SetPositionOfPivot(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x, newPos.y, trans.localPosition.z);
	}

	public static void SetLeftBottomPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
	}
	public static void SetLeftTopPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x + (trans.pivot.x * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
	}
	public static void SetRightBottomPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y + (trans.pivot.y * trans.rect.height), trans.localPosition.z);
	}
	public static void SetRightTopPosition(this RectTransform trans, Vector2 newPos) {
		trans.localPosition = new Vector3(newPos.x - ((1f - trans.pivot.x) * trans.rect.width), newPos.y - ((1f - trans.pivot.y) * trans.rect.height), trans.localPosition.z);
	}

	public static void SetSize(this RectTransform trans, Vector2 newSize) {
		Vector2 oldSize = trans.rect.size;
		Vector2 deltaSize = newSize - oldSize;
		trans.offsetMin = trans.offsetMin - new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
		trans.offsetMax = trans.offsetMax + new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
	}
	public static void SetWidth(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(newSize, trans.rect.size.y));
	}
	public static void SetHeight(this RectTransform trans, float newSize) {
		SetSize(trans, new Vector2(trans.rect.size.x, newSize));
	}

	// Get left, right, top, bottom

	public static float GetLeft(this RectTransform trans){
		return trans.offsetMin.x;
	}

	public static float GetRight(this RectTransform trans){
		return -trans.offsetMax.x;
	}

	public static float GetTop(this RectTransform trans){
		return -trans.offsetMax.y;
	}

	public static float GetBottom(this RectTransform trans){
		return trans.offsetMin.y;
	}

	// Set left, right, top, bottom

	public static void SetLeft(this RectTransform trans, float value){
		float y = trans.offsetMin.y;
		trans.offsetMin = new Vector2 (value, y);
	}

	public static void SetRight(this RectTransform trans, float value){
		float y = trans.offsetMax.y;
		trans.offsetMax = new Vector2 (-value, y);
	}

	public static void SetTop(this RectTransform trans, float value){
		float x = trans.offsetMax.x;
		trans.offsetMax = new Vector2 (x, -value);
	}

	public static void SetBottom(this RectTransform trans, float value){
		float x = trans.offsetMin.x;
		trans.offsetMin = new Vector2 (x, value);
	}

	/// <summary>
	/// Converts RectTransform.rect's local coordinates to world space
	/// Usage example RectTransformExt.GetWorldRect(myRect, Vector2.one);
	/// </summary>
	/// <returns>The world rect.</returns>
	/// <param name="rt">RectangleTransform we want to convert to world coordinates.</param>
	/// <param name="scale">Optional scale pulled from the CanvasScaler. Default to using Vector2.one.</param>
	static public Rect GetWorldRect (this RectTransform rt, Vector2 scale) {
		// Convert the rectangle to world corners and grab the top left
		Vector3[] corners = new Vector3[4];
		rt.GetWorldCorners (corners);
		Vector3 topLeft = corners [0];

		// Rescale the size appropriately based on the current Canvas scale
		Vector2 scaledSize = new Vector2 (scale.x * rt.rect.size.x, scale.y * rt.rect.size.y);
		return new Rect (topLeft, scaledSize);
	}

	static public Rect GetWorldRect (this RectTransform rt) {
		return rt.GetWorldRect (new Vector2 (1f, 1f));
	}

	// Edges

	public static float GetLeftEdge(this RectTransform trans){
		Rect rect = trans.GetWorldRect ();
		return rect.x;
	}

	public static float GetRightEdge(this RectTransform trans){
		Rect rect = trans.GetWorldRect ();
		return rect.x + rect.width;
	}

	public static float GetTopEdge(this RectTransform trans){
		Rect rect = trans.GetWorldRect ();
		return rect.y + rect.height;
	}

	public static float GetBottomEdge(this RectTransform trans){
		Rect rect = trans.GetWorldRect ();
		return rect.y;
	}

}