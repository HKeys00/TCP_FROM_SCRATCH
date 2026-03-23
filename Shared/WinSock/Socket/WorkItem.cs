namespace Shared.WinSock.Socket
{
    /// <summary>
    /// An item of work that is sent across a socket and needs to be enqueud.
    /// </summary>
    public class WorkItem
    {
        #region Properties

        /// <summary>
        /// Gets or sets the handle of the socket this work item belongs to.
        /// </summary>
        public nint Handle { get; set; }

        /// <summary>
        /// Gets or sets the buffer data sent in this work item.
        /// </summary>
        public int[] Buffer { get; set; }

        #endregion
    }
}
