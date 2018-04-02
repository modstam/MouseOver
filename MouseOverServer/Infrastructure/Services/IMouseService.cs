namespace MouseOverServer.Infrastructure.Services
{
    public interface IMouseService
    {
        /// <summary>
        /// Approximates and sets an appropriate mouse position on the server, 
        /// depending on the input and resolution of the sender
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns> true if success </returns>
        bool SetAdjustedMousePosition(int x, int y, int width, int height);

        /// <summary>
        /// Attempts to set the absolute position of the mouse on the sever, 
        /// given by the input 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>  true if success </returns>
        bool SetAbsoluteMousePosition(int x, int y);

        bool IsCompatibleSystem();
    }
}
