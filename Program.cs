public class SystemParameters<T> where T : Win32_Base
{
	public IEnumerable<Win32_Base> GetInfo()
	{
		foreach (ManagementObject mo in new ManagementObjectSearcher($"SELECT * FROM {typeof(T).Name}").Get())
		{
			// При добавлении нового класса (производного от Win32_Base) нужный объект будет создан автоматически.  
			var construct = typeof(T).GetConstructor(new[] { mo.GetType() });
			var instance = construct.Invoke(new[] { mo });
			yield return (Win32_Base)instance;
		}
	}
}

public abstract class Win32_Base
{
	protected ManagementObject mo { get; set; }
	public Win32_Base(ManagementObject mo)
	{
		this.mo = mo;
	}
}

public class Win32_DiskDrive : Win32_Base
{
	public Win32_DiskDrive(ManagementObject mo) : base(mo) { }
	public string Caption => mo["Caption"].ToString();
	public string Description => mo["Description"].ToString();
	public string FirmwareRevision => mo["FirmwareRevision"].ToString();
	public string DeviceID => mo["DeviceID"].ToString();
	public string MediaType => mo["MediaType"].ToString();
	public string Model => mo["Model"].ToString();
	public string Name => mo["Name"].ToString();
	uint Partitions;
	public string PNPDeviceID => mo["PNPDeviceID"].ToString();
	public string SerialNumber => mo["SerialNumber"].ToString();

	public string Status => mo["Status"].ToString();
	public string SystemName => mo["SystemName"].ToString();

	public object VolumeName => mo["VolumeName"];
	public string VolumeSerialNumber => mo["VolumeSerialNumber"].ToString();
}
public class Win32_LogicalDisk : Win32_Base
{
	public Win32_LogicalDisk(ManagementObject mo) : base(mo) { }
	public string Caption => mo["Caption"].ToString();
	public string CreationClassName => mo["CreationClassName"].ToString();
	public string Description => mo["Description"].ToString();
	public string DeviceID => mo["DeviceID"].ToString();
	public string ErrorDescription => mo["ErrorDescription"].ToString();
	public string ErrorMethodology => mo["ErrorMethodology"].ToString();
	public string FileSystem => mo["FileSystem"].ToString();
	public long FreeSpace => (long)mo["FreeSpace"];
	public string Name => mo["Name"].ToString();
	public string PNPDeviceID => mo["PNPDeviceID"].ToString();
	public string ProviderName => mo["ProviderName"].ToString();
	public string Purpose => mo["Purpose"].ToString();
	public string SessionID => mo["SessionID"].ToString();
	public long Size => (long)mo["Size"];
	public string SystemName => mo["SystemName"].ToString();
	public string VolumeName => mo["VolumeName"].ToString();
	public string VolumeSerialNumber => mo["VolumeSerialNumber"].ToString();

};
public class Win32_LogicalProgramGroup : Win32_Base
{
	public Win32_LogicalProgramGroup(ManagementObject mo) : base(mo) { }
	public string Caption => mo["Caption"].ToString();
	public string Description => mo["Description"].ToString();
	public object InstallDate => Convert.ToDateTime(mo["InstallDate"].ToString().Substring(0, 8).Insert(6, "-").Insert(4, "-")).ToShortDateString();
	public string GroupName => mo["GroupName"].ToString();
	public string Name => mo["Name"].ToString();
	public string UserName => mo["UserName"].ToString();
}
public class Win32_NetworkAdapter : Win32_Base
{
	public Win32_NetworkAdapter(ManagementObject mo) : base(mo) { }
	public string AdapterType => mo["AdapterType"].ToString();
	public string Caption => mo["Caption"].ToString();
	public string Description => mo["Description"].ToString();
	public string DeviceID => mo["DeviceID"].ToString();
	public string GUID => mo["GUID"].ToString();
	public string MACAddress => mo["MACAddress"].ToString();
	public string Manufacturer => mo["Manufacturer"].ToString();
	public string Name => mo["Name"].ToString();
	public string NetConnectionID => mo["NetConnectionID"].ToString();
	public object NetEnabled => mo["NetEnabled"];
	public object NetworkAddresses => mo["NetworkAddresses"];
	public string PermanentAddress => mo["PermanentAddress"].ToString();
	public object PhysicalAdapter => mo["PhysicalAdapter"];
	public string PNPDeviceID => mo["PNPDeviceID"].ToString();
	public string ProductName => mo["ProductName"].ToString();
	public string ServiceName => mo["ServiceName"].ToString();
	public string Status => mo["Status"].ToString();
	public string SystemCreationClassName => mo["SystemCreationClassName"].ToString();
	public string SystemName => mo["SystemName"].ToString();
};
public class Win32_Processor : Win32_Base
{
	public Win32_Processor(ManagementObject mo) : base(mo) { }
	public ushort AddressWidth => (ushort)mo["AddressWidth"];
	public ushort Architecture => (ushort)mo["Architecture"];
	public string AssetTag => mo["AssetTag"].ToString();
	public ushort Availability => (ushort)mo["Availability"];
	public string Caption => mo["Caption"].ToString();
	public uint Characteristics => (uint)mo["Characteristics"];
	public uint ConfigManagerErrorCode => (uint)mo["ConfigManagerErrorCode"];
	public bool ConfigManagerUserConfig => (bool)mo["ConfigManagerUserConfig"];
	public ushort CpuStatus => (ushort)mo["CpuStatus"];
	public string CreationClassName => mo["CreationClassName"].ToString();
	public uint CurrentClockSpeed => (uint)mo["CurrentClockSpeed"];
	public ushort CurrentVoltage => (ushort)mo["CurrentVoltage"];
	public ushort DataWidth => (ushort)mo["DataWidth"];
	public string Description => mo["Description"].ToString();
	public string DeviceID => mo["DeviceID"].ToString();
	public bool ErrorCleared => (bool)mo["ErrorCleared"];
	public string ErrorDescription => mo["ErrorDescription"].ToString();
	public uint ExtClock => (uint)mo["ExtClock"];
	public ushort Family => (ushort)mo["Family"];
	public object InstallDate => mo["InstallDate"]; //DateTime
	public uint L2CacheSize => (uint)mo["L2CacheSize"];
	public uint L2CacheSpeed => (uint)mo["L2CacheSpeed"];
	public uint L3CacheSize => (uint)mo["L3CacheSize"];
	public uint L3CacheSpeed => (uint)mo["L3CacheSpeed"];
	public uint LastErrorCode => (uint)mo["LastErrorCode"];
	public ushort Level => (ushort)mo["Level"];
	public ushort LoadPercentage => (ushort)mo["LoadPercentage"];
	public string Manufacturer => mo["Manufacturer"].ToString();
	public uint MaxClockSpeed => (uint)mo["MaxClockSpeed"];
	public string Name => mo["Name"].ToString();
	public uint NumberOfCores => (uint)mo["NumberOfCores"];
	public uint NumberOfEnabledCore => (uint)mo["NumberOfEnabledCore"];
	public uint NumberOfLogicalProcessors => (uint)mo["NumberOfLogicalProcessors"];
	public string OtherFamilyDescription => mo["OtherFamilyDescription"].ToString();
	public string PartNumber => mo["PartNumber"].ToString();
	public string PNPDeviceID => mo["PNPDeviceID"].ToString();
	public object PowerManagementCapabilities => mo["PowerManagementCapabilities"];
	public bool PowerManagementSupported => (bool)mo["PowerManagementSupported"];
	public string ProcessorId => mo["ProcessorId"].ToString();
	public ushort ProcessorType => (ushort)mo["ProcessorType"];
	public ushort Revision => (ushort)mo["Revision"];
	public string Role => mo["Role"].ToString();
	public bool SecondLevelAddressTranslationExtensions => (bool)mo["SecondLevelAddressTranslationExtensions"];
	public string SerialNumber => mo["SerialNumber"].ToString();
	public string SocketDesignation => mo["SocketDesignation"].ToString();
	public string Status => mo["Status"].ToString();
	public ushort StatusInfo => (ushort)mo["StatusInfo"];
	public string Stepping => mo["Stepping"].ToString();
	public string SystemCreationClassName => mo["SystemCreationClassName"].ToString();
	public string SystemName => mo["SystemName"].ToString();
	public uint ThreadCount => (uint)mo["ThreadCount"];
	public string UniqueId => mo["UniqueId"].ToString();
	public ushort UpgradeMethod => (ushort)mo["UpgradeMethod"];
	public string Version => mo["Version"].ToString();
	public bool VirtualizationFirmwareEnabled => (bool)mo["VirtualizationFirmwareEnabled"];
	public bool VMMonitorModeExtensions => (bool)mo["VMMonitorModeExtensions"];
	public uint VoltageCaps => (uint)mo["VoltageCaps"];
}
public class Win32_BIOS : Win32_Base
{
	public Win32_BIOS(ManagementObject mo) : base(mo) { }

	public object BiosCharacteristics => mo["BiosCharacteristics"];
	public object BIOSVersion => mo["BIOSVersion"];
	public string BuildNumber => mo["BuildNumber"].ToString();
	public string Caption => mo["Caption"].ToString();
	public string CodeSet => mo["CodeSet"].ToString();
	public string CurrentLanguage => mo["CurrentLanguage"].ToString();
	public string Description => mo["Description"].ToString();
	public byte EmbeddedControllerMajorVersion => (byte)mo["EmbeddedControllerMajorVersion"];
	public byte EmbeddedControllerMinorVersion => (byte)mo["EmbeddedControllerMinorVersion"];
	public string IdentificationCode => mo["IdentificationCode"].ToString();
	public ushort InstallableLanguages => (ushort)mo["InstallableLanguages"];
	public object InstallDate => mo["InstallDate"];
	public string LanguageEdition => mo["LanguageEdition"].ToString();
	public object  ListOfLanguages => mo["ListOfLanguages"];
	public string Manufacturer => mo["Manufacturer"].ToString();
	public string Name => mo["Name"].ToString();
	public string OtherTargetOS => mo["OtherTargetOS"].ToString();
	public bool PrimaryBIOS => (bool)mo["PrimaryBIOS"];
	public object ReleaseDate => mo["ReleaseDate"];
	public string SerialNumber => mo["SerialNumber"].ToString();
	public string SMBIOSBIOSVersion => mo["SMBIOSBIOSVersion"].ToString();
	public ushort SMBIOSMajorVersion => (ushort)mo["SMBIOSMajorVersion"];
	public ushort SMBIOSMinorVersion => (ushort)mo["SMBIOSMinorVersion"];
	public bool SMBIOSPresent => (bool)mo["SMBIOSPresent"];
	public string SoftwareElementID => mo["SoftwareElementID"].ToString();
	public ushort SoftwareElementState => (ushort)mo["SoftwareElementState"];
	public string Status => mo["Status"].ToString();
	public byte SystemBiosMajorVersion => (byte)mo["SystemBiosMajorVersion"];
	public byte SystemBiosMinorVersion => (byte)mo["SystemBiosMinorVersion"];
	public ushort TargetOperatingSystem => (ushort)mo["TargetOperatingSystem"];
	public string Version => mo["Version"].ToString();
}


public class Win32_Product : Win32_Base
{
	public Win32_Product(ManagementObject mo) : base(mo) { }
	
	public ushort AssignmentType=> (ushort)mo["AssignmentType"];
	public string Caption=> mo["Caption"].ToString();
	public string Description=> mo["Description"].ToString();
	public string IdentifyingNumber=> mo["IdentifyingNumber"].ToString();
	public string InstallDate=> mo["InstallDate"].ToString();
	public object InstallDate2=> mo["InstallDate2"];
	public string InstallLocation=> mo["InstallLocation"].ToString();
	public ushort InstallState=> (ushort)mo["InstallState"];
	public string HelpLink=> mo["HelpLink"].ToString();
	public string HelpTelephone=> mo["HelpTelephone"].ToString();
	public string InstallSource=> mo["InstallSource"].ToString();
	public string Language=> mo["Language"].ToString();
	public string LocalPackage=> mo["LocalPackage"].ToString();
	public string Name=> mo["Name"].ToString();
	public string PackageCache=> mo["PackageCache"].ToString();
	public string PackageCode=> mo["PackageCode"].ToString();
	public string PackageName=> mo["PackageName"].ToString();
	public string ProductID=> mo["ProductID"].ToString();
	public string RegOwner=> mo["RegOwner"].ToString();
	public string RegCompany=> mo["RegCompany"].ToString();
	public string SKUNumber=> mo["SKUNumber"].ToString();
	public string Transforms=> mo["Transforms"].ToString();
	public string URLInfoAbout=> mo["URLInfoAbout"].ToString();
	public string URLUpdateInfo=> mo["URLUpdateInfo"].ToString();
	public string Vendor=> mo["Vendor"].ToString();
	public ushort WordCount=> (ushort)mo["WordCount"];
	public string Version=> mo["Version"].ToString();
}

public class Program
{
	// Если нужно получить информацию по какому либо устройству, то необходимо добавить новый класс 
	// Например для добавления информации о BIOS нужно создать класс по аналогии с этим С++ классом, который взять по ссылке ->
	// https://docs.microsoft.com/ru-ru/windows/win32/cimwin32prov/win32-bios
	// Данный класс унаследовать от Win32_Base и пробросить в конструктор базового класса параметр mo
	// public Win32_Bios(ManagementObject mo) : base(mo) { }

	public static void Main(string[] args)
	{
		//Console.WriteLine(new SystemParameters<Win32_BIOS>().GetInfo());
		Console.WriteLine(new SystemParameters<Win32_DiskDrive>().GetInfo());
		//Console.WriteLine(new SystemParameters<Win32_Product>().GetInfo());
	}
}
