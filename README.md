# MouseOver

<p>
MouseOver is an ongoing hobby project aiming to create a cross-platform solution 
for remote controlling mouse movement on a host computer from a mobile device.
The project itself is a means to an end of learning more about development for .NET Core 
(Running on the host as a rest API) and Xamarin.Forms (Running on the client mobile device)
</p>

<p>
The final goal is to support hosts running Windows, OSX and linux while also supporting clients running Android and iOS.
This is not entirely as trivial as it seems because there is no standardized APIs for
controlling mouse movements on host machines and intricate touch controls for Xamarin.Forms.
</p>


# Current state of the project

<h3> Server </h3>
<p>
Currently the server part of the project has a working solution implemented for Windows machines. Linux and OSX support is not yet implemented.
</p>

<h3> Client </h3>

<p>
A rudimentary implementation for network discovery of active hosts is implemented along with the non device specific parts of the Xamarin.Forms application.
Still missing platform specific touch-implementations.
</p>
