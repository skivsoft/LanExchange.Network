using System;

namespace LanExchange.Network.Models
{
    [CLSCompliant(false)]
    [Flags]
    public enum ShareTypes : uint
    {
        /// <summary>
        /// Disk drive
        /// </summary>
        STYPE_DISKTREE = 0,
        /// <summary>
        /// Print queue
        /// </summary>
        STYPE_PRINTQ = 1,
        /// <summary>
        /// Communication device
        /// </summary>
        STYPE_DEVICE = 2,
        /// <summary>
        /// Interprocess communication (IPC)
        /// </summary>
        STYPE_IPC = 3,
        /// <summary>
        /// A cluster share
        /// </summary>
        STYPE_CLUSTER_FS   = 0x02000000,
        /// <summary>
        /// A Scale-Out cluster share
        /// </summary>
        STYPE_CLUSTER_SOFS = 0x04000000,
        /// <summary>
        /// A DFS share in a cluster
        /// </summary>
        STYPE_CLUSTER_DFS  = 0x08000000,
        /// <summary>
        /// A temporary share that is not persisted for creation each time the file server initializes.
        /// </summary>
        STYPE_TEMPORARY    = 0x40000000,
        /// <summary>
        /// Special share reserved for interprocess communication (IPC$) or remote administration of the server (ADMIN$). 
        /// Can also refer to administrative shares such as C$, D$, E$, and so forth.
        /// </summary>
        STYPE_SPECIAL      = 0x80000000,
    }
}