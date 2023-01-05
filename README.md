# AFS (Apt Flatpak Snap Installer)

## Table of Contents

- [About](#about)
- [Install](#installing)
- [Usage](#usage)

## About <a name = "about"></a>

This is a simple command line tool you can use to install Apt/Flatpak/Snaps from one place, Prefers to install using apt         
but installs flatpak if no package of that name is found. Installs snap if neither apt nor flatpak is found.                 

## Installing <a name = "installing"></a>

Go to releases, and Download the executeable, and                           
copy it to /usr/bin or /usr/local/bin              

### Prerequisites

This software needs Flatpak and snaps to be installed on your system.                         

Installing snap - https://snapcraft.io/docs/installing-snapd             
Installing flatpak - https://flatpak.org/setup/Ubuntu            


### Building
To build this by yourself, you need to install dotnet(.NET) compiler on your system.                
Link to official Microsoft documentation on how to install -     
         
Run dotnet publish with self-contained as admin -     
```sudo dotnet publish --self-contained true```              
Your build will be found at bin/Debug/net7.0/linux-x64/publish/

Now you can install it normally. [Install](#installing)


## Usage <a name = "usage"></a>
To install an application use -    
```sudo afs install App```     
or    
```sudo afs i App```     
To remove an application use -     
```sudo afs remove App```     
or      
```sudo afs r App```       