# Alias for invoking psake from project root
param (
    [Parameter(Position=0,Mandatory=0)]
    [string]$buildFile = '.\default.ps1',
    [Parameter(Position=1,Mandatory=0)]
    [string[]]$taskList = @(),
    [Parameter(Position=2,Mandatory=0)]
    [string]$framework,
    [Parameter(Position=3,Mandatory=0)]
    [switch]$docs = $false,
    [Parameter(Position=4,Mandatory=0)]
    [System.Collections.Hashtable]$parameters = @{},
    [Parameter(Position=5, Mandatory=0)]
    [System.Collections.Hashtable]$properties = @{},
    [Parameter(Position=6, Mandatory=0)]
    [alias("init")]
    [scriptblock]$initialization = {},
    [Parameter(Position=7, Mandatory=0)]
    [switch]$nologo = $false,
    [Parameter(Position=8, Mandatory=0)]
    [switch]$help = $false,
    [Parameter(Position=9, Mandatory=0)]
    [string]$scriptPath = $(Split-Path -parent $MyInvocation.MyCommand.path)
)

Import-Module .\psake.psm1

try 
{
    Invoke-Psake $buildFile $taskList $framework $docs $parameters $properties
    Exit $LastExitCode;
}
finally 
{
    Remove-Module psake -ea 'SilentlyContinue'
}
