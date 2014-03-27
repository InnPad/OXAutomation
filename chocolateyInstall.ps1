$packageName = "OXAutomation"
$serviceName = $packageName
$username = "username"
$password = convertto-securestring -String "password" -AsPlainText -Force  

try { #error handling is only necessary if you need to do anything in addition to/instead of the main helpers
    $scriptPath = Split-Path $myInvocation.MyCommand.Path
    $packagePath = (Get-Item $(Split-Path -parent $MyInvocation.MyCommand.Definition)).Parent.FullName
    $existingService = Get-WmiObject -Class Win32_Service -Filter "Name='$serviceName'"
    
    if ($existingService)
    {
        $PSCmdlet.ThrowTerminatingError("Service exists. Uninstall first.")
    }
    
    # Use -params to specify the path. E.g: -params "C:\inetpub\wwwroot\ContinuousDelivery"
    $installPath = $env:chocolateyPackageParameters
    
    if ([string]::IsNullOrEmpty($installPath)) {
        # If -params with path is not specified, use the location from which the user invoked chocolatey install
        $installPath = Get-Location
    }
    
    Write-Output "Starting $packageName installation on $installPath.."
    
    # Delete existing files
    if (Test-Path $installPath) {
        Write-Output "Cleaning site content at $installPath."
        # Clean
        Remove-Item "$installPath\*" -Force -Recurse | Out-Null
    }
    
    # Copy binaries
    Write-Output "Copying binaries to $installPath..."
    Copy-Item $packagePath\bin\* $installPath | Out-Null
    
    # Install service
    Write-Output "Installing service..."  | Out-Null
    
    $exePath = "$installPath\OXAutomationService.exe"
    $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
    
    New-Service -BinaryPathName $exePath -Name $serviceName -Credential $cred -DisplayName $serviceName -StartupType Automatic
    
    #$ShouldStartService = Read-Host "Would you like the '$serviceName ' service started? Y or N"
    #if($ShouldStartService -eq "Y")
    #{
    # Start service
    Write-Output "Starting service..."  | Out-Null
    
    Start-Service $serviceName
    #}

    # Error handling
    Write-ChocolateySuccess $packageName
} catch {
    Write-ChocolateyFailure $packageName "$($_.Exception.Message)"
    #throw 
}