PyImageToUnity3d
=============================================

A python script that streams PNG formatted images from python to a Unity3d in real-time. With this, Images that are generated using python libraries such as python-cv, numpy and tensorflow can alter a texture using remote input.

This tool is based on PyImageStream from [Bronkoknorb](https://github.com/Bronkoknorb) which enables webcam streaming to the browser: [https://github.com/Bronkoknorb/PyImageStream](https://github.com/Bronkoknorb/PyImageStream).

This approach is recomended as quick workaround that is potentially easier to configure than more advanced video streaming methods like HLS, MPEG-DASH, WebRTC.

Prerequisites
-------------

### Install dependencies

##### Python

[Tornado Web server](http://www.tornadoweb.org/)

pip install tornado

[Python Imaging Library](https://pypi.python.org/pypi/PIL)

[OpenCV](https://pypi.org/project/opencv-python/)

pip install opencv-python

[numpy](https://pypi.org/project/numpy/)

pip install numpy

[pyliblo](https://pypi.org/project/pyliblo/) **required for OSC control

[https://pypi.org/project/pyliblo/](https://pypi.org/project/pyliblo/)

##### Unity3D

[Unity3D](https://unity.com/)

[WebsocketSharp](https://medium.com/@ark.akshaykale/unity-and-websocket-7c2902c2c864)

- Unity has a open source package manager called NuGet.

- Head to [asset store](https://assetstore.unity.com/packages/tools/utilities/nuget-for-unity-104640). Download and import this asset.

- Then search for WebsocketSharp and hit install button. (In my case it is already installed. You should see the install button.)

![wss](https://cdn-images-1.medium.com/max/1600/1*lPhLFdxpfHGGWnJtasL_Bg.png)

*Many thanks to Akshay Kale for the instructions* [https://medium.com/@ark.akshaykale/unity-and-websocket-7c2902c2c864](https://medium.com/@ark.akshaykale/unity-and-websocket-7c2902c2c864)

Installation & Browser Test
------------

### Setup

Clone the repository and open in terminal:

git clone https://github.com/wprimett/PyImageToUnity3d.git
cd PyImageToUnity3d

### Running the code

##### Python only

Start with

python main.py test

This is to test that your machine can execute the program by simply outputting the images with OpenCV. If it works, some images should appear in a pop up window

##### Browser Client

change with first agument to `stream`

python main.py stream

While the script is running, open `pyimage_client.html` to test the stream in the browser. If the connection is successful, uou should see `CONNECTED` pop-up in the terminal and the image on the screen.

##### Unity3D Texture

Run the same commad as before

python main.py stream

Open the `PyImageReceiver_Example` in Unity and play the default scene. Click the green icon to initialize the WebSockets listener, if sucessful, an image should appear on the Plane object



The project two scripts for this to work, `WebSocketClient.cs` which can be attached the empty WSS GameObject and `TextureUpdater.cs` which can be attached any mesh you wish to update.







