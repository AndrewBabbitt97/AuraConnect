# AuraConnect 
This is a simple application to sync ASUS AURA Devices using the Razer Chroma Broadcast API. This should support all devices that work with AURA. If you have any devices not working be sure to report this. 


## HOW TO INSTALL AND ENABLE
- Make sure you have ASUS ARMOURY CRATE (Recommended) or ASUS AURA installed and working. 
- Make sure you have Razer Synapse 3 installed, updated and functioning. Razer Synapse 2 is not supported as it’s a legacy software that doesn’t support these types of API additions. 
- In ASUS ARMOURY CRATE, go to the Aura Sync tab. Make sure "In-game Lighting Effects" is enabled.
- Head over to the releases tab to grab the latest installer. 
- Install AURACONNECT and restart your machine to make sure it takes effect. 
- In Razer Synapse, go to the Connect tab, then the Devices subtab. Enable the ASUS device.
- You should now be able to control your ASUS AURA Devices Colors with Razer Synapse. 
- NOTE: Do not open ASUS ARMOURY CRATE again. It will try to overtake your Chroma effects.


## BEFORE REPORTING ANY ISSUES! 

**MAKE SURE THE ASUSCONNECT SERVICE IS RUNNING** 
- Open your Task Manager 
- Go to your Services Tab. 
- Check to see if the AURACONNECT services is running. If it's Stopped just right click and start the service back up. 

**MAKE SURE YOUR ANTI-VIRUS SOFTWARE IS NOT BLOCKING THE SERVICE**

Some Anti-Virus software seem to block installing or even running ASUSCONNECT or even ASUS AURA/ARMOURY. Make sure you allow the services/installs through them if possible and report the bug to your Anti-Virus software company as a false positive. 

**INSTALL ASUS ARMOURY CRATE INSTEAD OF ASUS AURA**

ASUS ARMOURY CRATE seems to be much better in support. Even if your device doesn't show as supported on their website or your motherboard support page, try it anyways, they are terrible at updating these when support is added. 
- If you have ASUS AURA installed, remove everything related to it before you try installing ASUS ARMOURY CRATE as this will cause issues. 
- Install ASUS ARMOURY CRATE. Restart when asked. (https://www.asus.com/supportonly/Armoury%20Crate/HelpDesk_Download/) 
- Start the software up and let it update.
- Once updated you need to update the components inside the software itself too. Go to Settings > Update Center > Check for Updates. Restart once done. 
- Check and see if your devices show up and are controllable and you can control your lighting effects. _*You should be able to select and control your lighting effects. If you can control it under the Devices or Aura tab you should be fine. One may not work over the other based on the devices you have._
- If it's not working or your device is not compatible, make sure to uninstall all services that ARMOURY CRATE has installed and go back to AURA. 


## BASIC TROUBLESHOOTING 

**BATTLEYE BLOCKING ASUSCONNECT**

This is a current issue with BattleEye software and is being tracked/reported. You can follow any changes through the issue tracker. (https://github.com/AndrewBabbitt97/AuraConnect/issues/23) 

**MY CPU USAGE IS TOO HIGH!**

This has nothing to do with AURACONNECT. AURACONNECT takes over the Asus Lighting Services and just allows for it to sync up with Razer Synapse. The high CPU usage seems to be related to the lighting effects selected. You can test this by opening AURA or ARMOURY CRATE and changing the lighting effects to Static and the CPU usage being at nearly 0% but change it to another effect and you will see it's usage jump. This will mostly be seen on lower to mid-range CPUs and probably not noticed on higher end CPUs with high core counts due to the amount of workload they can do. Running Razer Synapse under a static color will still cause high CPU Usage as it's being a "special effect." There is nothing you can do to fix this but to report the bug to ASUS and hope they fix the problem. 

**SYNAPSE DOES NOT CONTROL MY ASUS DEVICES**
- Make sure the AURACONNECT Services is running. 
- Try changing the effects inside of Synapse under the Studio Tab. This may be enough to trigger control back to AURACONNECT. 

**ARMOURY CRATE FIX**
- Startup ASUS ARMOURY CRATE 
- Make sure your devices are fully update and restart if needed. 
- Try changing your color effects under the AURA tab. 
- Close ARMOURY CRATE
- You may need to once you change the effect start the AURACONNECT Service again. 
- Make a change to the ASUS Service in Razer Synapse under the Studio Tab 
- Should take control of the devices within 30 seconds. 

**ASUS AURA FIX**
- Make sure the AURACONNECT Service is running first 
- Startup ASUS AURA. _*Make sure you see your devices showing, if your devices are missing like the motherboard, try the Advance Troubleshooting Steps._
- Select the option SELECT EFFECT. This should then open AURA for AURACONNECT to take over and you should see your lights start working. 
- If still no luck, select one of the prebuilt in software's color effects. Apply the changes and then select the option SELECT EFFECT and it should take over. 


## ADVANCE TROUBLESHOOTING 

**DEVICES NOT SHOWING UNDER ASUS AURA LIKE MOTHERBOARD**

If ASUS AURA can't see your devices, then AURACONNECT will not be able to work. 
- Uninstall all the AURA software including ASUSCONNECT. 
- Boot into your BIOS and disable the AURA/ROG Effects so all the RGB Lights and RGB Pins on the board turn off. 
- Shutdown the machine. 
- Boot back up into the BIOS and enable the AURA/ROG Effects so the lights start doing the default actions. 
- Check your ASUS folder under the programs folder and make sure all remanence of ASUSCONNECT and ASUS AURA are no longer present. 
- Install all the AURA Software again and restart when asked. 
- Install the AURACONNECT software and restart once installed. 
- Devices should be showing now. 

**AURA SOFTWARE WILL NOT RUN OR SAYS SERVICES ARE MISSING** 

This seems to stem from the AMD Chipset drivers causing the services to not correctly install or communicate with your motherboard/devices. There are a few fixes you can try. Make sure you have tried everything in the BASIC TROUBLESHOOTING first. 

_**BEFORE TRYING**_

_You need to make sure you backup your data and or create a system restore point in case of any issues are to occur. Also, you will need to uninstall all of the ASUS AURA Software before doing these steps. If you don't then it will still not work, a fresh install of the software needs to happen, or you will be stuck with a still broken software._


**AMD**

**UPDATE TO THE LATEST AMD CHIPSET DRIVERS**

Make sure you have the latest AMD Chipset drivers installed, you need to update to the latest one's provided by your Motherboards support page and see if that works or grab the latest from AMD's website under Driver Downloads (AMD may have newer then what ASUS provides for your motherboard so try the one on your device page first before getting AMD's). If grabbing the latest version still has issues, try the next step. 

**INSTALL OLDER AMD CHIPSET DRIVERS**

Your next step would be to uninstall the Chipset drivers and install an older one provided by your motherboards support page or from AMD's website, there is a small text link button provided on their driver page to get older drivers. Just keep going back an update until you get one that works. Now this may not even work as sometimes you may run into an issue where Windows won't allow for the drivers to rollback due to service blocks or just not being able to remove the drivers. 

**UNABLE TO INSTALL OLDER AMD CHIPSET DRIVERS**

Your last option is to reformat Windows and start fresh. Again, please backup all data before you do. Once you have reached the Windows Desktop follow the steps below. 
- DO NOT INSTALL ANYTHING FOR DRIVERS, UPDATES, NOTHING! 
- Install AURA Software and restart when asked 
- Startup the software and make sure you have all devices showing 
- Install AURACONNECT and Razer Synapse 3, restart once you have signed into Razer Synapse and it's updated and install everything needed. 
- Test AURACONNECT is working. 
- Update and install drivers as needed like normal. 


**INTEL**

Currently I'm unaware of any Intel or Intel Software related issues. If you have any issues and are using an Intel Chipset, please report these issues so it can be tracked. https://github.com/AndrewBabbitt97/AuraConnect/issues 
 

## NONE OF THESE STEPS WORKED!

If you're having issues with ARMOURY and AURA that conflicts with CONNECT report the buggy software problems to ASUS. ASUS AURA is a mess of a program that needs to be taken to its grave.
https://rog.asus.com/forum/forumdisplay.php?205-ASUS-Software

If everything is work just fine with ASUS ARMOURY CRATE or ASUS AURA there possibly may be an issue with AURACONNECT. Report your issues so it can be tracked.
