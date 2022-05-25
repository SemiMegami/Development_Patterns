using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    private bool _isRecording;
    private bool _isReplaying;
    private float _recordingTime;
    private float _replayTime;

    private SortedList<float, Command> _recordedCommand = new SortedList<float, Command>();
    // Start is called before the first frame update


    public void ExecuteCommand(Command command)
    {
        command.Execute();
        if (_isRecording)
        {
            _recordedCommand.Add(_recordingTime, command);
        }

        Debug.Log("Record Time: " + _recordingTime);
        Debug.Log("Record Command: " + command);
    }
    public void Record()
    {
        _recordingTime = 0;
        _isRecording = true;
    }

    public void Replay()
    {
        _replayTime = 0;
        _isReplaying = true;
        if(_recordedCommand.Count <= 0)
        {
            Debug.LogError("No command to replay!");
        }
        _recordedCommand.Reverse();
    }

    private void FixedUpdate()
    {
        if (_isRecording)
        {
            _recordingTime += Time.deltaTime;
        }
        if (_isReplaying)
        {
            _replayTime += Time.deltaTime;
            if (_recordedCommand.Any())
            {
                if (Mathf.Approximately(_replayTime, _recordedCommand.Keys[0]))
                {
                    Debug.Log("Replay Time: " + _replayTime);
                    Debug.Log("Replay Command: " + _recordedCommand.Values[0]);
                    _recordedCommand.Values[0].Execute();
                    _recordedCommand.RemoveAt(0);
                }
            }
            else
            {
                _isReplaying = false;
            }
        }
    }
}
