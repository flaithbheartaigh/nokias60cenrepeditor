using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace S60.Lib.Sis
{
  public class Enumerators
  {
    public enum THeaderFlags
    {
      None = 0,
      EInstIsUnicode = 1 << 0,
      EInstIsDistributable = 1 << 1,
      EInstIsCompareToMajor = 1 << 2,
      EInstNoCompress = 1 << 3,
      EInstShutdownApps = 1 << 4,
      EInstNonRemovable = 1 << 5,
      EInstROMUpgrade = 1 << 6,
      EInstHide = 1 << 7
    }

    public enum TVariableToken
    {
      None = 0,
      EVarLanguage = 0x1000,
      EVarRemoteInstall,
      EVarOptionBase = 0x2000
    }

    public enum TFieldType
    {
      ESISUndefined,
      ESISString,
      ESISArray,
      ESISCompressed,
      ESISVersion,
      ESISVersionRange,
      ESISDate,
      ESISTime,
      ESISDateTime,
      ESISUid,
      ESISUnused1,
      ESISLanguage,
      ESISContents,
      ESISController,
      ESISInfo,
      ESISSupportedLanguages,
      ESISSupportedOptions,
      ESISPrerequisites,
      ESISDependency,
      ESISProperties,
      ESISProperty,
      ESISSignatures,
      ESISCertificateChain,
      ESISLogo,
      ESISFileDescription,
      ESISHash,
      ESISIf,
      ESISElseIf,
      ESISInstallBlock,
      ESISExpression,
      ESISData,
      ESISDataUnit,
      ESISFileData,
      ESISSupportedOption,
      ESISControllerChecksum,
      ESISDataChecksum,
      ESISSignature,
      ESISBlob,
      ESISSignatureAlgorithm,
      ESISSignatureCertificateChain,
      ESISDataIndex,
      ESISCapabilities,
      // insert new fields here
      ESISUnknown
    }

    public enum TDbgFlags
    {
      EDbgDefault = 0,
      EDbgDataChecksum = 0x01,
      EDbgControllerChecksum = 0x02,
      EDbgCompress = 0x04,
      EDbgNoCompress = 0x08,
    }

    public enum TBug
    {
      EBugDefault = 0,
      EBugCRCError = 0x0001,
      EBugInvalidLength = 0x0002,
      EBugMissingField = 0x0004,
      EBugUnexpectedField = 0x0008,
      EBugBigEndian = 0x0010,
      EBugDuffFieldType = 0x0020,
      EBugInvalidValues = 0x0040,
      EBugHashError = 0x0080,
      EBugNegativeLength = 0x0100,
      EBugInsaneString = 0x0200,
      EBugInsaneBlob = 0x0400,
      EBugArrayCount = 0x0800,
      EBug32As64 = 0x1000,
      EBugUnknownField = 0x2000,
      EBugEmptyCaps = 0x4000,
      EBugUnknownData = 0x8000,
    }

    public enum THeadOpt
    {
      EOptDefault = 0,
      EOptIsUnicode = 1 << 0,
      EOptIsDistributable = 1 << 1,
      EOptIsCompareToMajor = 1 << 2,
      EOptNoCompress = 1 << 3,
      EOptShutdownApps = 1 << 4,
      EOptNonRemovable = 1 << 5,
      EOptROMUpgrade = 1 << 6,
    }


  }
}
