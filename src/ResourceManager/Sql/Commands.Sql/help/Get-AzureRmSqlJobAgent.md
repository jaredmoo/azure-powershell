---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/get-azurermsqljobagent
schema: 2.0.0
---

# Get-AzureRmSqlJobAgent

## SYNOPSIS
Gets one or more job agents in a server.

## SYNTAX

```
Get-AzureRmSqlJobAgent [-ServerName] <String> [[-JobAgentName] <String>] [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmSqlJobAgent** cmdlet gets one or more Azure SQL job accounts from an Azure SQL Database Server.

## EXAMPLES

### Example 1: Get all job agents in a server
```
PS C:\> Get-AzureRmSqlJobAgent -ResourceGroupName rg1 -ServerName server1


ResourceGroupName : rg1
ServerName        : server1
JobAgentName      : agent1
Location          : centralus
DatabaseName      : db1
Tags              :

ResourceGroupName : rg1
ServerName        : server1
JobAgentName      : agent2
Location          : centralus
DatabaseName      : db2
Tags              :
```

This command gets all job agents in the server named server1.

### Example 2: Get a job agent by name
```
PS C:\> Get-AzureRmSqlJobAgent -ResourceGroupName rg1 -ServerName server1 -JobAgentName agent1


ResourceGroupName : rg1
ServerName        : server1
JobAgentName      : agent1
Location          : centralus
DatabaseName      : db1
Tags              :
```

This command gets a job agent named agent1 in the server named server1.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JobAgentName
SQL Database job account name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
SQL Database server name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
