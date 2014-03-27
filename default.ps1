properties {
    $solutionName = "OXAutomation"
    $solutionVersion = "0.1.0"
    $baseDirectory = Get-Item $psake.build_script_dir
    $srcDirectory = "$baseDirectory\src"
    $solution = "$srcDirectory\$solutionName.sln"
    $buildDirectory = "$baseDirectory\.build"
    $toolsDirectory = "$baseDirectory\tools"
    $packageDirectory = "$baseDirectory\package"
    $buildLog = "$buildDirectory\build.log"
    $configuration = "Release"
    $visualStudioVersion = "11.0" # Visual Studio 2010
}

# Build process: Clean, Compile, Inspect, Test, Package 
task default -depends Package

# Delete existing build directory and clean solution
task Clean {
    # Delete existing build directory
    Delete-Directory -Path $buildDirectory
    
    # Clean solution
    Clean-Solution -Solution $solution -VisualStudioVersion $visualStudioVersion
}

# Compile solution
task Compile -depends Clean {
    # Delete existing build directory
    Delete-Directory -Path $buildDirectory
    
    # Create build directory
    New-Item $buildDirectory -ItemType Directory -Force | Out-Null

    # Compile solution
    # VisualStudioVersion property is necessary to locate WebApplication target
    Compile-Solution -Solution $solution -Configuration $configuration -OutputDirectory $buildDirectory -VisualStudioVersion $visualStudioVersion
}

# Create distribution package using NuGet, NPM, Windows Installer, etc
task Package -depends Compile {
    Pack-Binaries -PackageName $solutionName -TempDirectory $packageDirectory -ContentDirectory "$buildDirectory\$solutionName"
}

# Clean solution
function Clean-Solution() {
    # Pass in the Parameters.
    param ([string] $solution, [string] $visualStudioVersion)
    
    Write-Output "Cleaning solution $solution (VS Version $visualStudioVersion)"
    
    # Clean solution
    # VisualStudioVersion property is necessary to locate WebApplication target
    Invoke-Expression "msbuild $solution /p:VisualStudioVersion=$visualStudioVersion /t:Clean /v:Quiet"
}

# Compile solution
function Compile-Solution() {
    # Pass in the Parameters.
    param ([string] $solution, [string] $configuration, [string] $outputDirectory, [string] $visualStudioVersion)
    
    # Create build directory
    New-Item $buildDirectory -ItemType Directory -Force | Out-Null
    
    # Build solution
    # VisualStudioVersion property is necessary to locate WebApplication target
    Invoke-Expression "msbuild $solution /fl /flp:logfile=$buildLog /p:Configuration=$configuration /p:OutDir=$outputDirectory /p:VisualStudioVersion=$visualStudioVersion /t:Build /v:Quiet"
}

# Delete existing directory
function Delete-Directory() {
    # Pass in the Parameters.
    param ([string] $path)
    
    # Delete existing directory
    if (Test-Path $path) {
        Remove-Item $path -Force -Recurse
    }
}

# Pack binaries
function Pack-Binaries() {
    # Pass in the Parameters.
    param ([string] $packageName, [string] $tempDirectory, [string] $contentDirectory)
            
    # Create build tools directory
    New-Item $buildDirectory\tools -ItemType Directory -Force | Out-Null

    # Copy installation scripts and NuGet spec
    Copy-Item $baseDirectory\$packageName.nuspec $buildDirectory | Out-Null     
    Copy-Item chocolateyInstall.ps1 $buildDirectory\tools\ | Out-Null
    Copy-Item chocolateyUninstall.ps1 $buildDirectory\tools\ | Out-Null

    # Create Chocolatey package
    pushd $buildDirectory
        Invoke-Expression "$toolsDirectory\Chocolatey\chocolateyinstall\chocolatey.ps1 pack $packageName.nuspec"
    popd
    
    Copy-Item $buildDirectory\$solutionName.*.nupkg $packageDirectory | Out-Null
    
    Remove-Item $buildDirectory -Force -Recurse | Out-Null
    
    dir $packageDirectory
}

function FTP-Upload-File() {
    # Pass in the Parameters.
    param ([string] $localFile, [string] $remoteLocation)
    
    # create the FtpWebRequest and configure it
    $ftp = [System.Net.FtpWebRequest]::Create($remoteLocation)
    $ftp = [System.Net.FtpWebRequest]$ftp
    $ftp.Method = [System.Net.WebRequestMethods+Ftp]::UploadFile
    $ftp.Credentials = New-Object System.Net.NetworkCredential("anonymous","anonymous@localhost")
    $ftp.UseBinary = $true
    $ftp.UsePassive = $true
    # read in the file to upload as a byte array
    $content = [System.IO.File]::ReadAllBytes($localFile)
    $ftp.ContentLength = $content.Length
    # get the request stream, and write the bytes into it
    $rs = $ftp.GetRequestStream()
    $rs.Write($content, 0, $content.Length)
    # be sure to clean up after ourselves
    $rs.Close()
    $rs.Dispose()
}