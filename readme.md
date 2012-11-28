## AutoProxy

AutoProxy is a simple tool that will automatically change your Windows proxy settings when your IP configuration (address, gateway, etc.) changes.

### Getting started

**Getting started with Git and GitHub**

 * People new to GitHub should consider using [GitHub for Windows](http://windows.github.com/).
 * If you decide not to use GHFW you will need to:
  1. [Set up Git and connect to GitHub](http://help.github.com/win-set-up-git/)
  2. [Fork the XPF repository](http://help.github.com/fork-a-repo/)
 * Finally you should look into [git - the simple guide](http://rogerdudler.github.com/git-guide/)

**Rules for Our Git Repository**

 * We use ["A successful Git branching model"](http://nvie.com/posts/a-successful-git-branching-model/). What this means is that:
   * You need to branch off of the [develop branch](https://github.com/redbadger/XPF/tree/develop) when creating new features or non-critical bug fixes.
   * Each logical unit of work must come from a single and unique branch:
     * A logical unit of work could be a set of related bugs or a feature.
     * You should wait for us to accept the pull request (or you can cancel it) before committing to that branch again.
     
### Using AutoProxy

AutoProxy uses profiles to configure your network. Each network that you configure in AutoProxy is checked against your current settings and if one matches your Windows proxy settings are updated. Type the name of the network into the drop down box at the top of the AutoProxy window and click the "+" button to add a new profile.

There is also the "(Default)" profile. This is a special profile that is activated in the event that no other profiles are matched - you should usually leave it blank.

The configuration window closely mirrors the Windows proxy settings window, so it should be familiar. The "detection" contains information about how AutoProxy should detect the network, in most cases clicking "Current" while connected to that network will get the correct values for you.

### License

AutoProxy uses the BSD 3-clause license, which can be found in license.txt.

**Additional Restrictions**

 * We only accept code that is compatible with the BSD license (essentially, MIT and Public Domain).
 * Copying copy-left (GPL-style) code is strictly forbidden.