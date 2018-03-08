using System.IO;

namespace PclSharp.Test
{
    static class TestData
    {
        /// <summary>
        /// get a path to the data submodule, relative to the test output
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string DataPath(string path)
            => Path.Combine("..", "..", "..", "..", "data", path);
    }
}
