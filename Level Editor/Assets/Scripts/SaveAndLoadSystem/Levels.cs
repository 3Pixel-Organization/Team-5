using System.Collections.Generic;
[System.Serializable]
public class Levels {
	public Dictionary<string, Level> levels = new Dictionary<string, Level>();
	public Levels() => levels = new Dictionary<string, Level>();
	[System.Serializable]
	public class Level {
		public string name;
		public ObjectsData objects;
		public TilemapData tiles;
		public Level(string _name, ObjectsData oData, TilemapData tData) {
			name = _name;
			objects = oData;
			tiles = tData;
		}
		[System.Serializable]
		public class ObjectsData {
			public Dictionary<float[], int> objects = new Dictionary<float[], int>();
			public ObjectsData(Dictionary<float[], int> _objects) => objects = _objects;
			public ObjectsData() => objects = new Dictionary<float[], int>();
		}
		[System.Serializable]
		public class TilemapData {
			public Dictionary<float[], int> tiles = new Dictionary<float[], int>();
			public TilemapData(Dictionary<float[], int> _tiles) => tiles = _tiles;
			public TilemapData() => tiles = new Dictionary<float[], int>();
		}
	}
}