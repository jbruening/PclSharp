using System;
using RIS = System.Runtime.InteropServices;

namespace PclSharp
{
    public static class Native
    {
        public const string DllName = "PclSharp.Extern.dll";
        public const RIS.CallingConvention CallingConvention = RIS.CallingConvention.Cdecl;
    }
}
