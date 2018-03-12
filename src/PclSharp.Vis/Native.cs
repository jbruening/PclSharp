using System;
using RIS = System.Runtime.InteropServices;

namespace PclSharp.Vis
{
    class Native
    {
        public const string DllName = "PclSharp.ExternVis.dll";
        public const RIS.CallingConvention CallingConvention = RIS.CallingConvention.Cdecl;
    }
}
