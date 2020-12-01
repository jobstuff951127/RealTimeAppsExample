# RealTimeApplication
This is a basic example of how to deal with real time charting while using winform exposing the one to many approach and the one to one approach as another basic example.

To give it a try firstly run the SignalR project by selecting SignalRHost as running option instead of IIS Express, then run RealTimeCharting project as a new instance.
Once the exe is running open many exe´s as you can and press a button to see it working, this example shows how to send a message from one client to the rest of them.

To run the RealTimeOnetoOne project is the same process described above but this last one needs another client app that uses the "Done" method and share the same business id randomly assigned.

**Example:**
connection.InvokeAsync("Done", bool, int);


