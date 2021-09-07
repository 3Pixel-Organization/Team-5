using System.Collections.Generic;
[System.Serializable]
public class WorldData
{
	public TilemapData tilemapData;
	public ObjectsData objectsData;
	public Dictionary<string, BuildingData> buildingsData;
	public WorldData(TilemapData tData, ObjectsData oData, Dictionary<string, BuildingData> bData)
		{ tilemapData = tData; objectsData = oData; buildingsData = bData; }
	public WorldData()
		{ tilemapData = new TilemapData(); objectsData = new ObjectsData(); buildingsData = new Dictionary<string, BuildingData>(); }
	[System.Serializable]
	public class TilemapData
	{
		public Dictionary<float[], int> tiles;
		public TilemapData(Dictionary<float[], int> _tiles) => tiles = _tiles;
		public TilemapData() => tiles = new Dictionary<float[], int>();
	}
	[System.Serializable]
	public class ObjectsData
	{
		public Dictionary<float[], int> objects;
		public ObjectsData(Dictionary<float[], int> _objects) => objects = _objects;
		public ObjectsData() => objects = new Dictionary<float[], int>();
	}
	[System.Serializable]
	public class BuildingData
	{
		public int index;
		public float[] position;
		public string name;
		public TilemapData tilemapData;
		public ObjectsData objectsData;
		public BuildingData(TilemapData tData, ObjectsData oData, int _index, float[] _position, string _name) { tilemapData = tData; objectsData = oData; index = _index; position = _position; name = _name; }
		public BuildingData() { index = 0; position = new float[3]; name = string.Empty; tilemapData = new TilemapData(); objectsData = new ObjectsData(); }
	}
}