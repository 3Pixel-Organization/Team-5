using UnityEngine;
using TMPro;

public class LevelData : MonoBehaviour
{
    public Levels.Level level;

	public void SetData(Levels.Level lvl)
	{
		level = lvl;
		TextMeshProUGUI text = GetComponentInChildren<TextMeshProUGUI>();
		text.text = lvl.name;
	}

	public void ViewLevel() => LevelsMenu.instance.ViewLevel(level);
}
