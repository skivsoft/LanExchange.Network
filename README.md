# LanExchange.Network

Managed Windows Network Api Wrapper.

## Wrapped functions

- NetWkstaGetInfo
- NetApiBufferFree
- NetServerEnum
- NetServerEnumEx
- NetServerGetInfo
- NetServerSetInfo
- NetShareEnum
- NetWkstaUserEnum

## Usage

### Enumeration of SQL-Servers in current domain

```csharp
var servers = NetworkHelper.NetServerEnum<ServerInfo100>(100, null, SoftwareTypes.SV_TYPE_SQLSERVER);
foreach (var server in servers)
{
    Console.WriteLine("SQL Server Name: {0}", server.Name);
}
```