using System.IO;
namespace GrozaGames.Kit
{
    public static class FileSystemInfoEx
    {
        public static string GetAssetPath(this FileSystemInfo fileInfo)
        {
            return fileInfo.FullName.Replace('\\', '/').Replace(UnityProject.Path, "").TrimStart('/');
        }
    }
}
