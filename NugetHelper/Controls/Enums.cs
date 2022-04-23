namespace NugetHelper.Controls
{

    /// <summary>
    /// enum to store the available task in this software
    /// </summary>
    public enum Commands : short
    {
        Path,
        Feed,
        Push,
        Update,
        PackageId,
        Exit
     
    }

    public enum SplitOptions : short
    {
        ByUpperCase,
        ByLowerCase,
        None
    }


}
