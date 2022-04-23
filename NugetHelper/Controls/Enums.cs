namespace NugetHelper.Controls
{

    /// <summary>
    /// enum to store the available task in this software
    /// </summary>
    public enum OptionsToRun : short
    {
        GetTiaProcessInfo,
        AttachToRunningProcess,
        StartTiaInstance,
        DisposeTiaInstance,
        GetInstalledSoftware,
        OpenTiaProject,
        SaveTiaProject,
        GetProjectAttributes,
        CloseTiaProject,
        GetDevicesInProject,
        GetPlcsInSystem,
        GetSofwareBlocksInPlc,
        GetSoftwareFoldersDefined,
        GetUserDataTypes,
        GetUserDataTypeFolders,
        ExportSoftwareBlockToXml,
        GenerateSourceFromBlock,
        GetDeviceItems,
        GetSoftwareTargets,
        GetSubnetsInProject,
        GetSubnetDetails,
        GetNodesFromSubnet,
        SaveSubnetNodesToFile,
        GetLmConfigurationFile,
        CloseNugetHelper
    }

    public enum SplitOptions : short
    {
        ByUpperCase,
        ByLowerCase,
        None
    }


}
