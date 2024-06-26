﻿namespace ProtobufRegen
{
    /// <summary>
    /// This class is used for configuring the invoke path of some apps. 
    /// It's useful if you don't add them to the environment PATH. 
    /// </summary>
    internal class OuterInvokeConfig
    {
        /// <summary>
        /// The dotnet runtime CLI from Microsoft. 
        /// If dotnet isn't in the PATH, you can change it to a definitive path.
        /// Not recommend a relative path because the working directory will be changed by the program at the startup. 
        /// </summary>
        public const string dotnet_path = "dotnet";
        /// <summary>
        /// The git path. In most cases you should make git into PATH instead of changing here. 
        /// If git isn't in the PATH, you can change it to a definitive path.
        /// Not recommend a relative path because the working directory will be changed by the program at the startup. 
        /// </summary>
        public const string git_path = "git";
    }
}
