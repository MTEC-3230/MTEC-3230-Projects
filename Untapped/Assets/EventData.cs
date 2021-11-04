using System;


[Serializable]
public class EventData
{
	public int event_id;
	public int event_type;
	public string timestamp;
	public string object_state;
	public int step_id;

	public override string ToString()
	{
		return UnityEngine.JsonUtility.ToJson(this, true);
	}

}