# RemoteApps Loupedeck Plugin
[![License](http://img.shields.io/:license-MIT-blue.svg?style=flat)](LICENSE)
![forks](https://img.shields.io/github/forks/Steinerd/Loupedeck.RemoteAppsPlugin?style=flat)
![stars](https://img.shields.io/github/stars/Steinerd/Loupedeck.RemoteAppsPlugin?style=flat)
![issues](https://img.shields.io/github/issues/Steinerd/Loupedeck.RemoteAppsPlugin?style=flat)
[![downloads](https://img.shields.io/github/downloads/Steinerd/Loupedeck.RemoteAppsPlugin/latest/total?style=flat)](https://github.com/Steinerd/Loupedeck.RemoteAppsPlugin/compare)


--------

# Table of Contents

- [Installation](#installation)
- [Usage](#usage)
- [Support](#support)
- [Contributing](#contributing)
- [License](#license)

# Installation

<details><summary><b>Loupedeck Installation</b></summary>
  
  
  1. Go to [latest release](https://github.com/Steinerd/Loupedeck.RemoteAppsPlugin/releases/latest), and download the `lplug4` file to you computer
  1. Open (normally double-click) to install, the Loupedeck software should take care of the rest
  1. Restart Loupedeck (if not handled by the installer)
  1. In the Loupedeck interface, enable **RemoteApps** by clicking <ins>Manage plugins</ins>
  1. Check the RemoteApps box on to enable
  1. Drag the desired control onto your layout

Once click it will bring you to a dynamic playback device selection page. 
</details>

<details><summary><b>IDE Installation</b></summary>
  Made with Visual Studio 2022, C# will likely only compile in VS2019 or greater. 

  Assuming Loupedeck is already installed on your machine, make sure you've stopped it before you debug the project. 

  Debugging _should_ build the solution, which will then output the DLL, config, and pdb into your `%LocalAppData%\Loupedeck\Plugins` directory.

  If all goes well, Loupedeck will then open and you can then debug. 

</details>

# Usage

First, follow the __Loupedeck Installation__ instructions above. 

Just drag and drop the "Remote Apps" control onto your layout. 

# Support

[Submit an issue](https://github.com/Steinerd/Loupedeck.RemoteAppsPlugin/issues/new)

Fill out the template to the best of your abilities and send it through. 

# Contribute

Easily done. Just [open a pull request](https://github.com/Steinerd/Loupedeck.RemoteAppsPlugin/compare). 

Don't worry about specifics, I'll handle the minutia. 

# License
The MIT-License for this plugin can be reviewed at [LICENSE](LICENSE) attached to this repo.