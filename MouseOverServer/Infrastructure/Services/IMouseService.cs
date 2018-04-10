namespace MouseOverServer.Infrastructure.Services
{
    public interface IMouseService
    {
        /// <summary>
        /// Approximates and sets an appropriate mouse position on the server, 
        /// depending on the input position and the ration between the senders resolution 
        /// and the resolution on the server
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="senderWidth"></param>
        /// <param name="senderHeight"></param>
        /// <returns> true if success </returns>
        bool SetAdjustedMousePosition(int x, int y, int senderWidth, int senderHeight);

        /// <summary>
        /// Attempts to set the absolute position of the mouse on the sever, 
        /// given by the input 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>  true if success </returns>
        bool SetAbsoluteMousePosition(int x, int y);

        /// <summary>
        /// Clicks the absolute position specified by input parameters
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool ClickMouseAbsolutePosition(int x, int y);

        /// <summary>
        /// Clicks the appropriate mouse position given by input position and the ratio between the 
        /// senders resolution and the current resolution on the server
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="senderWidth"></param>
        /// <param name="senderHeight"></param>
        /// <returns></returns>
        bool ClickMouseAdjustedPosition(int x, int y, int senderWidth, int senderHeight);

        bool IsCompatibleSystem();
    }
}
