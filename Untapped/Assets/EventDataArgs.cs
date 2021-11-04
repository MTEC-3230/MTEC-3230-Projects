using System;

public class EventDataArgs : EventArgs
{
    public readonly int step_id;
    public EventDataArgs(int Step_id)
    {
        step_id = Step_id;
    }

}