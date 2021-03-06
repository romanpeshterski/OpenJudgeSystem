﻿namespace OJS.Workers.Executors.Process
{
    using System;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Security;
    using System.Security.Permissions;

    using Microsoft.Win32.SafeHandles;

    [SuppressUnmanagedCodeSecurity]
    [HostProtection(SecurityAction.LinkDemand, MayLeakOnAbort = true)]
    public sealed class SafeLocalMemHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        internal SafeLocalMemHandle()
            : base(true)
        {
        }

        [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
        internal SafeLocalMemHandle(IntPtr existingHandle, bool ownsHandle)
            : base(ownsHandle)
        {
            this.SetHandle(existingHandle);
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false)]
        internal static extern bool ConvertStringSecurityDescriptorToSecurityDescriptor(string stringSecurityDescriptor, int stringSDRevision, out SafeLocalMemHandle securityDescriptor, IntPtr securityDescriptorSize);

        protected override bool ReleaseHandle()
        {
            return LocalFree(this.handle) == IntPtr.Zero;
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        [DllImport("kernel32.dll")]
        private static extern IntPtr LocalFree(IntPtr memoryHandler);
    }
}
