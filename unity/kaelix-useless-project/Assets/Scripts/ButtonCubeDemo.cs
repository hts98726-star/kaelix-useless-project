using System;
using System.Collections.Concurrent;
using System.IO.Ports;
using System.Threading;
using UnityEngine;

/// <summary>
/// Minimal Arduino-to-Unity test.
///
/// Expected serial messages at 115200 baud:
///   BUTTON,0
///   BUTTON,1
///
/// The component creates its own cube, so the scene needs no manual setup.
/// </summary>
public sealed class ButtonCubeDemo : MonoBehaviour
{
    private const string PreferredPort = "COM5";
    private const int BaudRate = 115200;

    private static readonly Color ReleasedColor = new(0.1f, 0.65f, 1f);
    private static readonly Color PressedColor = new(1f, 0.25f, 0.1f);

    private readonly ConcurrentQueue<bool> buttonEvents = new();
    private readonly ConcurrentQueue<string> logMessages = new();

    private SerialPort serialPort;
    private Thread readerThread;
    private Renderer cubeRenderer;
    private volatile bool keepReading;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void StartDemo()
    {
        var demoObject = new GameObject(nameof(ButtonCubeDemo));
        demoObject.AddComponent<ButtonCubeDemo>();
    }

    private void Start()
    {
        CreateCube();
        OpenArduinoPort();
    }

    private void CreateCube()
    {
        var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = "Arduino Button Cube";
        cube.transform.position = Vector3.zero;
        cube.transform.localScale = Vector3.one * 2f;

        cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material.color = ReleasedColor;
    }

    private void OpenArduinoPort()
    {
        try
        {
            var availablePorts = SerialPort.GetPortNames();
            var portName = Array.Exists(availablePorts, port =>
                string.Equals(port, PreferredPort, StringComparison.OrdinalIgnoreCase))
                ? PreferredPort
                : availablePorts.Length == 1
                    ? availablePorts[0]
                    : throw new InvalidOperationException(
                        $"Could not choose an Arduino port. Available ports: {string.Join(", ", availablePorts)}");

            serialPort = new SerialPort(portName, BaudRate)
            {
                ReadTimeout = 100,
                NewLine = "\n",
                DtrEnable = true
            };
            serialPort.Open();

            keepReading = true;
            readerThread = new Thread(ReadSerialLoop)
            {
                IsBackground = true,
                Name = "Arduino button serial reader"
            };
            readerThread.Start();

            Debug.Log($"Arduino button demo connected to {portName} at {BaudRate} baud.");
        }
        catch (Exception exception)
        {
            Debug.LogError(
                "Arduino connection failed. Close Arduino Serial Monitor, verify the COM port, " +
                $"then enter Play Mode again. Details: {exception.Message}");
        }
    }

    private void ReadSerialLoop()
    {
        while (keepReading)
        {
            try
            {
                var line = serialPort.ReadLine().Trim();
                if (line == "BUTTON,1")
                {
                    buttonEvents.Enqueue(true);
                }
                else if (line == "BUTTON,0")
                {
                    buttonEvents.Enqueue(false);
                }
            }
            catch (TimeoutException)
            {
                // A short timeout lets the thread notice when Play Mode stops.
            }
            catch (Exception exception)
            {
                if (keepReading)
                {
                    logMessages.Enqueue($"Arduino serial read stopped: {exception.Message}");
                }

                break;
            }
        }
    }

    private void Update()
    {
        while (buttonEvents.TryDequeue(out var isPressed))
        {
            cubeRenderer.material.color = isPressed ? PressedColor : ReleasedColor;
        }

        while (logMessages.TryDequeue(out var message))
        {
            Debug.LogError(message);
        }

        // A gentle idle rotation makes it obvious that the demo is running.
        cubeRenderer.transform.Rotate(0f, 25f * Time.deltaTime, 0f, Space.World);
    }

    private void OnDestroy()
    {
        keepReading = false;

        if (readerThread is { IsAlive: true })
        {
            readerThread.Join(250);
        }

        if (serialPort is { IsOpen: true })
        {
            serialPort.Close();
        }

        serialPort?.Dispose();
    }
}
