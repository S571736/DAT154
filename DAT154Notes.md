## Windows SDK
* Based on functions
  * Not object oriented
* Can make object oriented programs by creating ovjects that encapsulate functions
* Uses normally C and C++....

### Windows messages
* The windows OS is based on messages
  * Sends messages to programs when events occur
  * Messages are out into the message queue
  * Message loop in program retrieves messages and handles the message
* Message handling example
  1. Mouse click
  2. Mouse driver
  3. I/O manager
  4. User32
  5. Message queue
  6. WinMain
  7. User32
  8. WndProc