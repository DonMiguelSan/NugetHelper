namespace NugetHelper.Controls
{

    /// <summary>
    /// enum to store the available task in this software
    /// </summary>
    public enum Commands : short
    {
        NugetExePath,
        Feed,
        Push,
        Update,
        PackageId,
        MovePackToPath,
        Exit
     
    }

    public enum SplitOptions : short
    {
        ByUpperCase,
        ByLowerCase,
        None
    }


}
