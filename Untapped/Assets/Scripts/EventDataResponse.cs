using System;

[Serializable]
public class EventDataResponse
{
    public int step_id; // step to execute next; special empty value indicates end of simulation
}
