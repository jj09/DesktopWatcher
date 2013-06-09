DesktopWatcher
==============

This application starts playing scary sound when you move mouse or push some key on keyboard. 
It is good to frighten those who want to mess up with your computer :)

How to use:

1. Run the app
2. Click play and choose some scary sound from your files (you can use alarm.mp3 from repo).
3. You need to leave cursor inside the application window to unable watching. You have 5 seconds for that (can be changed in Form1.cs line 73).
4. Quit the app:
  *  To quit app after you caught somebody you need to unlock the system and hit ALT-F4 immediately (two keys together - because alt cause lock screen again). If you are quick hand, you can try close app by mouse (click close cross) before it get unlocked again.
  *  To quit app and avoid sound you need to click ALT-F4. However computer will be locked anyway (but sound won't be played).

Issues:
* Sometimes you will need to unlock the system a few times, because it can detect previous moves after unlock.
* App is working appropriate only when cursor is on the app area. However it should be enough to caught people (if they do not know your app).
